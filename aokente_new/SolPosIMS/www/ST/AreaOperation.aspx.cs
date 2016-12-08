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
using ZsdDotNetLibrary.Web;
using Ims.Site.Model;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class ST_AreaOperation : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            InitListControlHelper.InitListControls(typeof(tb_area));
            //GetDefaultValue(null);
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
            areacode.Value = Request.QueryString["getcode"].ToString();
            ControlHelper.SetControlReadonly(areacode, true);
        }
        else
        {
            areacode.Value = "A-" + DateTime.Now.ToString("yyyyMMddhhmmss");
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Insert();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Update();
    }

    protected override bool OnSelecting(ref object objKey, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        errorToDo |= WebClientHelper.ToDo.CloseSelfWindow;
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
        okToDo = WebClientHelper.ToDo.FormViewModeInsert;
        errorToDo = WebClientHelper.ToDo.FormViewModeInsert;
        tb_area newo = new tb_area();
        newo.regtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
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
        //areacode.Value = "A-" + DateTime.Now.ToString("yyyyMMddhhmmss");
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
