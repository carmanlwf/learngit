
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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.PM;
using Ims.PM.BLL;

public partial class PM_Infor : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        //skillgroup.Visible = (Request.QueryString["statu"] == "readonly") ? true : false;
        if (!Page.IsPostBack)
        {
            InitListControlHelper.InitListControls(typeof(pm_employee));
            GetDefaultValue(null);
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
            //权限设置
            //if (!PmRolesCheck.InPMRoles(PmRolesCheck.PmInfo_Admin))//.PmInfo_All
            //{
            //    return;
            //}
        }
        if (Request.QueryString["getcode"] != null)
        {
            //skilllevel.Disabled = true;
            //pname.Disabled = true;
            //sex.Disabled = true;
            ControlHelper.SetControlReadonly(code, true);
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
        pm_employee newo = new pm_employee();
        GetDefaultValue(newo);
        ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
        string msg = "添加数据成功！";
        ChangeModeToInsert();
        WebClientHelper.DoResultClientProcess(ex == null, msg, okToDo, errorToDo);
        return true;
    }

    protected override bool OnUpdated(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.CloseSelfWindow;
        errorToDo = WebClientHelper.ToDo.FormViewModeEdit;
        return base.OnUpdated(o, result, ex, okToDo, errorToDo);
    }

    /// <summary>
    /// 设置初始值
    /// </summary>
    private void GetDefaultValue(pm_employee o)
    {
        if (o == null)
        {
            email.Value = "@qq.com";
        }
        else
        {
            o.sex = 0;
            o.email = "@qq.com";
        }
    }
}
