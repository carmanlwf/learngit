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
using Ims.Card.Model;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class Card_CardTypeOper : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        OnPageLoad();
        if (Request.QueryString["statu"] == "readonly")
        {
            ControlHelper.SetControlsReadonly(true);
            btnUpdate.Visible = false;
            btnInsert.Visible = false;
        }
        else
        {

        }

        if (Request.QueryString["getcode"] != null)
        {
            TypeID.Value = Request.QueryString["getcode"].ToString();
            ControlHelper.SetControlReadonly(TypeID, true);
        }
        else
        {
            TypeID.Value = "T-" + DateTime.Now.ToString("yMdhms");

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
    protected override void OnChangeModeToInsert()
    {
        btnUpdate.Visible = false;
        btnInsert.Visible = true;

    }

    protected override void OnChangeModeToUpdate()
    {

        btnUpdate.Visible = true;
        btnInsert.Visible = false;

    }

    protected override bool OnInserted(object o, int result, Exception ex, WebClientHelper.ToDo okToDo, WebClientHelper.ToDo errorToDo)
    {
        okToDo = WebClientHelper.ToDo.CloseSelfWindow;
        errorToDo = WebClientHelper.ToDo.FormViewModeInsert;
        tb_CardType newo = new tb_CardType();
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
