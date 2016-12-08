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
using NewSoftDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;

public partial class CardHold_CardUnlock : System.Web.UI.Page
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
            

        }
    }
    protected void btnUnLock_Click(object sender, EventArgs e)
    {
        string msg = "";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        tb_Card o = new tb_Card();
        string card = cardsnr.Value;
        o = CardHelperBLL.GetObject(card);
        ViewState["flag"] = o.Status;
        if (o.Status == 2)//挂失状态
        {
            ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
        }
        else
        {
            msg = "未挂失的卡不能进行解挂操作!";
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            }
        }

        int s = 0;
        if (ViewState["flag"] != null)
            s = int.Parse(ViewState["flag"].ToString());
        if (s != 2)
        {
            WebClientHelper.DoClientMsgBox("未挂失的卡不能进行解挂操作!");
            return;
        }
        int ret = CardHelperBLL.Card_JieGua(cardsnr.Value.Trim(), Mobile.Value.Trim(),memo.Value.Trim());
        if (ret > 0)
        {
            //WebClientHelper.DoClientMsgBox("卡号为" + Card.Value + "的卡已成功解挂!");
            string rtnmsg = "卡号为" + cardsnr.Value + "的卡已成功解挂!";
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + rtnmsg + "');</script>");

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

