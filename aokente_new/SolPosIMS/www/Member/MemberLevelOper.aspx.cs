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
using Ims.Member.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Member.BLL;

public partial class Member_MemberLevelOper : FormNormalEditPage
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
            InitListControlHelper.InitListControls(typeof(tb_MemberRanks));
            //InitListControlHelper.BindNormalTableToListControl(regionid, "id", "sitename", "tb_site");
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
            id.Value = Request.QueryString["getcode"].ToString();
            ControlHelper.SetControlReadonly(id, true);
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (MemberRanksHelper.GetObject(id.Value.Trim()) != null)
        {
            WebClientHelper.DoClientMsgBox("等级编号不能重复！");
            id.Focus();
            return;
        }
        else
        {
            Insert();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Update();
    }
    protected override void OnChangeModeToInsert()
    {
        btnUpdate.Visible = false;
        btnInsert.Visible = true;
        chflag.Disabled = true;
        chflag.Checked = false;
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
        tb_MemberRanks newo = new tb_MemberRanks();
        //GetDefaultValue(newo);
        ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
        newo.addeddate = DateTime.Now.ToString();
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
}
