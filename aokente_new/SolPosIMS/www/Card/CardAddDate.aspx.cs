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
using Ims.Card.BLL;
using Ims.Card.Model;
using Ims.Log.Model;
using Ims.Main;

public partial class Card_CardAddDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            InitListControlHelper.InitListControls(typeof(tb_Card));
            tb_Card o = new tb_Card();
            string card = Request.QueryString["getcode"].ToString();
            o = CardHelperBLL.GetObject(card);
            Card.Value = o.card;
            RealName.Value = o.RealName;

            ControlHelper.SetControlReadonly(Card, true);
            ControlHelper.SetControlReadonly(RealName, true);
            if (o.Status !=1)
            {
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                msg = "非正常状态下的卡不能进行延长期限操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }
                  }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tb_Card o = new tb_Card();
        o.card = Card.Value;
        o.validDate = adddate.Value + " 23:59:59";

            tb_Log tlog = new tb_Log();
            tlog.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            tlog.type = "卡片延长";
            tlog.operater = ImsInfo.CurrentUserId;
            tlog.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tlog.logmsg = "对卡号为:" + Card.Value + "的会员卡执行【卡片延长】操作，延长时间到:" + o.validDate;
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
