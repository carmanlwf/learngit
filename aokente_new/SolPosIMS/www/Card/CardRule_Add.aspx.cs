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
using Ims.Card.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class Card_CardRule_Add : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            opeid.Value = Ims.Main.ImsInfo.CurrentUserId;
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
            ruleid.Value = Request.QueryString["getcode"].ToString();
            ControlHelper.SetControlReadonly(ruleid, true);
        }
        else
        {
            ruleid.Value = "T-" + DateTime.Now.ToString("yMdhms");

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
        card_chargerule newo = new card_chargerule();
        //newo.ruleid = ruleid.Value;
        //newo.rulename = rulename.Value;
        //newo.amount = int.Parse(amount.Value.Trim());
        //newo.gift = int.Parse(gift.Value.Trim());
        //newo.opeid = Ims.Main.ImsInfo.CurrentUserId;
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
