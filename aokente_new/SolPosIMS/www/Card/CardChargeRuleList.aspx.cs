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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web;

public partial class Card_CardChargeRuleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        cardchargerule o = ParameterBindHelper.BindParameterToObject(typeof(cardchargerule), BindParameterUsage.OpQuery) as cardchargerule;
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        int n = 0;
        int count = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            cardchargerule o = new cardchargerule();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.bounsid = id;

                    int m = tb_CardActive_HistroyBLL.DeleteObjects_ChargeRules(o);

                    if (m > 0)
                    {
                        count++;
                    }
                }
            }

        }
        if (n == this.GridView1.Rows.Count)
        {
            WebClientHelper.DoClientMsgBox("请先选择要删除的项!");
            return;
        }
        if (count > 0)
        {
            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.PageIndex = 0;
            GridView1.DataBind();
            WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
        }
    }
}

