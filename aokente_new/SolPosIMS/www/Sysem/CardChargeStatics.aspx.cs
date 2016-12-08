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
using NewSoftDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;
using Ims.Card.BLL;

public partial class Sysem_CardChargeStatics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel,manager") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        string time1 = "";
        string time2 = "";
        switch (RadioButtonList1.SelectedValue)
        {
            case "查询本年":
                time1 = DateTime.Today.Year.ToString() + "-01-01" + " 00:00:00";
                time2 = DateTime.Today.Year.ToString() + "-12-31" + " 23:59:59";
                break;
            case "查询本月":
                //当前月份第一天   
                time1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd") + " 00:00:00";
                //当前月份最后一天   + " 23:59:59"
                time2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
                break;
            case "查询今天":
                time1 = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
                time2 = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
                break;
            case "自定义":
                time1 = !string.IsNullOrEmpty(OperateDate1.Value.Trim()) ? OperateDate1.Value.Trim() + " 00:00:00" : "";
                time2 = !string.IsNullOrEmpty(OperateDate1.Value.Trim()) ? OperateDate2.Value.Trim() + " 23:59:59" : "";
                break;

        }
        card_chargestatics o = ParameterBindHelper.BindParameterToObject(typeof(card_chargestatics), BindParameterUsage.OpQuery) as card_chargestatics;
        
        o.OperateDate1 = time1;
        o.OperateDate2 = time2;
        o.operatorid = operatorid.Value;
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        string operid = operatorid.Value.Trim();
        string time1 = "";
        string time2 = "";
        switch (RadioButtonList1.SelectedValue)
        {
            case "查询本年":
                time1 = DateTime.Today.Year.ToString() + "-01-01" + " 00:00:00";
                time2 = DateTime.Today.Year.ToString() + "-12-31" + " 23:59:59";
                break;
            case "查询本月":
                //当前月份第一天   
                time1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd") + " 00:00:00";
                //当前月份最后一天   + " 23:59:59"
                time2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
                break;
            case "查询今天":
                time1 = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
                time2 = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
                break;
            case "自定义":
                time1 = !string.IsNullOrEmpty(OperateDate1.Value.Trim()) ? OperateDate1.Value.Trim() + " 00:00:00" : "";
                time2 = !string.IsNullOrEmpty(OperateDate1.Value.Trim()) ? OperateDate2.Value.Trim() + " 23:59:59" : "";
                break;
            
        }

        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        DataTable dt1 = CardChargeListBLL.HavetimeCountCardChargeListByOperatorId(operid, time1, time2);
        DataTable dt2 = CardChargeListBLL.HavetimeCountCardChargeStaticsByOperatorIdAndTime(operid, time1, time2);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            Label1.Text = dt1.Rows[0]["am"].ToString();
            Label2.Text = dt1.Rows[0]["charge_sum"].ToString();
            Label3.Text = dt1.Rows[0]["cancel_sum"].ToString();
            Label4.Text = (decimal.Parse(dt1.Rows[0]["charge_sum"].ToString()) - decimal.Parse(dt1.Rows[0]["cancel_sum"].ToString())).ToString();
        }
        if (dt2 != null && dt2.Rows.Count > 0)
        {
            int vipcount = 0;
            //int v_count = 0;

            decimal vipamount = 0;
            //decimal v_amount = 0;
            decimal.TryParse(dt2.Rows[0]["vipAmount"].ToString(),out vipamount);
            int.TryParse(dt2.Rows[0]["vipCount"].ToString(), out vipcount);
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    int.TryParse(GridView1.Rows[i].Cells[9].Text, out v_count);
            //    decimal.TryParse(GridView1.Rows[i].Cells[10].Text, out v_amount);
            //    vipcount += v_count;
            //    vipamount += v_amount;
            //}
            Label5.Text = vipcount.ToString();
            Label6.Text = vipamount.ToString();
        }
        if (GridView1.Rows.Count <= 0)
        {
            Label1.Text = "0";
            Label2.Text = "0";
            Label3.Text = "0";
            Label4.Text = "0";
            Label5.Text = "0";
            Label6.Text = "0";
            WebClientHelper.DoClientMsgBox("没有满足条件的充值信息!");
        }


    }
}
