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
using Ims.PM.BLL;
using Ims.Card.BLL;
using Ims.Card.Model;
using Ims.Member.Model;
using Ims.Member.BLL;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Web;
using System.Collections.Generic;
using Ims.Log.Model;

public partial class Money_Charge : FormNormalEditPage

{
    protected void Page_Load(object sender, EventArgs e)
    {

        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }
    public void BindCard(string card)
    {
        if (!string.IsNullOrEmpty(card))
        {
            
            tb_Card o = new tb_Card();
            o = CardHelperBLL.GetObject(card);
            if (o != null)
            {
                //判断卡状态
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();

                if ((int)o.Status == 0)
                {
                    msg = "卡未激活，请先激活后再进行充值...";
                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                        return;
                    }
                }
                if ((int)o.Status == 2)
                {
                    msg = "卡片处于挂失状态，不能进行充值...";
                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                        return;
                    }
                }
                if ((int)o.Status == 3)
                {
                    msg = "卡片处于注销状态，不能进行充值...";
                    if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                    {
                        cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                        return;
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
                    ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.OpQuery);//绑定卡信息到页面上
                    gift.Value = "";
                    rulename.Value = "";
                    chargeAmount.Value = "";
                    chargeAmount.Focus();
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("系统不存在此卡信息!");
                gift.Value = "";
                rulename.Value = "";
                chargeAmount.Value = "";
            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("请输入卡号!");
        }
    }

    protected void btnCharge_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 1 && TypeName.Value.Trim() != "临时卡")
        {
            WebClientHelper.DoClientMsgBox("非临时卡不支持退款操作！");
            return;
        }
        string msg = "";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();

        tb_Card o = new tb_Card();
        o = CardHelperBLL.GetBalanceObject(card.Value.Trim());
        
        card_chargelist c = new card_chargelist();       
        c.transId = DateTime.Now.ToString("yyyyMMddHHmmss");
        c.Card = card.Value;
        c.cardtype = TypeName.Value;
        if (RadioButtonList1.SelectedItem.Text == "退卡退款")
        {  
            c.Chargetype = "扣款";
            if (decimal.Parse(chargeAmount.Value) > (decimal)(o.balance))
            {
                WebClientHelper.DoClientMsgBox("卡上余额不足，不能执行此操作!");
                return;
            }
           
        }
        else {  
            c.Chargetype = "充值";          
        }   

        c.amount = decimal.Parse(chargeAmount.Value);
        int result_gift = 0;
        int.TryParse(gift.Value.Trim(), out result_gift);
        c.gift = result_gift;
        c.Rulename = rulename.Value;
        c.Logtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        c.chargeway = "在线";
        c.operid=Ims.Main.ImsInfo.CurrentUserId;

        tb_Log log = new tb_Log();
        log.logid = DateTime.Now.ToString("yyyyMMddHHmmss");
        log.operater=Ims.Main.ImsInfo.CurrentUserId;
        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        log.type=" 平台充值";
        log.logmsg = log.operater + " 对卡号为"+card.Value+"的用户充值,充值金额" +c.amount + "元!";

        decimal NowMoney = decimal.Parse(!string.IsNullOrEmpty(Balance.Value.Trim())?Balance.Value.Trim():"0") ;
        decimal money = decimal.Parse(!string.IsNullOrEmpty(chargeAmount.Value.Trim())?chargeAmount.Value.Trim():"0") ;
        decimal money_gift = decimal.Parse(!string.IsNullOrEmpty(gift.Value.Trim())?gift.Value.Trim():"0") ;
        if (RadioButtonList1.SelectedIndex == 1) //退款
        {
            money = -money;
        }
        o.Balance = (decimal)(NowMoney + money + money_gift);

        bool ret = CardChargeListBLL.UpdateBalanceAndInsert(Balance.Value.Trim(),o.Balance.ToString(), card.Value, c, log);

        if (ret)
        {
            Balance.Value = o.Balance.ToString();
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>openwin();</script>");

            //跳转到充值页面
            //Response.Redirect("../Sysem/Cardchargelist.aspx");
        }
        else
            return;
    }
    /// <summary>
    /// 读卡，根据卡号读取会员信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReadCard_Click(object sender, EventArgs e)
    {
        string s = HexStrToAsc(RF_Card.Value);
        string card = s;
        BindCard(card);
    }

    /// <summary>
    /// 十六进制字符串转ascii码
    /// </summary>
    /// <param name="HexStr"></param>
    /// <returns></returns>
    public static string HexStrToAsc(string HexStr)
    {
        HexStr = HexStr.Replace(" ", "");
        List<byte> buffer = new List<byte>();
        for (int i = 0; i < HexStr.Length; i += 2)
        {
            string temp = HexStr.Substring(i, 2);
            byte value = Convert.ToByte(temp, 16);
            buffer.Add(value);
        }
        //string str = System.Text.Encoding.ASCII.GetString(buffer.ToArray());
        string str = System.Text.Encoding.GetEncoding("GB2312").GetString(buffer.ToArray());
        return str;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
}

