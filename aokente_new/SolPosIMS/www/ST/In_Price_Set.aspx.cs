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
using Ims.Site.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Site.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;
using System.Collections.Generic;


public partial class ST_In_Price_Set : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,maintenance") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {

            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));

            pname.Items.Insert(0, new ListItem("请选择", ""));
            InitListControlHelper.BindNormalTableToListControl(pname, "pid", "pname", "price_temp_feetype", "", "", "");

            GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        }
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        this.GridView1.DataSourceID = "ObjectDataSource1";
        this.GridView1.PageIndex = 0;
        this.GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的价次信息!");
        }
        else
        {
            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.PageIndex = 0;
            GridView1.DataBind();
            if (GridView1.Rows.Count <= 0)
            {
                WebClientHelper.DoClientMsgBox("没有满足条件的价次信息!");
            }
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        price_temp_sitefeelist o = ParameterBindHelper.BindParameterToObject(typeof(price_temp_sitefeelist), BindParameterUsage.OpQuery) as price_temp_sitefeelist;
        List<tb_site> tlist = new List<tb_site>();

        o.Flag = null;
        if (!string.IsNullOrEmpty(pname.Value) && pname.Value != "0")
            o.Pname = pname.Items[pname.SelectedIndex].Text;
        if (!string.IsNullOrEmpty(spid.Value))
            o.Spid = spid.Value.ToString();
        if (!string.IsNullOrEmpty(minPayment.Value))
            o.MinPayment = Convert.ToDecimal(minPayment.Value);

        if (!string.IsNullOrEmpty(Area_Code.SelectedValue))
        {
            tb_site site = new tb_site();
            //site.id = Site_Code.SelectedValue; 
            site.areacode = Area_Code.SelectedValue;
            tlist = SiteHelperBLL.GetPagedObjects_id(site);
        }
        List<price_temp_sitefeelist> sitefeelist = new List<price_temp_sitefeelist>();
        if (tlist != null && tlist.Count > 0)
        {
            foreach (tb_site r in tlist)
            {
                price_temp_sitefeelist psite = new price_temp_sitefeelist();
                psite.Siteid = r.id;
                sitefeelist.Add(psite);
            }
        }
        if (sitefeelist != null && sitefeelist.Count > 0)
        {
            foreach (price_temp_sitefeelist p in sitefeelist)
            {
                o.Siteid += "'"+p.Siteid +"',";
            }
            o.Siteid = o.Siteid.TrimEnd(',');
        }
        
        if (!string.IsNullOrEmpty(Site_Code.SelectedValue))
        {
            o.Siteid = "'" + Site_Code.SelectedValue + "'";
        }

        e.InputParameters[0] = o;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            price_temp_sitefeelist o = new price_temp_sitefeelist();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.Spid = id;
                    int m = Ims.Site.BLL.price_temp_sitefeelistBLL.DeleteObject(o);
                    if (m > 0)
                    {
                        count++;
                    }

                }
                else
                {
                    n++;
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

                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                if (sum == 0)
                {
                    log.logmsg = log.operater + "  对价次信息进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "价次信息删除操作,成功删除数据" + count + "条记录!" + "未能删除" + sum + "条记录! 原因是这些类别下有商品,系统默认不能删除!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!" + "未能删除 " + sum + "条记录! 原因是这些区域下有站点,系统默认不能删除!");
                }

            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!");
            }
        }
    }
    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            Site_Code.Items.Clear();
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
    }
}
