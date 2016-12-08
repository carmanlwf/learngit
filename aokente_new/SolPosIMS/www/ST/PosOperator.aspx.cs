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
using Ims.Site.Model;
using Ims.PM.BLL;
using Ims.Site.BLL;

public partial class Product_PosOperatorSortOperation : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        OnPageLoad();
        if (Request.QueryString["statu"] == "readonly")
        {
            ControlHelper.SetControlsReadonly(true);
            cbIsCharge.Attributes.Add("disabled", "disabled");
            btnUpdate.Visible = false;
            btnInsert.Visible = false;
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if (SiteHelperBLL.tb_Pos_Operatorid(Operatorid.Value.Trim()) > 0)
        {
            WebClientHelper.DoClientMsgBox(Operatorid.Value.Trim()+"此操作员已存在，请输入其它操作员");
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

    protected override bool OnSelecting(ref object objKey, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        errorToDo |= WebClientHelper.ToDo.CloseSelfWindow;
        return base.OnSelecting(ref objKey, okToDo, errorToDo);
    }

    protected override void OnChangeModeToInsert()
    {
        btnUpdate.Visible = false;
        btnInsert.Visible = true;

    }

    protected override void OnChangeModeToUpdate()
    {

        btnUpdate.Visible = true;
        Operatorid.Disabled = true;
        //pass.Visible = false;
        LabePassWord.Visible = false;
        btnInsert.Visible = false;
    }

    protected override bool OnInserted(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.NoShowResultMsg;
        errorToDo = WebClientHelper.ToDo.FormViewModeInsert;
        tb_Pos_Operator newo = new tb_Pos_Operator();
        ParameterBindHelper.BindObjectToParameter(newo, BindParameterUsage.OpQuery);
        string msg = "添加数据成功！";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
        //string msg = "添加数据成功！";
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
