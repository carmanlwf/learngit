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
using Ims.Card.Model;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Log.Model;

public partial class Card_CardBuKa : FormNormalEditPage
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
            /// 卡状态（0：未激活 1：正常 2：挂失 3：销卡 4:补卡）
            string msg = "";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if ((int)o.Status == 0)
            {
                msg = "卡未激活，请先激活后再进行补卡操作...";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    return;
                }
            }
            if ((int)o.Status == 4)
            {
                msg = "此卡已处于补卡状态...不能再次补卡...";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    return;
                }
            }



            OldCardId.Value = Request.QueryString["getcode"].ToString();
            Balance.Value = Convert.ToString(o .Balance);
            UserName.Value = o.RealName;

            //ViewState["oCard"] = o;
            //ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
            //ControlHelper.SetControlsReadonly(true, "NewCard,Pass");

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (OldCardId.Value.Trim() == NewCardId.Value.Trim() || NewCardId.Value.Trim() == "")
        {
            WebClientHelper.DoClientMsgBox("请输入新的卡号!");
            return;
        }
        tb_Card card1 = new tb_Card();
        card1 = CardHelperBLL.GetObject_objec(OldCardId.Value.Trim());
        //if (card1.pass != WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, Password.Value.Trim(), WebHelper.tradepassword_salt))
        //{
        //    WebClientHelper.DoClientMsgBox("旧卡密码验证错误!请重新输入!");
        //    return;
        //}
        tb_Card card2 = new tb_Card();
        card2 = CardHelperBLL.GetObject_objec(NewCardId.Value.Trim());
        if (card2==null)
        {
            WebClientHelper.DoClientMsgBox(NewCardId.Value.Trim() + "系统中不存在此卡号信息！请重新输入！");
            NewCardId.Value = "";
            return;
        }
        if ((int)card2.Status !=0)
        {
            WebClientHelper.DoClientMsgBox(NewCardId.Value.Trim() + "此卡正在使用状态，请输入其它新卡号!");
            NewCardId.Value = "";
            return;
        }
        else
        {
             //同时更新两个卡的信息
             //原卡----卡1
              tb_Card card11 = new tb_Card();
              card11.card = OldCardId.Value.Trim();
              card11.Balance = 0;
              //card11.Userid ="";
              card11.regionid = "";
              card11.Status = 4;
              ////card11.pass = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
              ////card11.tradepassword = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
              card11.validDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
              card11.activitystatus = 0;
              card11.memo = "已挂失!不能再用!";
            //新卡-----卡2
              tb_Card card22 = new tb_Card();
              card22.card = NewCardId.Value.Trim();
              card22.Userid = card1.Userid;
              card22.Balance = card2.initvalue + card1.Balance;
              card22.Status =1;
              card22.tradepassword = card1.tradepassword;
              card22.pass = card1.pass;
              card22.activitystatus = 1;//永久激活
              card22.validDate = card1.validDate;
              card22 .memo ="补卡发卡操作,原卡是"+OldCardId .Value .Trim();
              card22.regionid = card1.regionid;
              //card22.activitytime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

              //终端激活
              tb_CardActivityByShop cActive = new tb_CardActivityByShop();
              cActive.card = card22.card;
              cActive.siteid = card1.regionid;//设置卡区域
              //cActive.activitydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
              cActive.activityway = "在线";//设定激活方式
              cActive.status = 2;//2为正常状态，不同于card表的状态
              cActive.memo = "由于对用户" + card1.Userid + "补卡操作,并且在线对其进行激活!";
              cActive.operatorid = Ims.Main.ImsInfo.CurrentUserId;
              cActive.activitydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //写入操作日志
              tb_Log log = new tb_Log();
              log.logid = DateTime.Now.ToString("yyyyMMddHHmmss");
              log.operater = Ims.Main.ImsInfo.CurrentUserId;
              log.type = "补卡操作";
              log.logmsg = "对会员编号为:" + card1.Userid + "进行补卡,新卡卡号是:" + NewCardId.Value.Trim() + ",卡内原有余额是：￥" + card1.initvalue + ",旧卡卡号是:" + OldCardId.Value.Trim() + ",并把旧卡上的金额数：￥" + card1.Balance + "全转到新卡上!";

              //在Card_Record表中添加一条补卡记录
              Card_Record cardrecord = new Card_Record();
              cardrecord.Oldcardid = OldCardId.Value.Trim();
              cardrecord.Username = UserName.Value.ToString();
              cardrecord.Balance = card1.balance.ToString();
              cardrecord.NewCardId = NewCardId.Value.ToString();
              cardrecord.cardTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
              cardrecord.Password = Password.Value;
              cardrecord.flag = true;
             

              if (TransHelperBLL.MemberBuKa(card11, card22, cardrecord,cActive, log) == true)
              {                 
                  WebClientHelper.DoClientMsgBox("补卡成功，旧卡金额已全部转移到新卡上，新卡现在可以使用!");
              }
              else
              {
                  WebClientHelper.DoClientMsgBox("补卡失败!请重试!");
              }
        }

    }

}
