using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using Ims.Card.Model;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web;

public partial class Card_CardBathchAdjust : System.Web.UI.Page
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

            InitListControlHelper.BindNormalTableToListControl(TypeID_Target, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");

            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
        }
    }
    protected void bt_Batch_ServerClick(object sender, EventArgs e)
    {
        long s_num = long.Parse(StartNum.Value.Trim());
        long e_num = long.Parse(EndNum.Value.Trim());
        int ret = BatchActive(s_num, e_num);
        //WebClientHelper.DoClientMsgBox(ret.ToString() +"张卡已激活!");
        string msg = ret.ToString() + "张卡已成功转换!";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }
    }
    /// <summary>
    /// 批量卡类型转换方法
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
            string o_type = TypeID.Value;//原始类型
            string t_type = TypeID_Target.Value;//新类型
            string actard = AddZeroBeforeCardNum(StartNum.Value.Trim(), cardnum);
            string cus_num = "";
            cus_num = actard;
            if (Checkbox6.Checked)
                cus_num = CardPre + cus_num;
            tb_Card card = CardHelperBLL.GetObject_BatchCardRegistion(cus_num);
            if (card == null) continue;//卡不存在
            if (card.Status == 2 || card.Status == 3 || card.Status == 4) continue;//卡状态为正常使用或者未激活

            tb_Card o_source = new tb_Card();
            o_source = CardHelperBLL.GetObject_AllCard(cus_num, o_type);//根据卡号和卡类型获取原有卡类型对象
            tb_Card o_destination = new tb_Card();
            o_destination = o_source;
            o_destination.TypeID = t_type;//复制新类型给目标对象

            if (CardHelperBLL.updateCardTypeByCardNumAndTypeid(cus_num, o_type, t_type) > 0)
            {
                batch_actinve_count++;

                tb_TurnTypeRecord ttr = new tb_TurnTypeRecord();
                ttr.TID = DateTime.Now.ToString("yyMMddHHmmssfff");
                ttr.CardID = cus_num;

                ttr.OTypeID = o_type;
                ttr.NTypeID = t_type;
                ttr.TMan = Ims.Main.ImsInfo.CurrentUserId;
                ttr.AddDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ttr.Flag = true;
                tb_TurnTypeRecordBLL.InsertObject(ttr);
                Thread.Sleep(20);
            }
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
