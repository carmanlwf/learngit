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
using Ims.Card.Model;
using Ims.Log.Model;
using Ims.Card.BLL;
using Ims.Main;

public partial class CardHold_CardDelay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }

    }
    protected void btnCardDelay_Click(object sender, EventArgs e)
    {
        tb_Card o = new tb_Card();
        o.card = cardsnr.Value;
        o.validDate = delaytime.Value + " 23:59:59";

        tb_Log tlog = new tb_Log();
        tlog.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
        tlog.type = "卡片延长";
        tlog.operater = ImsInfo.CurrentUserId;
        tlog.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        tlog.logmsg = "对卡号为:" + cardsnr.Value + "的会员卡执行【卡片延长】操作，延长时间到:" + o.validDate+"备注:" + memo.Value.Trim();
        tlog.flag = true;

        if (CardHelperBLL.AddCardTime(o, tlog))
        {
            string msg = "会员卡" + o.card + "卡片延长期限成功!";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("操作失败,请重试!");
        }
    }
}

