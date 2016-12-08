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

public partial class Card_CardJieGua : System.Web.UI.Page
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
            string msg = "";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            tb_Card o = new tb_Card();
            string card = Request.QueryString["getcode"].ToString();
            o = CardHelperBLL.GetObject(card);
            ViewState["flag"] = o.Status;
            if (o.Status == 2)//挂失状态
            {
                ParameterBindHelper.BindObjectToParameter(o, BindParameterUsage.BindToParameter);
                ControlHelper.SetControlReadonly(Card, true);
                ControlHelper.SetControlReadonly(RealName, true);
            }
            else
            {
                msg = "未挂失的卡不能进行解挂操作!";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
            }

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int s = 0;
        if (ViewState["flag"] != null)
            s = int.Parse(ViewState["flag"].ToString());
        if (s != 2)
        {
            WebClientHelper.DoClientMsgBox("未挂失的卡不能进行解挂操作!");
            return;
        }
        int ret = CardHelperBLL.Card_JieGua(Card.Value, Idno1.Value,"");
        if (ret > 0)
        {
            //WebClientHelper.DoClientMsgBox("卡号为" + Card.Value + "的卡已成功解挂!");
            string msg = "卡号为" + Card.Value + "的卡已成功解挂!";
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
