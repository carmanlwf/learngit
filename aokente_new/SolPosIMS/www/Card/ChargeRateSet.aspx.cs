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
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Card_ChargeRageSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        double r1 = double.Parse(txt_Start.Value);
        double r2 = double.Parse(txt_End.Value);
        double r = r2 / r1;//比率倍数
        if (WebHelper.SetRate(0, r) > 0)
        {
            //WebClientHelper.DoClientMsgBox("充值汇率设置成功!");
            string msg = "充值汇率设置成功!";
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
        tb_Log o = new tb_Log();
        o.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
        o.operater = Ims.Main.ImsInfo.CurrentUserId;
        o.logmsg = OperMemo.Value + "当前比率值为：" + r.ToString() ;
        o.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        o.type = "充值规则";
        LogHelperBLL.InsertObject(o);
    }
}
