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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;
using Ims.Card.BLL;
using Ims.Main;
using Ims.Member.BLL;
using Ims.Member.Model;
using Ims.Log.Model;
using System.Threading;

public partial class Card_CardBatchActive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {

            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");

            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
        }
    }
    protected void bt_Batch_ServerClick(object sender, EventArgs e)
    {
        long s_num = long.Parse(StartNum.Value.Trim());
        long e_num = long.Parse(EndNum.Value.Trim());
        int ret = BatchActive(s_num, e_num);
        //WebClientHelper.DoClientMsgBox(ret.ToString() +"张卡已激活!");
        string msg = ret.ToString() + "张卡已激活!";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
    }
    /// <summary>
    /// 批量激活卡方法
    /// </summary>
    /// <param name="cardNum"></param>
    /// <param name="start_num"></param>
    /// <param name="end_num"></param>
    /// <returns></returns>
    public int BatchActive(long start_num, long end_num)
    {
        int batch_actinve_count = 0;
        for (long cardnum = start_num; cardnum < end_num; cardnum++)
        {
            string actard = AddZeroBeforeCardNum(StartNum.Value.Trim(), cardnum);
            string cus_num = "";
            cus_num = actard;
            if (Checkbox6.Checked)
                cus_num = CardPre + cus_num;
            tb_Card card = CardHelperBLL.GetObject_BatchCardRegistion(cus_num);
            if (card == null) continue;//卡不存在
            if (card.Status == 1 && card.activitystatus == 1) continue;//卡状态为正常使用，激活状态为完全激活（临时激活卡在有效期内卡状态为1，激活状态为0,临时激活:2）卡激活状态:0待激活 1已永久激活 2临时激活
            UserInfo u1 = new UserInfo();
            u1.CellPhone = "";
            u1.IdType = "";
            u1.RealName = "无名单";
            u1.Gender = "0";
            u1.IdNo = "";
            u1.flag = true;
            u1.Address = "无";
            tb_Log tlog1 = new tb_Log();
            tlog1.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            tlog1.type = "卡片激活";
            tlog1.operater = ImsInfo.CurrentUserId;
            tlog1.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tlog1.logmsg = "对卡号为:" + cus_num + "的会员卡执行【激活】操作。";
            tb_card_active c1 = new tb_card_active();
            c1.card = cus_num;
            c1.Status = 1;//设置卡状态为正常0->1;
            c1.activitystatus = 1;//设置激活状态为永久激活
            //c1.activitytime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //c1.activitystatus = "1";
            u1.Userid = "U" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            c1.regionid = Request.Form.Get("Site_Code");//设置卡区域
            c1.Userid = u1.Userid;

            tb_CardActivityByShop active1 = new tb_CardActivityByShop();
            active1.card = c1.card;
            active1.status = 2;//使用中
            active1.activitydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            active1.operatorid = ImsInfo.CurrentUserId;
            active1.siteid = c1.regionid;
            active1.activityway = "在线";

            tb_CardActive_Histroy h = new tb_CardActive_Histroy();
            h.Contno = DateTime.Now.ToString("yMdHHmmss");
            h.Card = c1.card;
            h.Activeway = "在线";
            h.Activeoperator = tlog1.operater;
            h.activetime = tlog1.operate_date;
            h.Memo = "批量激活生成的不记名卡用户";
            h.flag = true;
            if (MemberHelperBLL.ActiveCardForUser(u1, c1, tlog1, active1, h))
            {
                batch_actinve_count += 1;
            }
            Thread.Sleep(20);
        }
        return batch_actinve_count;

    }
    /// <summary>
    /// 对卡号前缀有0的卡进行补0操作
    /// </summary>
    /// <param name="oldnum"></param>
    /// <param name="nownum"></param>
    /// <returns></returns>
    public string AddZeroBeforeCardNum(string oldnum, long nownum)
    {
        //001999
        string actual_num = nownum.ToString();
        int len_old = oldnum.Length;//原来卡号(string)的长度
        int len_new = nownum.ToString().Length;//转换后的长度
        int len_plus = len_old - len_new;//减掉的0
        if (len_plus >= 0)
        {
            for (int i = 0; i < len_plus; i++)
            {
                actual_num = "0" + actual_num;
            }
        }
        return actual_num;
    }
}
