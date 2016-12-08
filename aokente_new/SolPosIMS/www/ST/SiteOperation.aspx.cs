using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ims.Site.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.PM.BLL;
using Ims.Admin.BLL;
using Ims.Site.BLL;
public partial class ST_SiteOperation : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,manager,seller,channel") == "")
        {

            Response.Redirect("../Unauthorized.aspx");
        }
        //skillgroup.Visible = (Request.QueryString["statu"] == "readonly") ? true : false;
        if (!Page.IsPostBack)
        {
            Category.Items.Insert(0, new ListItem("自营路段", "自营路段"));
            Category.Items.Insert(1, new ListItem("合营路段", "合营路段"));
            Category.Items.Insert(2, new ListItem("私家路段", "私家路段"));
            Category.Items.Insert(3, new ListItem("承包路段", "承包路段"));


            InitListControlHelper.InitListControls(typeof(tb_site));
            //GetDefaultValue(null);
            InitListControlHelper.BindNormalTableToListControl(areacode, "areacode", "areaname", "tb_area");
            //权限验证
            //(区域代理)
            if (Ims.Main.ImsInfo.UserIsInRole("agent") || Ims.Main.ImsInfo.UserIsInRole("manager"))
            {
                areacode.Disabled = true;
                string siteID = PmTtBLLHelper.GetAreacodeByAgentID(Ims.Main.ImsInfo.CurrentUserId);//区域代理编号
                areacode.Items.FindByValue(siteID).Selected = true;
                //areacode.Items.FindByText(sort).Selected = true;
            }

        }
        OnPageLoad();
        if (Request.QueryString["statu"] == "readonly")
        {
            ControlHelper.SetControlsReadonly(true);
            chflag.Attributes.Add("disabled", "disabled");
            btnUpdate.Visible = false;
            btnInsert.Visible = false;
        }


        if (Request.QueryString["getcode"] != null)
        {
            //skilllevel.Disabled = true;
            //pname.Disabled = true;
            //sex.Disabled = true;
            id.Value = Request.QueryString["getcode"].ToString();
            ControlHelper.SetControlReadonly(id, true);
        }
        else
        {
            id.Value = "S-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            //根据登录用户，获得区域编号后，插入分店
            if (Ims.Main.ImsInfo.UserIsInRole("agent"))
            {
                areacode.Value = PmTtBLLHelper.GetAreacodeByAgentID(Ims.Main.ImsInfo.CurrentUserId);

            }
            //根据登录用户，得到品牌编号，并插入
            if (Ims.Main.ImsInfo.UserIsInRole("channel"))
            {
                string sort = AgentInfoBLL.GetChannelSort();//获取品牌渠道
                Category.Value = sort;
            }

        }
    }
    bool isflt = false;
    public void isfloat()
    {
        IsOpenFence.Value = Isfence.Checked.ToString();
        string val = "LimitsFar|" + Request.Params["LimitsFar"] + "," + "Longitude|" + Request.Params["Longitude"] + "," + "latitude|" + Request.Params["latitude"];
        string[] arry = val.Split(',');
        for (int i = 0; i < arry.Length;i++)
        {
            string chenck = "^[0-9]+(\\.[0-9]+)?$";
            string[] arry2 = arry[i].Split('|');
            if (arry2[1] != null && System.Text.RegularExpressions.Regex.IsMatch(arry2[1], chenck))
            {
                isflt = true;
            }
            else
            {
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    isflt = false;
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>Checkid('" + arry2[0] + "');</script>");
                    break;
                }
            }
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        isfloat();
        if (isflt)
        {
            Insert();
        }
       
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        isfloat();
        if (isflt)
        {
            Update();
        }
    }

    protected override bool OnSelecting(ref object objKey, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        errorToDo = WebClientHelper.ToDo.CloseSelfWindow;
        return base.OnSelecting(ref objKey, okToDo, errorToDo);
    }

    protected override void OnChangeModeToInsert()
    {
        btnUpdate.Visible = false;
        btnInsert.Visible = true;
        chflag.Disabled = true;
        chflag.Checked = true;
    }

    protected override void OnChangeModeToUpdate()
    {

        btnUpdate.Visible = true;
        btnInsert.Visible = false;
        chflag.Disabled = false;
    }

    protected override bool OnInserted(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.NoShowResultMsg;
        errorToDo = WebClientHelper.ToDo.FormViewModeInsert;
        tb_site newo = new tb_site();
        //GetDefaultValue(newo);
        ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
        string msg = "添加数据成功！";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
        //ChangeModeToInsert();
        //WebClientHelper.DoResultClientProcess(ex == null, msg, okToDo, errorToDo);
        return true;
    }

    protected override bool OnUpdated(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.NoShowResultMsg;
        errorToDo = WebClientHelper.ToDo.FormViewModeEdit;
        bool ret = base.OnUpdated(o, result, ex, okToDo, errorToDo);
        string msg = "";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
        return ret;
    }

}
