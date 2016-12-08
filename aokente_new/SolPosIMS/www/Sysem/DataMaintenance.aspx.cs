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
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.Site.BLL;
using Ims.Site.Model;

public partial class Sysem_DataMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
        }
    }

    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            Site_Code.Items.Clear();

        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");

        }
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        if (Checkbox3.Checked == true)
        {
            if (SiteHelperBLL.UpateCountSite() > 0)
            {
                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                log.logmsg = log.operater + "将所有的分店统计记录清零!";
                LogHelperBLL.InsertObject(log);
                WebClientHelper.DoClientMsgBox("分店统计已经全部清空!");
            }
        }
        if (Checkbox4.Checked == true)//全部
        {
            tb_site ts = new tb_site();
            ts.Moneyconsume = 0;
            ts.Moneyrecharge = 0;
            ts.MoneyRemove = 0;
            ts.NUMconsume = 0;
            ts.NUMrecharge = 0;
            ts.NUMRemove = 0;
            ts.id = Site_Code.SelectedValue.ToString();
            if (SiteHelperBLL.UpdateObject(ts) > 0)
            {
                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                log.logmsg = log.operater + "将分店编号" + Site_Code.SelectedValue.ToString() + "统计记录清零!";
                LogHelperBLL.InsertObject(log);
                WebClientHelper.DoClientMsgBox("该分店统计已经清空!");
            }
        }
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        if (Transaction1.Checked == true)//全部
        {
            if (POS_TransactionBLL.countPosTransaction() == 0)
            {
                WebClientHelper.DoClientMsgBox("交易记录为全空状态!");
            }
            else
            {
                if (POS_TransactionBLL.Deletecdtb_POS_Transaction() > 0)
                {
                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "清除所有的交易记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("清除成功!");
                }
                else
                {
                    WebClientHelper.DoClientMsgBox("已清空!");
                }
            }
        }
        if (Transaction2.Checked == true)
        {
            if (operate_date_begin.Value.Trim() != "" && operate_date_end.Value.Trim() != "")
            {
                //判断有没有数据
                int h = POS_TransactionBLL.countPosTransactionBytime(operate_date_begin.Value.Trim(), operate_date_end.Value.Trim());

                if (h == 0)
                {
                    WebClientHelper.DoClientMsgBox("此时间段内无数据清除!");
                }
                else
                {
                    if (POS_TransactionBLL.Deletecdtb_POS_TransactionByTime(operate_date_begin.Value.Trim(), operate_date_end.Value.Trim()) > 0)
                    {
                        //写入日志
                        tb_Log log = new tb_Log();
                        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        log.operater = Ims.Main.ImsInfo.CurrentUserId;
                        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        log.type = "删除操作";
                        log.logmsg = log.operater + "删除从时间" + operate_date_begin.Value + "到时间" + operate_date_end.Value + "的数据!";

                        LogHelperBLL.InsertObject(log);

                        WebClientHelper.DoClientMsgBox("清除成功!");
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("清除失败!");
                    }
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("请选择正确的时间段清空!");
            }
        }
    }

    protected void Button5_ServerClick(object sender, EventArgs e)
    {
        if (systemLog1.Checked == true)
        {
            if (LogHelperBLL.Deletecdttb_Log() > 0)
            {
                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                log.logmsg = log.operater + "清除所有的日志记录!";
                LogHelperBLL.InsertObject(log);

                WebClientHelper.DoClientMsgBox("清除成功!");
            }
            else
            {
                WebClientHelper.DoClientMsgBox("数据已清空!");
            }
        }
        if (systemLog2.Checked == true)
        {
            if (systemLogtime1.Value.Trim() != "" && systemLogtime2.Value.Trim() != "")
            {
                int h = LogHelperBLL.counlogbytime(systemLogtime1.Value.Trim(), systemLogtime2.Value.Trim());
                if (h == 0)
                {
                    WebClientHelper.DoClientMsgBox("此时间段内无清除数据!");
                }
                else
                {
                    if (LogHelperBLL.Deletecdttb_LogBytime(systemLogtime1.Value.Trim(), systemLogtime2.Value.Trim()) > 0)
                    {
                        //写入日志
                        tb_Log log = new tb_Log();
                        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        log.operater = Ims.Main.ImsInfo.CurrentUserId;
                        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        log.type = "删除操作";
                        log.logmsg = log.operater + "删除从时间" + systemLogtime1.Value + "到时间" + systemLogtime2.Value + "的日志记录!";
                        LogHelperBLL.InsertObject(log);

                        WebClientHelper.DoClientMsgBox("清除成功!");
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("清除失败!");
                    }
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("请选择正确的时间段清空!");

            }
        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        if (activet1.Checked == true)
        {
            if (tb_CardActive_HistroyBLL.NocountCardActiveHistroy() == 0)
            { WebClientHelper.DoClientMsgBox("卡历史激活记录已为清空状态!"); }
            else
            {
                if (tb_CardActive_HistroyBLL.deleteAlltb_CardActive_Histroy() > 0)
                {
                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "清除所有的卡历史激活记录!";
                    LogHelperBLL.InsertObject(log);

                    WebClientHelper.DoClientMsgBox("清空成功!");
                }
                else
                {

                    WebClientHelper.DoClientMsgBox("清空失败!");
                }
            }
        }
        if (activet2.Checked == true)
        {
            if (activetime1.Value.Trim() != "" && activetime2.Value.Trim() != "")
            {
                if (tb_CardActive_HistroyBLL.HavecountCardActiveHistroy(activetime1.Value, activetime2.Value) == 0)
                {
                    WebClientHelper.DoClientMsgBox("此时间段内没有可清空记录数据!");
                }
                else
                {
                    if (tb_CardActive_HistroyBLL.deleteAlltb_CardActive_HistroyByTime(activetime1.Value, activetime2.Value) > 0)
                    {
                        //写入日志
                        tb_Log log = new tb_Log();
                        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        log.operater = Ims.Main.ImsInfo.CurrentUserId;
                        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        log.type = "删除操作";
                        log.logmsg = log.operater + "删除从时间" + activetime1.Value + "到时间" + activetime2.Value + "的卡历史激活记录!";
                        LogHelperBLL.InsertObject(log);

                        WebClientHelper.DoClientMsgBox("清除成功!");
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("清空失败!");
                    }

                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("两时间段不能间断!");
            }
        }
    }

    protected void Button4_ServerClick(object sender, EventArgs e)
    {
        //WebClientHelper.DoClientMsgBox("两时间段不能间断!");
        if (TransLog1.Checked == true)
        {
            if (TransLogHelperBLL.NotimeCountTransLog() == 0)
            {
                WebClientHelper.DoClientMsgBox("清除充值记录已处于清空状态!");
            }
            else
            {
                if (TransLogHelperBLL.NotimeDeleteTransLog() > 0)
                {

                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "清除所有的充值记录!";
                    LogHelperBLL.InsertObject(log);


                    WebClientHelper.DoClientMsgBox("清空充值记录成功!");
                }
                else
                {
                    WebClientHelper.DoClientMsgBox("清空充值记录失败!");
                }
            }
        }
        if (TransLog2.Checked == true)
        {
            if (TransLogtime1.Value != "" && TransLogtime2.Value != "")
            {
                if (TransLogHelperBLL.HavetimeCountTransLog1(TransLogtime1.Value.Trim(), TransLogtime2.Value.Trim()) == 0)
                {
                    WebClientHelper.DoClientMsgBox("此时间段充值记录已处于清空状态!");
                }
                else
                {
                    if (TransLogHelperBLL.HavetimeDeleteTransLog(TransLogtime1.Value.Trim(), TransLogtime2.Value.Trim()) > 0)
                    {
                        //写入日志
                        tb_Log log = new tb_Log();
                        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        log.operater = Ims.Main.ImsInfo.CurrentUserId;
                        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        log.type = "删除操作";
                        log.logmsg = log.operater + "删除从时间" + TransLogtime1.Value + "到时间" + TransLogtime2.Value + "的充值记录!";
                        LogHelperBLL.InsertObject(log);


                        WebClientHelper.DoClientMsgBox("清空充值记录成功!");
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("清空充值记录失败!");
                    }
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("两时间段不能间断!");
            }
        }
    }
    protected void Button6_ServerClick(object sender, EventArgs e)
    {
        //WebClientHelper.DoClientMsgBox("两时间段不能间断!");清除未激活卡NotimeCountNoactiveCard
        if (cardNoAvtive1.Checked == true)//清除未激活卡
        {
            if (CardHelperBLL.NotimeCountNoactiveCard() == 0)
            {
                WebClientHelper.DoClientMsgBox("未激活卡数据已处于清空状态!");
            }
            else
            {
                if (CardHelperBLL.NotimeDeleteNoactiveCard() > 0)
                {
                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "清除所有的未激活卡记录!";
                    LogHelperBLL.InsertObject(log);

                    WebClientHelper.DoClientMsgBox("清空成功!");
                }
                else
                {
                    WebClientHelper.DoClientMsgBox("清空失败!");
                }
            }
        }
        if (cardNoAvtive2.Checked == true)
        {
            if (cardNoAvtivetime1.Value != "" && cardNoAvtivetime2.Value != "")
            {
                if (CardHelperBLL.HavetimeCountNoactiveCard(cardNoAvtivetime1.Value, cardNoAvtivetime2.Value) == 0)
                {
                    WebClientHelper.DoClientMsgBox("此时间段未激活卡记录已处于清空状态!");
                }
                else
                {
                    if (CardHelperBLL.HavetimeDeleteNoactiveCard(cardNoAvtivetime1.Value, cardNoAvtivetime2.Value) > 0)
                    {
                        //写入日志
                        tb_Log log = new tb_Log();
                        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        log.operater = Ims.Main.ImsInfo.CurrentUserId;
                        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        log.type = "删除操作";
                        log.logmsg = log.operater + "删除从时间" + cardNoAvtivetime1.Value + "到时间" + cardNoAvtivetime2.Value + "未激活卡记录!";
                        LogHelperBLL.InsertObject(log);
                        WebClientHelper.DoClientMsgBox("清空成功!");
                    }
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("两时间段不能间断!");
            }
        }


    }
    protected void Button7_ServerClick(object sender, EventArgs e)
    {
        int n = 0;
        //WebClientHelper.DoClientMsgBox("两时间段不能间断!");
        if (cardYesAvtive1.Checked == true)
        {
            if (CardHelperBLL.NotimeCountYESactiveCard() == 0)
            {
                WebClientHelper.DoClientMsgBox("没有已激活卡信息可清空!");
            }
            else
            {
                DataTable ta = CardHelperBLL.NotimeGetYESactiveCardID();//获取所有已激活的卡号

                for (int i = 0; i < ta.Rows.Count; i++)
                {
                    if (CardHelperBLL.DeleteCardAndMemBer(ta.Rows[i][0].ToString()))
                    {
                        n++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (n > 0)
                {
                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "清除所有的已激活卡信息!";
                    LogHelperBLL.InsertObject(log);

                    WebClientHelper.DoClientMsgBox("成功删除" + n + "个卡号!");
                }
                else
                {
                    WebClientHelper.DoClientMsgBox("删除失败，请重试!");
                }
            }
        }
        if (cardYesAvtive2.Checked == true)
        {
            if (cardYesAvtivetime1.Value != "" && cardYesAvtivetime2.Value != "")
            {
                if (CardHelperBLL.HavetimeCountYESactiveCard(cardYesAvtivetime1.Value, cardYesAvtivetime2.Value) == 0)
                {
                    WebClientHelper.DoClientMsgBox("此时间段已激活卡已处于清空状态!");
                }
                else
                {
                    DataTable ta2 = CardHelperBLL.HavetimeGetYESactiveCardID(cardYesAvtivetime1.Value, cardYesAvtivetime2.Value);
                    for (int i = 0; i < ta2.Rows.Count; i++)
                    {
                        if (CardHelperBLL.DeleteCardAndMemBer(ta2.Rows[i][0].ToString()))
                        {
                            n++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (n > 0)
                    {
                        //写入日志
                        tb_Log log = new tb_Log();
                        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        log.operater = Ims.Main.ImsInfo.CurrentUserId;
                        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        log.type = "删除操作";
                        log.logmsg = log.operater + "删除从时间" + cardYesAvtivetime1.Value + "到时间" + cardYesAvtivetime2.Value + "未激活卡记录!";
                        LogHelperBLL.InsertObject(log);

                        WebClientHelper.DoClientMsgBox("成功删除!");
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("删除失败，请重试!");
                    }

                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("两时间段不能间断!");
            }
        }
    }
    protected void btnClearChargeList_ServerClick(object sender, EventArgs e)
    {
        bool IsAllData = cb_cardchargelistAll.Checked;
        int ret = CardChargeListBLL.DeleteChargeList(chargelistTime1.Value.Trim(), chargelistTime2.Value.Trim(), IsAllData);
        //写入日志
        if (ret > 0)
        {
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "删除操作";
            log.logmsg = log.operater + "删除从时间" + chargelistTime1.Value + "到时间" + chargelistTime2.Value + "条历史充值记录!";
            LogHelperBLL.InsertObject(log);
        }
        WebClientHelper.DoClientMsgBox("操作完成,共删除"+ret+"条历史充值记录!");
    }
    protected void btnClearChargeStatic_ServerClick(object sender, EventArgs e)
    {
        bool IsAllData = cb_cardchargeStaticAll.Checked;
        int ret = CardChargeListBLL.DeleteChargeList(cardStaticsTime1.Value.Trim(), cardStaticsTime2.Value.Trim(), IsAllData);
        //写入日志
        if (ret > 0)
        {
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "删除操作";
            log.logmsg = log.operater + "删除从时间" + cardStaticsTime1.Value + "到时间" + cardStaticsTime2.Value + "条历史充值[结算]记录!";
            LogHelperBLL.InsertObject(log);
        }
        WebClientHelper.DoClientMsgBox("操作完成,共删除" + ret + "条历史充值[结算]记录!");
    }
    protected void btnReplaceCard_ServerClick(object sender, EventArgs e)
    {
        bool IsAllData = cb_ReplaceCardAll.Checked;
        int ret = Card_RecordBLL.del_ReplaceCardRecord(replaceCardTime1.Value.Trim(), replaceCardTime2.Value.Trim(), IsAllData);
        //写入日志
        if (ret > 0)
        {
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "删除操作";
            log.logmsg = log.operater + "删除从时间" + cardStaticsTime1.Value + "到时间" + cardStaticsTime2.Value + "条历史补卡记录!";
            LogHelperBLL.InsertObject(log);
        }
        WebClientHelper.DoClientMsgBox("操作完成,共删除" + ret + "条历史补卡记录!");
    }
    protected void btnDelPosTrans_ServerClick(object sender, EventArgs e)
    {
        bool IsAllData = cb_ReplaceCardAll.Checked;
        int ret = tb_POS_TransactionBLL.DeletePosTransDetailsHistroy(postransTime1.Value.Trim(), postransTime2.Value.Trim(), IsAllData);
        //写入日志
        if (ret > 0)
        {
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "删除操作";
            log.logmsg = log.operater + "删除从时间" + postransTime1.Value + "到时间" + postransTime2.Value + "条历史删除交易记录!";
            LogHelperBLL.InsertObject(log);
        }
        WebClientHelper.DoClientMsgBox("操作完成,共删除" + ret + "条历史删除交易记录!");
    }
}