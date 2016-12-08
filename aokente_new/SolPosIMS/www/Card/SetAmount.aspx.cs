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
using Ims.Main;
using Ims.Card.BLL;

public partial class Card_SetAmount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hd_MaxChargeValue.Value = tb_CardActive_HistroyBLL.GetMaxChargeRuleValue().ToString();
            hd_MinChargeValue.Value = tb_CardActive_HistroyBLL.GetMinChargeRuleValue().ToString();
            if (!string.IsNullOrEmpty(Request.QueryString["getcode"]))
            {
                lbbounsid.Text = Request.QueryString["getcode"].ToString();
                cardchargerule o = tb_CardActive_HistroyBLL.GetObject_ChargeRules(lbbounsid.Text);
                ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.OpDefault);
            }
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        cardchargerule o = new cardchargerule();
        decimal s_amount = 0;
        decimal e_amount = 0;
        decimal a_money = 0;
        decimal g_money = 0;
        o.bounsid = lbbounsid.Text;
        o.bounsname = bounsname.Value;
        decimal.TryParse(giftMoney.Value, out s_amount);
        decimal.TryParse(endAmount.Value, out e_amount);
        decimal.TryParse(actualMoney.Value, out a_money);
        decimal.TryParse(giftMoney.Value, out g_money);
        o.beginAmount = s_amount;
        o.endAmount = e_amount;
        o.actualMoney = a_money;
        o.giftMoney = g_money;
        o.operatorid = ImsInfo.CurrentUserId;

        int ret = tb_CardActive_HistroyBLL.UpdateObject_ChargeRules(o);
        if (ret > 0)
        {
            string msg = "操作成功!" + ret + "条记录已修改.";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
            }
        }
    }
}
