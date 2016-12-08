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
using Ims.Member.Model;
using Ims.Member.BLL;
using ZsdDotNetLibrary.Web;
using Ims.Card.Model;
using Ims.Log.Model;
using Ims.Main;

public partial class Card_CardActive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            //InitListControlHelper.BindNormalTableToListControl(UserRank, "id", "Name", "tb_MemberRanks");

            ViewState["type"] = Request.QueryString["type"];
            Card.Value = Request.QueryString["getcode"].ToString();
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            if (ViewState["type"].ToString() == "activenoinfo")//新增卡、会员及激活信息
            {
                ControlHelper.SetControlsReadonly(true, "Site_Code,Area_Code,RealName,gender,IdType,IdNo,CellPhone,UserRankm,Address");
            }
            else if (ViewState["type"].ToString() == "activehasinfo")
            {
                ControlHelper.SetControlsReadonly(true, "Site_Code,Area_Code,RealName,gender,IdType,IdNo,CellPhone,UserRank,Address");
                Site_Code.Disabled = true;
                Area_Code.Disabled = true;
            }
            tb_Card o = new tb_Card();
            //-----------------------------------2011-10-20-----------------------------------
            o = CardHelperBLL.GetObject_objec(Card.Value.Trim());
            if ((int)o.activitystatus == 0||(int)o.activitystatus==2)//待激活和临时激活
            {
          
            }
            //-----------------------------------2011-10-20-----------------------------------
            else
            {
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                msg = "此卡已在使用中,无须再次激活!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if(ViewState["type"]==null){return;}
        //string uid = CardHelperBLL.Card_GetUseridByCard(Card.Value.Trim());
        tb_Card card = CardHelperBLL.GetObject_BatchCardRegistion(Card.Value.Trim());
        //tb_CardActivityByShop active = CardHelperBLL.GetActiveObject(Card.Value.Trim());
        if (card ==null)
        {
            WebClientHelper.DoClientMsgBox("此卡无任何操作");
            return;
        }
        //if (MemberHelperBLL.MemberCardByIdNober(IdNo.Value.Trim()) > 0)
        //{
        //    WebClientHelper.DoClientMsgBox("此身份证号码在本系统中已存在!不能重复输入");
        //    return;
        //}
        if (card != null)
        {
            if (card.Status == 1 && card.activitystatus == 1)//卡状态为正常使用，激活状态为完全激活（临时激活卡在有效期内卡状态为1，激活状态为0,临时激活:2）卡激活状态:0待激活 1已永久激活 2临时激活
            {
                WebClientHelper.DoClientMsgBox("此卡已为激活状态，无须重复操作!");
                return;
            }
            else
            {
         
                if (ViewState["type"].ToString() == "activenoinfo")//新增卡、会员及激活信息
                {
                    UserInfo u1 = new UserInfo();
                    //u = MemberHelperBLL.GetObject(uid);

                    u1.CellPhone = CellPhone.Value;
                    u1.IdType = IdType.Value;
                    u1.RealName = RealName.Value;
                    u1.Gender = gender.Value;
                    u1.IdNo = IdNo.Value;
                    u1.flag = true ;
                    u1.Address = Address.Value;
                    //u1.UserRank = UserRank.Value;
                    //u1.Regionid = Site_Code.Value;

                    tb_Log tlog1 = new tb_Log();
                    tlog1.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    tlog1.type = "卡片激活";
                    tlog1.operater = ImsInfo.CurrentUserId;
                    tlog1.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tlog1.logmsg = "对卡号为:" + Card.Value + "的会员卡执行【激活】操作。";
                    //tlog1.flag = true;

                    //tb_Card cc = CardHelperBLL.GetObject(Card.Value.Trim());

                    tb_card_active c1 = new tb_card_active();
                    c1.card = Card.Value.Trim();
                    c1.Status = 1;//设置卡状态为正常0->1;
                    c1.activitystatus = 1;//设置激活状态为永久激活
                    //c1.activitytime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //c1.activitystatus = "1";
                     
                    u1.Userid = "M-" + DateTime.Now.ToString("yyyyMMddhhmmss");
                    
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
                    h.Memo = "系统自动批量生成的不记名卡用户";
                    h.flag = true;

                    if (MemberHelperBLL.ActiveCardForUser(u1, c1, tlog1, active1,h ))
                    {
                        string msg = "激活成功!";
                        ClientScriptManager cs = Page.ClientScript;
                        Type cstype = this.GetType();
                        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                        {
                            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                        }
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("激活操作失败,请重试!");
                    }
                }
                else if (ViewState["type"].ToString() == "activehasinfo")//更新会员及激活信息
                {
                    UserInfo u2 = new UserInfo();
                    //u = MemberHelperBLL.GetObject(uid);

                    u2.CellPhone = CellPhone.Value;
                    u2.IdType = IdType.Value;
                    u2.RealName = RealName.Value;
                    u2.Gender = gender.Value;
                    u2.IdNo = IdNo.Value;
                    //u2.Regionid = Site_Code.Value;

                    tb_Log tlog2 = new tb_Log();
                    tlog2.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    tlog2.type = "卡片激活";
                    tlog2.operater = ImsInfo.CurrentUserId;
                    tlog2.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tlog2.logmsg = "对卡号为:" + Card.Value + "的会员卡执行【激活】操作。";
                    tlog2.flag = true;

                    string uid = CardHelperBLL.Card_GetUseridByCard(Card.Value.Trim());
                    //tb_Card c2 = CardHelperBLL.GetObject(Card.Value.Trim());
                    tb_card_active c2 = new tb_card_active();
                    c2.card = Card.Value.Trim();
                    u2.Userid = uid;
                    c2.Userid = uid;
                    c2.Status = 1;//将卡设置为正常使用状态
                    c2.activitystatus = 1;//设置激活状态为永久激活 0：未激活 1：已永久激活 2:临时激活

                    tb_CardActivityByShop active2 = CardHelperBLL.GetActiveObject(c2.card);
                    active2.card = c2.card;
                    active2.status = 2;//使用中
                    active2.activitydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    active2.operatorid = ImsInfo.CurrentUserId;
                    active2.activityway = "终端";
                    c2.regionid = active2.siteid;//设置卡区域(此时为终端激活分店的编号，无须选择)
                    if (!string.IsNullOrEmpty(uid))
                    {
                        if (MemberHelperBLL.ActiveCardForUser_Supplement(u2, c2, tlog2, active2))
                        {
                            string msg = "补充激活成功!";
                            ClientScriptManager cs = Page.ClientScript;
                            Type cstype = this.GetType();
                            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                            {
                                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                            }
                        }
                        else
                        {
                            WebClientHelper.DoClientMsgBox("补充激活操作失败,请重试!");
                        }
                    }
                    else
                    {
                        WebClientHelper.DoClientMsgBox("未检索到此卡对应的会员初始信息,请确认用户是否了激活操作!");
                    }
                }

            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("该卡不存在,请重新操作!");
        }
    }
}
