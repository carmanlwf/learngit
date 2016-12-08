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
using Ims.Log.Model;
using ZsdDotNetLibrary.Web;

public partial class Card_CardAddMoney : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          //string card = Request.QueryString["getcode"].ToString();
        if(!IsPostBack)
        {
            if( Request.QueryString["getcode"]!=null)
            {
                tb_Card o = new tb_Card();
                //o = CardHelperBLL.GetObjec(Request.QueryString["getcode"].ToString());
                o = CardHelperBLL.GetObject(Request.QueryString["getcode"].ToString());
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if ((int)o.Status == 0)
                {
                    msg = "卡未激活，请先激活后再进行充值...";
                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    }
                }
                if ((int)o.Status == 2)
                {
                    msg = "卡片处于挂失状态，不能进行充值...";
                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    }
                }
                if ((int)o.Status == 3)
                {
                    msg = "卡片处于注销状态，不能进行充值...";
                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    }
                }
                if ((int)o.Status == 4)
                {
                    msg = "卡片处于补卡状态，不能进行充值...";
                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                        return;
                    }
                }
                else
                {
                    card.Value = Request.QueryString["getcode"].ToString();
                    RealName.Value = o.RealName;
                    balance.Value = o.balance.ToString();
                    TypeName.Value = o.TypeName;
                    DisCrad.Value = o.Recharge.ToString();
                }
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tb_Card card1 = new tb_Card();
        card1.card = card.Value;
        card1.balance = Convert.ToDecimal(balance2.Value);

        tb_Log log = new tb_Log();
        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        log.logmsg = "为卡号:" + card.Value + "的用户充值,充值金额:" + Bance3.Value + "元";
        log.operater = Ims.Main.ImsInfo.CurrentUserId;
        log.type = "平台充值";
        log.flag = true;

        tb_TransLog t = new tb_TransLog();
        t.TransNo = "T-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        t.ActualCost = decimal.Parse(Bance3.Value);//实际发金额
        t.Card = card.Value;
        t.ChargeAmount = decimal.Parse(balance1.Value);//交易金额
        t.memo = Memo.Value;
        t.OperateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        t.operatorid = Ims.Main.ImsInfo.CurrentUserId;
        //t.ChargeAmount = decimal.Parse(Bance3.Value);
        t.transType = 1; //充值
        t.TransWay =1;//交费方式
        t.flag = true;
        t.memberReak = RealName.Value;
        t.remainMoney = decimal.Parse(balance.Value);//充值前余额
        if (DisCrad.Value == "")
        { DisCrad.Value = "0"; }
        else
        {
            t.chargeRate = decimal.Parse(DisCrad.Value);
        }
        t.finallyCost = decimal.Parse(balance2.Value);

        if (TransHelperBLL.Card_ChongZhi(t, card1, log))
        {
            //WebClientHelper.DoClientMsgBox("操作已成功!当前账户余额为:" + m.Balance.ToString() + "元");
            string msg = "操作已成功!当前账户余额为:" + balance2.Value + "元";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
 
            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("操作失败!请重试.");
        }
    }
}
