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
using Ims.Card.BLL;
using System.Threading;
using Ims.Log.Model;
using Ims.Log.BLL;
using ZsdDotNetLibrary.Web;
using System.Text;
using System.Collections.Generic;

public partial class Card_BatchRecharge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 格式化卡号后半部分
    /// </summary>
    /// <param name="baseNum"></param>
    /// <param name="i_sqno"></param>
    /// <returns></returns>
    public string FormatCardStr(string baseNum, int i_sqno)
    {
        int cardrihgtlenth = 0;
        if (StartNum.Value.Trim() != "")
        {
            cardrihgtlenth = StartNum.Value.Trim().Length;
        }
        else
        {
            cardrihgtlenth = 3;
        }
        Int64 baseNo = Int64.Parse(baseNum) + Convert.ToInt64(i_sqno);
        string str_temp = baseNo.ToString();
        while (str_temp.Length < cardrihgtlenth) //10,8,6
        {
            str_temp = "0" + str_temp;
        }
        return str_temp;
    }

    protected void bt_Batch_ServerClick(object sender, EventArgs e)
    {
        string card_head = CardPre.Value;
        int card_num = 0;
        try
        {
           card_num = int.Parse(EndNum.Value.ToString().Trim()) - int.Parse(StartNum.Value.ToString().Trim()) + 1;
        }
        catch (Exception)
        {

            WebClientHelper.DoClientMsgBox("请输入数字型的卡号！");
            return;
        }
     
        int succes_num = 0;
        double init_balance = string.IsNullOrEmpty(InitBalance.Value.Trim()) ? 0.00 : double.Parse(InitBalance.Value);
        int num = 0;
        string str = "";
       // List<tb_TransLog> lt = new List<tb_TransLog>();

        for (int i = 0; i < card_num; i++)
        {
            tb_Card c = new tb_Card();
            c.card = card_head + FormatCardStr(StartNum.Value.Trim(), i);

           tb_Card t= CardHelperBLL.GetObject_objec(c.card.Trim());

            if (t == null)//系统是否已有此卡号
            {
              
                num++;
                if (num < 11)
                {
                    str += c.card + "|";
                  
                }
                else
                {
                    str = num.ToString();
                }
            }
            else
            {  
                c.Balance = t.balance + Convert.ToDecimal(InitBalance.Value); //账户余额
             
                  tb_TransLog tl = new tb_TransLog();
                tl.TransNo = "T-" + DateTime.Now.ToString("yyyyMMddhhmmss")+i;
                tl.transType = 1;
                tl.Card = c.card;
                tl.ChargeAmount = Convert.ToDecimal(InitBalance.Value);
                tl.ActualCost = Convert.ToDecimal(InitBalance.Value);
                tl.OperateDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                tl.TransWay = 1;
                tl.operatorid = Ims.Main.ImsInfo.CurrentUserId;
                tl.remainMoney = t.balance;
                tl.chargeRate = 0;
                tl.flag = true;
                tl.finallyCost = c.Balance;


                if (CardHelperBLL.UpdateObject(c) > 0 && TransLogHelperBLL.InsertObject(tl) > 0)
                {
                    succes_num++;
                    Thread.Sleep(20);

                }
                else
                {
                    continue;
                }
            }
        }
        if (str == "")
        {
            str = "0";
        }
        if (succes_num > 0)
        {
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.type = "批量充值";
            log.logmsg = "批量充值操作.卡号前缀：" + CardPre.Value + ",起始序号：" + StartNum.Value + ",张数：" + card_num + ",充值金额：" + InitBalance.Value + "，共有" + succes_num + "张成功,有"+str+"张卡充值失败，原因是不存在此卡.";
            log.flag = true;
            LogHelperBLL.InsertObject(log);
        }
        CardPre.Value = "";
        StartNum.Value = "";
        EndNum.Value = "";
        InitBalance.Value = "";
        WebClientHelper.DoClientMsgBox("批量充值结束!共有" + succes_num + "张成功,有" + str + "张卡充值失败，原因是不存在此卡.");

    }
}
