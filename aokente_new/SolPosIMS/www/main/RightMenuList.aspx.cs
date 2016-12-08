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
using Ims.Card.Model;
using NewSoftDotNetLibrary.Web;

public partial class main_RightMenuList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,manager") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        Label1.Text = Ims.Main.ImsInfo.CurrentUserId;
        Label2.Text = Ims.Main.ImsInfo.CurrentUser.Name;
        Label3.Text = Ims.Main.ImsInfo.CurrentUser.HostName;
        Label4.Text = Ims.Main.ImsInfo.CurrentUser.ServerIp;
        Label5.Text = "VIP1.1.0优化版";
    }
    /// <summary>
    /// 转换时分秒
    /// </summary>
    /// <param name="HowManySecond"></param>
    /// <returns></returns>
    public string RtnTimeStr(object Minutes)
    {
        
        string SumMins = "";
        if (Minutes !=null)
            SumMins = Minutes.ToString();
        else
            SumMins = "0分钟";
        int Mins = 0;
        if (!string.IsNullOrEmpty(SumMins))
        {
            int.TryParse(SumMins, out Mins);
        }
        else
        { return "0分钟"; }

        int days = Mins/1440;//天数
        int day_plus = Mins % 1440;//余数(分钟)
        int hour = day_plus / 60;//小时数
        int Min = day_plus % 60; //(余数)分钟数

        return days + "天" + hour + "小时" + Min + "分";
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_pos_transaction o = new v_pos_transaction();
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的停车信息!");
        }

        //BindStaticsData();

    }
}
