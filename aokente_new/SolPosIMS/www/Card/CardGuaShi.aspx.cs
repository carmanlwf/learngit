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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;
using Ims.Card.BLL;

public partial class Card_CardGuaShi : System.Web.UI.Page
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
            string card = Request.QueryString["getcode"].ToString();
            tb_Card o = new tb_Card();
            o = CardHelperBLL.GetObject(card);
            ViewState["flag"] = o.Status;
            ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
            ControlHelper.SetControlReadonly(Card, true);
            ControlHelper.SetControlReadonly(RealName, true);
            string msg = "";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();



            if ((int)o.Status == 0)
            {
                msg = "卡未激活，请先激活后再进行挂失...";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    return;
                }
            }
            if ((int)o.Status == 2)
            {
                msg = "卡已处于挂失状态,不能进行此项操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    return;
                }
            }
            if ((int)o.Status == 3)
            {
                msg = "卡已处于注销状态,不能进行此项操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    return;
                }
            }
            if ((int)o.Status == 4)
            {
                msg = "卡已处于补卡状态,不能进行此项操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                    return;
                }
            }
            //switch ((int)o.Status)
            //{
            //    case 3:
            //        msg = "卡已处于注销状态,不能进行此项操作!";
            //        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            //        {
            //            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            //        }
            //        break;
            //    case 2:
            //        msg = "卡已处于挂失状态,不能进行此项操作!";
            //        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            //        {
            //            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            //        }
            //        break;
            //    case 4:
            //        msg = "卡已处于补卡状态,不能进行此项操作!";
            //        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            //        {
            //            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
            //        }
            //        break;

            //    default:
            //        break;
            //}
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int s = 0;
        if (ViewState["flag"] != null)
            s = int.Parse(ViewState["flag"].ToString());
        if (s == 0)
        {
            WebClientHelper.DoClientMsgBox("此卡未激活,不能进行此项操作!");
            return;
        }
        if (s == 2)
        {
            WebClientHelper.DoClientMsgBox("此卡已挂失,请勿重复操作!");
            return;
        }
        if (s == 3)
        {
            WebClientHelper.DoClientMsgBox("此卡已注销,不能进行此项操作!");
            return;
        }
        int ret = CardHelperBLL.Card_GuaShi(Card.Value,Idno1.Value,"");
        if (ret >0)
        {
            //WebClientHelper.DoClientMsgBox("卡号为"+Card.Value +"的卡已成功挂失!");
            string msg = "卡号为" + Card.Value + "的卡已成功挂失!";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            }
        }
        else if (ret == -1)
        {
            WebClientHelper.DoClientMsgBox("操作失败,请重试!");

        }
        else
        {
            WebClientHelper.DoClientMsgBox("手机号验证失败,请重新输入!");
        }
    }
}
