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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.PM.BLL;
using Ims.Site.BLL;
using System.IO;
using ZsdDotNetLibrary.Data;
using Ims.Site.Model;
using Ims.Card.BLL;

public partial class Report_Rpt_AllBranchData : System.Web.UI.Page
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

        string posid = machineid.Value.Trim();
        tb_site o = ParameterBindHelper.BindParameterToObject(typeof(tb_site), BindParameterUsage.OpQuery) as tb_site;
        o.machineid = posid;

        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        if (!string.IsNullOrEmpty(regtime1.Value.ToString()) && !string.IsNullOrEmpty(regtime2.Value.ToString()))
        {
            o.regtime1 = regtime1.Value.Trim();
            o.regtime2 = regtime2.Value.Trim();
        }
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {

        string posid = machineid.Value.Trim();

        DataTable dt = new DataTable();
        tb_site o = new tb_site();
        o.machineid = posid;
        if (!string.IsNullOrEmpty(regtime1.Value.ToString()) && !string.IsNullOrEmpty(regtime2.Value.ToString()))
        {
            o.regtime1 = regtime1.Value.Trim();
            o.regtime2 = regtime2.Value.Trim();
        }

        //dt = SiteHelperBLL.RptSiteCountGetPagedObject(0, 100, "", o);
        //if (dt != null && dt.Rows.Count > 0)
        //{
        //    decimal xftj_count = 0;
        //    decimal cztj_count = 0;
        //    decimal cdtj_count = 0;
        //    decimal xftj_amount = 0;
        //    decimal cztj_amount = 0;
        //    decimal cdtj_amount = 0;

        //    decimal xftj_count_total = 0;
        //    decimal cztj_count_total = 0;
        //    decimal cdtj_count_total = 0;
        //    decimal xftj_amount_total = 0;
        //    decimal cztj_amount_total = 0;
        //    decimal cdtj_amount_total = 0;

        //    for (int index = 0; index < dt.Rows.Count; index++)
        //    {
        //        decimal.TryParse(dt.Rows[index]["XFTJ_Count"].ToString(), out xftj_count);
        //        xftj_count_total += xftj_count;
        //        decimal.TryParse(dt.Rows[index]["CZTJ_Count"].ToString(), out cztj_count);
        //        cztj_count_total += xftj_count;
        //        decimal.TryParse(dt.Rows[index]["CDTJ_Count"].ToString(), out cdtj_count);
        //        cdtj_count_total += xftj_count;
        //        decimal.TryParse(dt.Rows[index]["XFTJ_Amount"].ToString(), out xftj_amount);
        //        xftj_amount_total += xftj_count;
        //        decimal.TryParse(dt.Rows[index]["CZTJ_Amount"].ToString(), out cztj_amount);
        //        cztj_amount_total += xftj_count;
        //        decimal.TryParse(dt.Rows[index]["CDTJ_Amount"].ToString(), out cdtj_amount);
        //        cdtj_amount_total += xftj_count;

        //    }

        //    Label1.Text = xftj_count_total.ToString();
        //    Label2.Text = cztj_count_total.ToString();
        //    Label3.Text = cdtj_count_total.ToString();
        //    Label4.Text = xftj_amount_total.ToString();
        //    Label5.Text = cztj_amount_total.ToString();
        //    Label6.Text = cdtj_amount_total.ToString();
        //}
        //else
        //{
        //    Label1.Text = "0";
        //    Label2.Text = "0";
        //    Label3.Text = "0";
        //    Label4.Text = "0.00";
        //    Label5.Text = "0.00";
        //    Label6.Text = "0.00";
        //}
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();

        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的统计信息!");
        }
        else
        {

            int xfbs = 0;//消费笔数
            int czbs = 0;//充值笔数
            int cdbs = 0;//撤单笔数

            decimal xfje = 0; //消费金额
            decimal czje = 0; //充值金额
            decimal cdje = 0;//撤单金额

            int xfbs_total = 0;//消费笔数
            int czbs_total = 0;//充值笔数
            int cdbs_total = 0;//撤单笔数

            decimal xfje_total = 0; //消费金额
            decimal czje_total = 0; //充值金额
            decimal cdje_total = 0;//撤单金额
            
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int.TryParse(GridView1.Rows[i].Cells[1].Text, out xfbs);
                xfbs_total += xfbs;
                int.TryParse(GridView1.Rows[i].Cells[3].Text, out czbs);
                czbs_total += czbs;
                int.TryParse(GridView1.Rows[i].Cells[5].Text, out cdbs);
                cdbs_total += cdbs;

                decimal.TryParse(GridView1.Rows[i].Cells[2].Text, out xfje);
                xfje_total += xfje;
                decimal.TryParse(GridView1.Rows[i].Cells[4].Text, out czje);
                czje_total += czje;
                decimal.TryParse(GridView1.Rows[i].Cells[6].Text, out cdje);
                cdje_total += cdje;
                ;
            }
            Label1.Text = xfbs_total.ToString();
            Label2.Text = czbs_total.ToString();
            Label3.Text = cdbs_total.ToString();
            Label4.Text = xfje_total.ToString();
            Label5.Text = czje_total.ToString();
            Label6.Text = cdje_total.ToString();
        }
    }

    protected void btnOut_Click(object sender, EventArgs e)
    {
        
     
        string sit = string.IsNullOrEmpty(machineid.Value.ToString().Trim()) ? "" :machineid.Value.ToString().Trim();
        string where = "";
        string str = "";
        if (sit != "")
        {
            str += " and Category = '" + sit + "'";
        }
        if (regtime1.Value.ToString() != "")
        {
            where += " and Datetime>='" + regtime1.Value.ToString() ;
        }

        if (regtime2.Value.ToString() != "")
        {
            where += " and Datetime<='" + regtime2.Value.ToString() ;
        }
        DataTable dt = SiteHelperBLL.SiteCountOutMachine(where, str);
        StringWriter sw = new StringWriter(); //创建对象
        sw.WriteLine("\t\t\t机器号统计信息 ");  //输入标题 
        sw.WriteLine("机器编号\t时间段");//输入字段
        sw.WriteLine( sit + "\t" + regtime1.Value.ToString() + "--" + regtime2.Value.ToString());
        sw.Close(); //关闭数据流
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls"); //test.xls导入Excel得文件名
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(sw);
        DataToExcel.CreateExcel(dt, "haogongming");
    }
}