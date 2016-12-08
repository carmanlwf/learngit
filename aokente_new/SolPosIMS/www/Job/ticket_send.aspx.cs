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
using ZsdDotNetLibrary.Web;
using Ims.Job.Model;
using Ims.Job.BLL;

public partial class Job_ticket_send : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if(!Page.IsPostBack)
            InitListControlHelper.BindNormalTableToListControl(rdbl_select, "operatorid", "name", "tb_Pos_Operator", "", "", "");

    }
    protected void bt_Batch_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(rdbl_select.SelectedValue))
        {
            WebClientHelper.DoClientMsgBox("请选择领取人员!");
            return;
        }
        else
        {
            ticket_sendlist ts_object = new ticket_sendlist();
            ts_object.tid = DateTime.Now.ToString("yyMMddHHmmss");
            decimal ToatalAmount = 0;
            decimal.TryParse(amount.Value.Trim(), out ToatalAmount);
            ts_object.amount = ToatalAmount;
            ts_object.memo = memo.Value.Trim();
            ts_object.state = 1;//有效
            ts_object.operatorid = Ims.Main.ImsInfo.CurrentUserId;
            ts_object.receiver = rdbl_select.SelectedItem.Value;

            int ret = TicketHelperBLL.InsertObject(ts_object);

            string rtnmsg = "操作完成.[" + rdbl_select.SelectedItem.Text + "]已成功领取共计"+ToatalAmount.ToString()+ "元票据";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + rtnmsg + "');</script>");

            }
        }
    }


}
