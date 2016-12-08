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

public partial class Card_CardTypeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_CardType o = ParameterBindHelper.BindParameterToObject(typeof(tb_CardType), BindParameterUsage.OpQuery) as tb_CardType;
        o.DeleStatus = 0;
        e.InputParameters[0] = o; 
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的类型信息!");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        int n = 0;
        int count = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            tb_CardType o = new tb_CardType();
            o.DeleStatus = 1;
            o.DeleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.TypeID = id;
                    if (id == "T-1353061653")
                    {
                        WebClientHelper.DoClientMsgBox("临时卡为系统默认卡类型,您不能删除!");
                        break;
                    }

                    int k = SQLHelper.ExecuteSql("delete from tb_CardType where TypeID='" + id + "'");
                    if (k > 0)
                    {
                        Response.Write("<Script Language=JavaScript>alert(\"删除成功！\");window.location.href=window.location.href; </Script>");

                        this.checkitall.Checked = false;
                        this.chkChouse.Checked = false;

                        //MsgBoxdelete("删除成功");
                    }

                    int m = tb_CardTypeBLL.UpdateObject(o);

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
