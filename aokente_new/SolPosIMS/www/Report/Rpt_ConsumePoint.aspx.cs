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
using ZsdDotNetLibrary.Data;
using Ims.Log.Model;
using Ims.Card.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.BLL;
using System.IO;
using Ims.PM.BLL;
public partial class Report_Rpt_ConsumePoint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
 
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
  

            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
            Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                this.TABLE1.Rows[1].Style.Add("display ", "none ");
            }
         
        }
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        string siteid = "";
        string areacode = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,channel") != "")//admin
        {
            areacode = Area_Code.SelectedValue;
            siteid = Site_Code.SelectedValue.ToString().Trim();
        }
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            siteid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);//获取对应该的分店编号
        }
        DataTable ta = CardHelperBLL.MemberCountOrder(card.Value, RealName.Value.Trim(), siteid, areacode);
        if (ta != null)
        {
            Label2.Text = ta.Rows[0][0].ToString();
            Label3.Text = ta.Rows[0][1].ToString();

            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.PageIndex = 0;
            GridView1.DataBind();
            if (GridView1.Rows.Count <= 0)
            {
                Label2.Text ="0.00";
                Label3.Text = "0.00";
                WebClientHelper.DoClientMsgBox("没有满足条件的会员卡信息!");
            }
        }

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Card o = ParameterBindHelper.BindParameterToObject(typeof(tb_Card), BindParameterUsage.OpQuery) as tb_Card;
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,channel") != "")//admin
        {
            o.areacode = Area_Code.SelectedValue;
            o.regionid = Site_Code.SelectedValue.ToString().Trim();
        }
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            o.regionid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);//获取对应该的分店编号
        }

        o.chflag = true;
        o.Status = 1;
        e.InputParameters[0] = o;

    }

    protected void btnOut_Click(object sender, EventArgs e)
    {
        string car = string.IsNullOrEmpty(card.Value.ToString().Trim()) ? "" : card.Value.ToString().Trim();
        string nam = string.IsNullOrEmpty(RealName.Value.ToString().Trim()) ? "" : RealName.Value.ToString().Trim();
        string are = string.IsNullOrEmpty(Area_Code.SelectedValue.ToString().Trim()) ? "" : Area_Code.SelectedValue.ToString().Trim();
        string sit = string.IsNullOrEmpty(Site_Code.SelectedValue.ToString().Trim()) ? "" : Site_Code.SelectedValue.ToString().Trim().ToString().Trim();
        string siteid = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            siteid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        DataTable dt = CardHelperBLL.MemberInfoTongJi(car, nam, are, sit,siteid);
        StringWriter sw = new StringWriter(); //创建对象
        sw.WriteLine("\t\t\t会员统计信息 ");  //输入标题 
        sw.WriteLine("会员卡号\t会员姓名\t所属区域\t所属分店");//输入字段
        sw.WriteLine(car + "\t" + nam + "\t" + are + "\t" + sit);
        sw.Close(); //关闭数据流
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls"); //test.xls导入Excel得文件名
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(sw);
        DataToExcel.CreateExcel(dt, "haogongming");
    }
    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            Site_Code.Items.Clear();
            Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
        }
    }
}
