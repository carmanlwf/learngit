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
using Ims.Card.Model;
using NewSoftDotNetLibrary.Web.BindParameter;

public partial class CardHold_CardLock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }
    protected void btnLock_Click(object sender, EventArgs e)
    {
        InitListControlHelper.InitListControls(typeof(tb_Card));
        string card = cardsnr.Value;
        tb_Card o = new tb_Card();
        o = CardHelperBLL.GetObject(card);
        ViewState["flag"] = o.Status;
        ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
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
        ////////////////////////////////////////////////////////////////////////////////
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
        int ret = CardHelperBLL.Card_GuaShi(cardsnr.Value, Mobile.Value.Trim(),memo.Value.Trim());
        if (ret > 0)
        {
            //WebClientHelper.DoClientMsgBox("卡号为"+Card.Value +"的卡已成功挂失!");
            string Rtnmsg = "卡号为" + cardsnr.Value + "的卡已成功挂失!";
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + Rtnmsg + "');</script>");

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
