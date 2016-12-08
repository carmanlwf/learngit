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

public partial class  GroupOperation : FormNormalEditPage
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
            GroupID.Value = Request.QueryString["getcode"].ToString();
            ControlHelper.SetControlReadonly(GroupID, true);
        }
        else
        {
            GroupID.Value = "T-" + DateTime.Now.ToString("yMdhms");

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
        tb_Group newo = new tb_Group();
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
}
