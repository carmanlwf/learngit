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
using Ims.Site.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Site.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.PM.BLL;
using Ims.Admin.BLL;
using Ims.Card.BLL;
using System.IO;
using ZsdDotNetLibrary.Data;


public partial class Report_Rpt_SiteCount : System.Web.UI.Page
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
        string site = sitename.Value.Trim();
        string siteid = id.Value.ToString();


        tb_site o = ParameterBindHelper.BindParameterToObject(typeof(tb_site), BindParameterUsage.OpQuery) as tb_site;

        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }

        o.id = siteid;
        o.sitename = site;
        if (!string.IsNullOrEmpty(regtime1.Value.ToString())&&!string.IsNullOrEmpty(regtime2.Value.ToString()))
        {
            o. regtime1 = regtime1.Value.Trim();
            o.regtime2 = regtime2.Value.Trim();
        }
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        string site = sitename.Value.Trim();
        string siteid = id.Value.ToString();

        DataTable dt = new DataTable();
        tb_site o = new tb_site();
        o.id = siteid;
        o.sitename = site;
        if (!string.IsNullOrEmpty(regtime1.Value.ToString()) && !string.IsNullOrEmpty(regtime2.Value.ToString()))
        {
            o.regtime1 = regtime1.Value.Trim();
            o.regtime2 = regtime2.Value.Trim();
        }

        //dt = SiteHelperBLL.RptSiteCountGetPagedObject(0,100,"",o);
        //if (dt != null && dt.Rows.Count > 0)
        //{
        //    Label1.Text = dt.Rows[0]["XFTJ_Count"].ToString();
        //    Label2.Text = dt.Rows[0]["CZTJ_Count"].ToString();
        //    Label3.Text = dt.Rows[0]["CDTJ_Count"].ToString();
        //    Label4.Text = dt.Rows[0]["XFTJ_Amount"].ToString();
        //    Label5.Text = dt.Rows[0]["CZTJ_Amount"].ToString();
        //    Label6.Text = dt.Rows[0]["CDTJ_Amount"].ToString();
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
                int.TryParse(GridView1.Rows[i].Cells[2].Text, out xfbs);
                xfbs_total += xfbs;
                int.TryParse(GridView1.Rows[i].Cells[4].Text, out czbs);
                czbs_total += czbs;
                int.TryParse(GridView1.Rows[i].Cells[6].Text, out cdbs);
                cdbs_total += cdbs;

                decimal.TryParse(GridView1.Rows[i].Cells[3].Text, out xfje);
                xfje_total += xfje;
                decimal.TryParse(GridView1.Rows[i].Cells[5].Text, out czje);
                czje_total += czje;
                decimal.TryParse(GridView1.Rows[i].Cells[7].Text, out cdje);
                cdje_total += cdje;
                ;
            }
            Label1.Text = xfbs_total.ToString();
            Label4.Text = xfje_total.ToString();
        }
    }

    protected void btnOut_Click(object sender, EventArgs e)
    {

    }
}
