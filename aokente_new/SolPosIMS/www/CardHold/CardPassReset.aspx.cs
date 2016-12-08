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
using NewSoftDotNetLibrary.Web;
using Ims.Card.BLL;
using Ims.Log.Model;
using Ims.Card.Model;

public partial class CardHold_CardPassReset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
//权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }

    //public bool isnumber(string s)
    //{
    //    string pattern = "^[0-9]*$";
    //    Regex rx = new Regex(pattern);
    //    return rx.IsMatch(s);
    //}

    protected void btnResetPass_Click(object sender, EventArgs e)
    {
        string card = cardsnr.Value;
        tb_Card c = new tb_Card();
        c = CardHelperBLL.GetObject(card);
        if ((int)c.Status != 1)//正常使用状态
        {
            string msg = "卡状态异常,不能设置密码!";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            }
        }

        tb_Card o = new tb_Card();
        o.card = cardsnr.Value;
        o.tradepassword = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, "000000", WebHelper.tradepassword_salt);
        o.pass = o.tradepassword;


        tb_Log log = new tb_Log();
        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
        log.operater = Ims.Main.ImsInfo.CurrentUserId;
        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        log.type = "密码重设";
        if (memo.Value.Trim() == "")
        {
            log.logmsg = log.operater + "对卡号为:" + o.card + "进行" + "密码重设,重设后密码为000000!";
            //if (Checkbox1.Checked)
            //{ log.logmsg = log.operater + "对卡号为:" + o.card + "进行" + "密码重设,重设后密码为卡后6位!"; }
            //else
            //{ log.logmsg = log.operater + "对卡号为:" + o.card + "进行" + "密码重设重设后密码为卡后6个0"; }

        }
        else
        {
            log.logmsg = log.operater + "对卡号为:" + o.card + "进行" + "密码重设,重设后密码为000000!备注:" + memo.Value.Trim();
        }
        if (CardHelperBLL.ChangeUserCardPass(o, log))
        {
            string rtnmsg = "密码重设成功!";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + rtnmsg + "');</script>");

            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("操作失败,请重试!");
        }

    }
}

