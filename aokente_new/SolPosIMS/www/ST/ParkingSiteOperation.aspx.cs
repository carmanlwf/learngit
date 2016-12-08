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
using Ims.Admin.BLL;

public partial class ST_ParkingSiteOperation : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,manager,seller,channel") == "")
        {

            Response.Redirect("../Unauthorized.aspx");
        }
       
        Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
        Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        if (!IsPostBack) {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site");
            if (Request.QueryString["getcode"] != null)
            {
                string id = Request.QueryString["getcode"].ToString();
                Site_Code.SelectedValue = parkingsiteinfoHelper.GetParkingidSite_Codeid(id);
                Area_Code.SelectedValue = PosposListinfoHelper.GetArea_Codeid(Site_Code.SelectedValue);
            }
        }
            InitListControlHelper.InitListControls(typeof(park_parkingsite));
            //GetDefaultValue(null);
           
            //(区域代理)
            if (Ims.Main.ImsInfo.UserIsInRole("agent") || Ims.Main.ImsInfo.UserIsInRole("manager"))
            {
                //Area_Code.Disabled = true;
                string siteID = PmTtBLLHelper.GetAreacodeByAgentID(Ims.Main.ImsInfo.CurrentUserId);//区域代理编号
                Area_Code.Items.FindByValue(siteID).Selected = true;
                //areacode.Items.FindByText(sort).Selected = true;
            }
            //品牌经理
            if (Ims.Main.ImsInfo.UserIsInRole("channel"))
            {
                string sort = AgentInfoBLL.GetChannelSort();//获取品牌渠道
                Site_Code.Items.FindByText(sort).Selected = true;

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
        }
        if (Request.QueryString["getcode"] != null)
        {
            parkingid.Value = Request.QueryString["getcode"].ToString();
            ControlHelper.SetControlReadonly(parkingid, true);
        }
        else
        {
            parkingid.Value = "P-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            //根据登录用户，获得区域编号后，插入分店
            if (Ims.Main.ImsInfo.UserIsInRole("agent"))
            {
                Site_Code.SelectedValue = PmTtBLLHelper.GetAreacodeByAgentID(Ims.Main.ImsInfo.CurrentUserId);

            }

        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        siteid.Value = Site_Code.SelectedValue;
        int ret_magic = 0;
        ret_magic = parkingsiteinfoHelper.IsExistsMagicID(this.magicid.Value.Trim());
        if (ret_magic > 0)
        {
            WebClientHelper.DoClientMsgBox("该地磁编号已存在,请更换！");
            return;
        }
        int ret_parking = parkingsiteinfoHelper.IsExistsParkingName(this.parkingname.Value.Trim());
        if (ret_parking > 0)
        {
            WebClientHelper.DoClientMsgBox("该车位编号(自定义)已存在,请更换！");
            return;
        }
        if (siteid.Value == "所有路段" || siteid.Value == "")
        {
            WebClientHelper.DoClientMsgBox("请选择车位所在路段！");
            return;
        }
        Insert();

    }
    protected void Insert()
    {
        park_parkingsite newo =new park_parkingsite();
        newo.siteid = Site_Code.SelectedValue;
        newo.parkingid = parkingid.Value;
        newo.parkingname = parkingname.Value;
        newo.magicid = magicid.Value;
        newo.opt_user = Ims.Main.ImsInfo.CurrentUserId;
        newo.flag = true;
        newo.isbusy = 0;

        //GetDefaultValue(newo);
        parkingsiteinfoHelper.InsertObject(newo);
        //ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
        string msg = "添加数据成功！";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
        //ChangeModeToInsert();
        //WebClientHelper.DoResultClientProcess(ex == null, msg, okToDo, errorToDo);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Update();
    }
    protected void Update() {
        park_parkingsite site = new park_parkingsite();
        site.parkingid = Request.QueryString["getcode"].ToString();
        site.parkingname = parkingname.Value;
        site.magicid = magicid.Value;
        site.siteid = Site_Code.SelectedValue;
        site.flag = true;
        parkingsiteinfoHelper.UpdateObject(site);
        string msg = "";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

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

    //protected override bool OnInserted(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    //{

    //    okToDo = WebClientHelper.ToDo.NoShowResultMsg;
    //    errorToDo = WebClientHelper.ToDo.FormViewModeInsert;
        
    //    park_parkingsite newo = o as park_parkingsite;
    //    newo.siteid = areacode.Value;
    //    newo.opt_user = Ims.Main.ImsInfo.CurrentUserId;
    //    newo.flag = true;
    //    newo.isbusy = 0;
            
    //    //GetDefaultValue(newo);
    //    ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
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

    //protected override bool OnUpdated(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    //{
    //    okToDo = WebClientHelper.ToDo.NoShowResultMsg;
    //    errorToDo = WebClientHelper.ToDo.FormViewModeEdit;
    //    bool ret = base.OnUpdated(o, result, ex, okToDo, errorToDo);
    //    string msg = "";
    //    ClientScriptManager cs = Page.ClientScript;
    //    Type cstype = this.GetType();
    //    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
    //    {
    //        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

    //    }
    //    return ret;
    //}
    //protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Area_Code.SelectedValue == "")
    //    {
    //        Site_Code.Items.Clear();
    //        Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
    //    }
    //    else
    //    {
    //        InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
    //        Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
    //    }
    //}
    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            //Site_Code.Items.Clear();
            //Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            //Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
    }
}
