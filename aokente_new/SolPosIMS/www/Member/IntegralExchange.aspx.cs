using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web;
using Ims.Card.Model;
using Ims.Member.BLL;
using Ims.Member.Model;
using Ims.Main;
using Ims.Log.Model;

public partial class Member_IntegralExchange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }

    }
    protected void btnRenew_Click(object sender, EventArgs e)
    {
        int point = 0;
        int.TryParse(point_amount.Value.Trim(), out point);
        string card = cardsnr.Value;
        tb_Card o = new tb_Card();
        o = CardHelperBLL.GetObject(card);
        if (o.Status == 0) { WebClientHelper.DoClientMsgBox("此卡未激活!"); return; }
        if (o.Status == 2) { WebClientHelper.DoClientMsgBox("此卡已挂失!"); return; }
        if (o.Status == 3) { WebClientHelper.DoClientMsgBox("此卡已补卡停用!"); return; }
        if (o.Status == 0) { WebClientHelper.DoClientMsgBox("此卡已注销!"); return; }
        if (point > o.Points|| o.Points == 0) { WebClientHelper.DoClientMsgBox("余额不足!当前:" + o.Points.ToString()); return; }

            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            string rtnmsg = "";

            if (card_integralexchangeBLL.IntegralExchangeByCard(card, point) > 0)//扣减成功
            {
                card_integralexchangelist ciel = new card_integralexchangelist();
                ciel.transid = DateTime.Now.ToString("yyMMddHHmmss");
                ciel.card = card;
                ciel.old_point = o.Points;
                ciel.point = point;
                o = CardHelperBLL.GetObject(card);//再次查询积分余额
                ciel.new_point = o.Points;
                ciel.memo = memo.Value.Trim();
                ciel.operatorid = ImsInfo.CurrentUserId;
                ciel.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //写入操作日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddHHmmss");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.type = "补卡操作";
                log.logmsg = "对会员卡号为:" + card + "进行积分兑换操作.本次发生金额:" + point + "当前账户积分:" + o.Points.ToString();

                card_integralexchangeBLL.IntegralExchange_insert(ciel, log);
                rtnmsg = "兑换成功!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + rtnmsg + "');</script>");
                    return;
                }
            }

    }

}

