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
using Ims.Member.Model;
using Ims.Member.BLL;
using Ims.Card.BLL;
using Ims.Log.Model;


public partial class Member_MemberAddCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            //InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site");
        }
        string userid = Request.QueryString["getcode"].ToString();
        tb_Member m = new tb_Member();
        m = MemberHelperBLL.GetObject(userid);
        Labnum.Text = userid;
        LabName.Text = m.RealName;
        LabRead.Text = m.RankName;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Card.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("请输入要绑定的卡号!");
            return;
        }
        else
        {
            string c = Card.Value.Trim();
            tb_Card card1 = new tb_Card();
            card1 = CardHelperBLL.GetObject_objec(c);
            if (card1 == null)
            {
                WebClientHelper.DoClientMsgBox("此卡未在系统中注册,请确认后再进行用户绑定!");
                return;
            }
            else
            {
                if ((int)card1.Status == 1 && card1.Userid != null && card1.activitystatus == 1)// 永久有效的卡
                {
                    WebClientHelper.DoClientMsgBox("此卡正使用中,请更换后重试!");
                    return;
                }
                else if ((int)card1.Status == 1 && card1.Userid != null && card1.activitystatus == 0)// 临时有效的卡
                {
                    WebClientHelper.DoClientMsgBox("此卡正使用中,请更换后重试!");
                    return;
                }
                else
                {
                    //操作日志记录
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddHHmmss");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    log.type = "卡片绑定";
                    log.logmsg = "对会员编号为:" + Request.QueryString["getcode"].ToString() + "与卡号为:" + c + "进行绑定!";

                    //终端激活
                    tb_CardActivityByShop cActive = new tb_CardActivityByShop();
                    cActive.card = c;
                    //cActive.siteid = Site_Code.Value;
                    cActive.siteid = Request.Form.Get("Site_Code");//设置卡区域
                    cActive.activitydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cActive.activityway = "在线";//设定激活方式
                    cActive.status = 2;//2为正常状态，不同于卡的状态
                    cActive.memo = "在线激活";
                    cActive.operatorid = Ims.Main.ImsInfo.CurrentUserId;

                    //更新卡片信息
                    tb_Card card2 = new tb_Card();
                    card2.card = c;
                    card2.validDate = validDate.Value;
                    card2.Status = 1;//正常使用
                    card2.Userid = Request.QueryString["getcode"].ToString();
                    card2.regionid = Request.Form.Get("Site_Code");
                    card2.activitystatus = 1;//设置激活状态为永久激活
                    if (TransHelperBLL.SendCard(card2, log, cActive))
                    {
                        WebClientHelper.DoClientMsgBox("绑定成功!");
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("绑定失败,请重试!");
                    }
                }
            }
        }

    }
    //public bool CheckCardValid()
    //{
    //    //空闲卡操作
    //        if (string.IsNullOrEmpty(Card.Value))
    //        {
    //            WebClientHelper.DoClientMsgBox("卡号不能为空!!");
    //            return false;
    //        }
    //        else
    //        {
    //            tb_Card o = CardHelperBLL.GetObject_objec(Card.Value.Trim());
    //            if (o != null)
    //            {
    //                string C_Status = ((int)o.Status).ToString();

    //                if (C_Status != "0")
    //                {
    //                    WebClientHelper.DoClientMsgBox("此卡已被使用!请重新选择空闲卡进行绑定!");
    //                    return false;
    //                }
    //                else
    //                {
    //                    return true;
    //                }

    //            }
    //            else
    //            {
    //                WebClientHelper.DoClientMsgBox("卡号未注册!");
    //                return false;
    //            }
    //        }
    //}

}
