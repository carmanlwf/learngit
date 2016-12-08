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
using Ims.Member.BLL;
using Ims.Member.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Log.Model;
using Ims.Card.Model;
using Ims.Card.BLL;
using System.Text.RegularExpressions;

public partial class Member_MemberSetPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            //this.TABLE1.Rows[5].Style.Add("display ", "none ");
            //-----------------------------------------------------------
            //tb_Member o = new tb_Member();
            //string uid = Request.QueryString["getcode"].ToString();
            //o = MemberHelperBLL.GetObject(uid);
            ////ViewState["oMember"] = o;
            //ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
            //ControlHelper.SetControlsReadonly(true, "pass1,pass2,Memo1");
            //-------------修改部分-----------------------------
            string card = Request.QueryString["getcode"].ToString();
            tb_Card c = new tb_Card();
            c = CardHelperBLL.GetObject(card);
            if ((int)c.Status != 1)//正常使用状态
            {
                string msg = "此卡尚未启用,不能设置密码!";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }
            else
            {
                Label1.Text = c.Userid;
                Label2.Text = c.RealName;
                Label3.Text = card;
            }

            //if (Convert.ToInt32(lastisnumber(card)) < 7)
            //{
            //    //Checkbox1.Visible = false;
            //    //Label4.Visible = false;
            //    //Checkbox2.Checked = true;
            //    //Checkbox2.Disabled = true;
            //    //WebClientHelper.DoClientMsgBox("后面数字不够6位");
            //}
            //else
            //{
            //    //Checkbox1.Checked = true;
            //    //WebClientHelper.DoClientMsgBox("后面数字多于6位");
            //}

        }
    }

    public bool isnumber(string s)
    {
        string pattern = "^[0-9]*$";
        Regex rx = new Regex(pattern);
        return rx.IsMatch(s);
    }

    public string lastisnumber(string cardid)//卡后面走第几位是字母
    {
        int t = 0;
        char[] chars = cardid.ToCharArray();
        for (int i = 0; i <= cardid.Length - 1; i++)
        {
            if (isnumber(chars[cardid.Length - 1 - i].ToString()))
            {
                continue;
            }
            else
            {
                t = i;
                break;
            }
        }
        return t.ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (newpass.Value != password1.Value)
        {
            WebClientHelper.DoClientMsgBox("两次输入的密码不一致");
            return;
        }
        //string password = "";
        tb_Card o = new tb_Card();
        o.card = Request.QueryString["getcode"].ToString();
        //if (Checkbox1.Checked)
        //{
        //    password = o.card.Substring(o .card.Length -6);//卡后6位
        //}
        //else
        //{
        //    password ="000000";
        //}
        o.tradepassword = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, password1.Value, WebHelper.tradepassword_salt);
        o.pass = o.tradepassword;


        tb_Log log = new tb_Log();
        log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
        log.operater = Ims.Main.ImsInfo.CurrentUserId;
        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        log.type = "密码重设";
        if (Memo1.Value.Trim() == "")
        {
            log.logmsg = log.operater + "对卡号为:" + o.card + "进行" + "密码重设,重设后密码为" + password1.Value + "!";
            //if (Checkbox1.Checked)
            //{ log.logmsg = log.operater + "对卡号为:" + o.card + "进行" + "密码重设,重设后密码为卡后6位!"; }
            //else
            //{ log.logmsg = log.operater + "对卡号为:" + o.card + "进行" + "密码重设重设后密码为卡后6个0"; }

        }
        else
        {
            log.logmsg = Memo1.Value;
        }
        if (CardHelperBLL.ChangeUserCardPass(o, log))
        {
            string msg = "密码重设成功!";
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
