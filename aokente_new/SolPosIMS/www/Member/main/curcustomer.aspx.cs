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
using Ims.Card.Model;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class main_curcustomer : System.Web.UI.Page
{

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        string card = this.Card.Value.Trim();
        if (!string.IsNullOrEmpty(card))
        {
            BindCardInfo(card);
        }
        else
        {
            WebClientHelper.DoClientMsgBox("请输入会员卡号!");
            Card.Focus();
        }
    }
    public void BindCardInfo(string card)
    {
        tb_Card o = CardHelperBLL.GetObject(card);
        if (o != null)
        {
            ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
            LastConsumeTime.Value = TransHelperBLL.GetLastConsumeTime(card);
        }
        else
        {
            WebClientHelper.DoClientMsgBox("没有查询到相应的会员卡信息!");
            Card.Focus();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent") == "")
        //权限验证
        //if (!Ims.Main.ImsInfo.UserIsInRole("admin,agent,channel"))
        //{
        //    Response.Redirect("../Unauthorized.aspx");
        //}
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        { Response.Redirect("../Unauthorized.aspx"); }
        if (!Page.IsPostBack)
        {
            ControlHelper.SetControlsReadonly(true, "Card");
            Label1.Text = Ims.Main.ImsInfo.CurrentUserId;
            Label2.Text = Ims.Main.ImsInfo.CurrentUser.Name;
            Label3.Text = Ims.Main.ImsInfo.CurrentUser.HostName;
            Label4.Text = Ims.Main.ImsInfo.CurrentUser.ServerIp;
            Label5.Text = "VIP1.0.1优化版";
        }
    }
}
