using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Ims.PM.BLL;
using Ims.Site.Model;
using Ims.Site.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class ST_ParkingSiteOperation : FormNormalEditPage
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
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site");
            
            if(Request.QueryString["getcode"]!=null){
                string id= Request.QueryString["getcode"].ToString();
                string zhi = PosposListinfoHelper.GetSite_Codeid(id);
                Site_Code.SelectedValue = PosposListinfoHelper.GetSite_Codeid(id);
                Area_Code.SelectedValue = PosposListinfoHelper.GetArea_Codeid(Site_Code.SelectedValue);
            }
            //Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
            ////权限验证
            ////(区域代理)
            //if (Ims.Main.ImsInfo.UserIsInRole("agent") || Ims.Main.ImsInfo.UserIsInRole("manager"))
            //{
            //    Area_Code.Enabled = true;
            //    string siteID = PmTtBLLHelper.GetAreacodeByAgentID(Ims.Main.ImsInfo.CurrentUserId);//区域代理编号
            //    Area_Code.Items.FindByValue(siteID).Selected = true;
            //}

        }
        OnPageLoad();
        if (Request.QueryString["statu"] == "readonly")
        {
            ControlHelper.SetControlsReadonly(true);
            chflag.Attributes.Add("disabled", "disabled");
            btnUpdate.Visible = false;
            btnInsert.Visible = false;
        }
        else
        {
            ////权限设置
            //if (!PmRolesCheck.InPMRoles(PmRolesCheck.PmInfo_All))
            //{
            //    return;
            //}

        }
        if (Request.QueryString["getcode"] != null)
        {
            //skilllevel.Disabled = true;
            //pname.Disabled = true;
            //sex.Disabled = true;
            posnum.Value = Request.QueryString["getcode"].ToString();
           
            ControlHelper.SetControlReadonly(posnum, true);
        }
        else
        {

        }
    }
    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
           
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        siteid.Value = Area_Code.SelectedValue;
        //if (parkingsiteinfoHelper.IsExistsMagicID(this.siteid.Value) > 0)
        //{
        //    WebClientHelper.DoClientMsgBox("该地磁编号已存在,请更换！");
        //    return;
        //}
        if (siteid.Value == "所有路段" || siteid.Value == "")
        {
            WebClientHelper.DoClientMsgBox("请选择车位所在路段！");
            return;
        }

        //posnum
        pos_poslist s = PosposListinfoHelper.GetObject(posnum.Value);
        if (s == null)
        {
            Insert();
        }
        else
        {
            Msg("操作失败，终端编号重复！");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Update();
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
    protected void Insert()
    {
        pos_poslist newo = new pos_poslist();
        newo.isaction = 1;
        newo.posnum = posnum.Value;
        newo.postype = postype.Value;
        newo.productno = productno.Value;
        newo.opt_user = opt_user.Value;
        newo.addedtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        newo.flag = true;
        newo.siteid = Site_Code.SelectedValue;
        //ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
        PosposListinfoHelper.InsertObject(newo);
        Msg("添加数据成功！");
        //ChangeModeToInsert();
        //WebClientHelper.DoResultClientProcess(ex == null, msg, okToDo, errorToDo);
    }
    //protected override bool OnInserted(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    //{
    //    okToDo = WebClientHelper.ToDo.NoShowResultMsg;
    //    errorToDo = WebClientHelper.ToDo.FormViewModeInsert;
    //    pos_poslist newo = new pos_poslist();
    //    newo.isaction =1;
    //    newo.addedtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
    //    newo.flag = true;
    //    newo.siteid = Site_Code.SelectedValue;
    //    //ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
    //    PosposListinfoHelper.InsertObject(newo);
    //    string msg = "添加数据成功！";
    //    ClientScriptManager cs = Page.ClientScript;
    //    Type cstype = this.GetType();
    //    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
    //    {
    //        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

    //    }
    //    //ChangeModeToInsert();
    //    //WebClientHelper.DoResultClientProcess(ex == null, msg, okToDo, errorToDo);
    //    return true;
    //}

    protected override bool OnUpdated(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.NoShowResultMsg;
        errorToDo = WebClientHelper.ToDo.FormViewModeEdit;
        pos_poslist zhi =o as pos_poslist;
        zhi.siteid = Site_Code.SelectedValue;
        //bool ret = base.OnUpdated(zhi, result, ex, okToDo, errorToDo);
        PosposListinfoHelper.UpdateObject(zhi);
        Msg("修改成功！");
        return true;
    }
    public void Msg(string msg)
    {
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
    }
}
