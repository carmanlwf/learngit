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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.BLL;

public partial class Card_CardXiaoKa : System.Web.UI.Page
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
            //ViewState["oCard"] = o;
            //ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
            //ControlHelper.SetControlsReadonly(Page, true, "", true);
            //ControlHelper.SetControlsReadonly(true, "Card,RealName,IdTypeName");
            Card.Value = o.card;
            RealName.Value = o.RealName;

            ControlHelper.SetControlReadonly(Card, true);
            ControlHelper.SetControlReadonly(RealName, true);
            if (o.Status == 0)
            {
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                msg = "已未激活的卡不能进行销卡操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }
            if (o.Status == 3)//销卡状态
            {
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                msg = "已注销的卡不能进行销卡操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }
            if (o.Status == 4) 
            {
                string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                msg = "已补替补的卡不能进行销卡操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //tb_Card o = (tb_Card)ViewState["oCard"];

        tb_Card o = new tb_Card();
        o = CardHelperBLL.GetObject_CardAndMember(Card.Value.Trim());


        string mypass = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, Pass.Value, o.tradepasswordsalt);
        if (o.Status == 3)
        {
            WebClientHelper.DoClientMsgBox("此卡已注销,无须重复操作!");
        }
        else
        {
            if (o.tradepassword != mypass)
            {
                WebClientHelper.DoClientMsgBox("密码验证失败,请重新输入!");
                return;
            }
            else
            {
                if (o.CellPhone != Idno1.Value)
                {
                    WebClientHelper.DoClientMsgBox("证件号码验证失败,请重新输入!");
                    return;
                }
                else
                {
                    if (CardHelperBLL.Card_XiaoKa(o.card) > 0)
                    {
                        string msg = "会员卡" + o.card + "销卡成功!";
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
        }
    }
}
