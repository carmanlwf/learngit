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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Member.BLL;
using Ims.Card.BLL;
using System.Collections.Generic;
using Ims.Log.Model;
using Ims.PM.BLL;

public partial class Member_MemberSendCard : System.Web.UI.Page
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
            //InitListControlHelper.BindNormalTableToListControl(UserRank, "id", "Name", "tb_MemberRanks");
            Userid.Value = "M" + DateTime.Now.ToString("yyMMddHHmmssfff");
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                this.TABLE1.Rows[2].Style.Add("display ", "none ");
            }

        }
       
        if(Request.QueryString["id"] != null)
        {
            Card.Value = Request.QueryString["id"].ToString();
            Card.Disabled = true;
        }


    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        tb_Member member = MemberHelperBLL.GetObject(Userid.Value);
        if (member != null)
        {
            WebClientHelper.DoClientMsgBox("该用户编号已存在!");
            Userid.Value = "M" + DateTime.Now.ToString("yyMMddHHmmssfff");
        }
        else
        {
            tb_Card c = new tb_Card();
            //更新卡信息
            c.card = Card.Value.Trim();
            c.Userid = Userid.Value.Trim();
            c.activitystatus = 1;//永久激活
            c.Status = 1;
            //c.validDate = Validdate.Value.Trim();
            c.memo = memo.Value.Trim();
            tb_Member m = new tb_Member();
            //写入会员信息
            m.Userid = c.Userid;
            m.RealName = RealName.Value.Trim();
            m.Address = Address.Value.Trim();
            m.Zipcode = Zipcode.Value.Trim();
            m.QQ = QQ.Value.Trim();
            m.email = email.Value.Trim();
            m.TelPhone = Telphone.Value.Trim();
            m.CellPhone = CellPhone.Value.Trim();
            m.IdType = IdType.Value;
            m.IdNo = IdNo.Value.Trim();
            m.UserRank = "无级";
            m.BirthDate = birthdate.Value.Trim();
            m.Gender = int.Parse(gender.Value.Trim());
            m.Memo = memo.Value.Trim();
            m.MSN = "";
            m.addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            m.flag = true;
            m.Expenditure = 0;
            m.Regionid = c.regionid;
            m.isSysAuto = false;
            m.Points = 0;
            //m.IsSms = cbIsSms.Checked;


            tb_CardActivityByShop s = new tb_CardActivityByShop();
            //写入激活卡表信息
            s.card = c.card;
            s.siteid = c.regionid;
            s.activitydate = m.addeddate;
            s.activityway = "在线";
            s.status = 2;
            s.operatorid = Ims.Main.ImsInfo.CurrentUserId;
            s.memo = s.operatorid + "为用户编号为:" + m.Userid + ",名称为:" + m.RealName + "发卡," + "所在门店编号是:" + c.regionid;



            //卡激活记录
            tb_CardActive_Histroy h = new tb_CardActive_Histroy();
            h.Contno = DateTime.Now.ToString("yyyyMMddHHmmss");
            h.Card = c.card;
            h.Activeway = "在线";
            h.Activeoperator = s.operatorid;
            h.activetime = m.addeddate;
            h.Memo = s.memo;
            h.flag = true;

            if (MemberHelperBLL.SendCardHaveCardNoMen(c, m, s, h) == true)
            {
                string msg = "添加数据成功！";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }

                //Userid.Value = "M" + DateTime.Now.ToString("yyMMddHHmmssfff");
                //Card.Value = "";
                //RealName.Value = "";
                //CellPhone.Value = "";
                //Telphone.Value = "";
                //QQ.Value = "";
                //email.Value = "";
                //birthdate.Value = "";
                //IdNo.Value = "";
                //Address.Value = "";
                //Zipcode.Value = "";
                //memo.Value = "";
                //Card.Focus();
            }
            else
            {
                WebClientHelper.DoClientMsgBox("发卡失败!");
            }
        }
    }
}
