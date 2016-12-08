using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewSoftDotNetLibrary.Web;
using Ims.Card.BLL;
using NewSoftDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;

public partial class main_RightMenu : System.Web.UI.Page
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
            //ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
            RealName.Value = o.RealName;
            sex.Value = o.Sex;
            CellPhone.Value = o.CellPhone;
            RankName.Value = o.TypeName;
            statusname.Value = o.statusname;
            Balance.Value = o.balance.ToString();
            Points.Value = o.Points.ToString();
            Expenditure.Value = o.Expenditure.ToString();
            sitename.Value = o.sitename;
            addeddate.Value = o.addeddate;
            validDate.Value = o.validDate;
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
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,manager,seller") == "")
        { Response.Redirect("../Unauthorized.aspx"); }
        if (!Page.IsPostBack)
        {
            string ucard = !string.IsNullOrEmpty(Request.QueryString["ucard"])?Request.QueryString["ucard"].ToString():"";
            if (!string.IsNullOrEmpty(ucard))
            {
                BindCardInfo(ucard);
                Card.Value = ucard;
            }
            else
            {
                Card.Focus();
            }

            ControlHelper.SetControlsReadonly(true, "Card");
            Label1.Text = Ims.Main.ImsInfo.CurrentUserId;
            Label2.Text = Ims.Main.ImsInfo.CurrentUser.Name;
            Label3.Text = Ims.Main.ImsInfo.CurrentUser.HostName;
            Label4.Text = Ims.Main.ImsInfo.CurrentUser.ServerIp;
            Label5.Text = "VIP1.0.3优化版";
        }
    }
}
