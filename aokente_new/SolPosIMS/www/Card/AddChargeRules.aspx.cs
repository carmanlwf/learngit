using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ims.Main;
using Ims.Card.BLL;

public partial class Card_AddChargeRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hd_MaxChargeValue.Value = tb_CardActive_HistroyBLL.GetMaxChargeRuleValue().ToString();
            hd_MinChargeValue.Value = tb_CardActive_HistroyBLL.GetMinChargeRuleValue().ToString();
            lbbounsid.Text = DateTime.Now.ToString("yyMMddHHmmss");
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Ims.Card.Model.cardchargerule o = new Ims.Card.Model.cardchargerule();
        decimal s_amount = 0;
        decimal e_amount = 0;
        decimal a_money = 0;
        decimal g_money = 0;
        o.bounsid = lbbounsid.Text;
        o.bounsname = txtName.Value;
        decimal.TryParse(txtStartMoney.Value, out s_amount);
        decimal.TryParse(txtendMoney.Value, out e_amount);
        decimal.TryParse(txtMoney.Value, out a_money);
        decimal.TryParse(txtGiftMoney.Value, out g_money);
        o.beginAmount = s_amount;
        o.endAmount = e_amount;
        o.actualMoney = a_money;
        o.giftMoney = g_money;
        o.operatorid = ImsInfo.CurrentUserId;

        int ret = tb_CardActive_HistroyBLL.InsertObject_ChargeRules(o);
        if (ret > 0)
        {
            string msg = "操作成功!" + ret + "条记录已添加.";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
            }
        }
    }
}

