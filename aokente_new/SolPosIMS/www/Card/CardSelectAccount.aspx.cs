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

public partial class Card_CardSelectAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Card o = ParameterBindHelper.BindParameterToObject(typeof(tb_Card), BindParameterUsage.OpQuery) as tb_Card;
        //o.activitystatus = 1;//完全被激活的卡 临时激活2和未激活的卡 0
        o.Status = 1;//正常的卡才能转显示
        o.chflag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.PageIndex = 0;
            GridView1.DataBind();
            if (GridView1.Rows.Count <= 0)
            {
                WebClientHelper.DoClientMsgBox("没有满足条件的会员账户信息,或许卡方面还没有激活!");
            }
    }

    protected void bt_Confirm_ServerClick(object sender, EventArgs e)
    {
        string[] selectCardAccounts = Request.Form.GetValues("selectRadioButton1");
        string parm_card = "";
        string parm_name = "";
        string parm_balance = "";
        if (selectCardAccounts != null)
        {
            parm_card = selectCardAccounts[0].Trim();
            GridViewRow row = null;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.DataKeys[i].Value.ToString() == parm_card)
                {
                    row = GridView1.Rows[i];
                    break;
                }
            }
            if (row != null)
            {
                parm_name = row.Cells[2].Text;
                parm_balance = row.Cells[4].Text;
            }
        }
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + parm_card + "','" + parm_name + "','" + parm_balance + "');</script>");

        }
    }

}
