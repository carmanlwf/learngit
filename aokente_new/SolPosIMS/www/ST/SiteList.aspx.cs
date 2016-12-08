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
using Ims.PM.BLL;
using Ims.Admin.BLL;

public partial class ST_SiteList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel,maintenance") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            Category.Items.Insert(0, new ListItem("自营路段", "自营路段"));
            Category.Items.Insert(1, new ListItem("全部", ""));
            Category.Items.Insert(2, new ListItem("合营路段", "合营路段"));
            Category.Items.Insert(3, new ListItem("私家路段", "私家路段"));
            Category.Items.Insert(4, new ListItem("承包路段", "承包路段"));


            InitListControlHelper.BindNormalTableToListControl(areacode, "areacode", "areaname", "tb_area");
            areacode.Items.Insert(0, new ListItem("全部", ""));

        }

        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//设置功能限制
        {
            areacode.Disabled = true;
         
        }

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
       
        tb_site o = ParameterBindHelper.BindParameterToObject(typeof(tb_site), BindParameterUsage.OpQuery) as tb_site;
        o.flag = true;
        //if (Ims.Main.ImsInfo.UserIsInRoles("agent") == "agent")
        //{
        //    areacode.Disabled = true;
        //    //根据登录编号获得区域编号
        //    o.areacode = PmTtBLLHelper.GetAreacodeByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        //}
        //品牌方面
        string sort = AgentInfoBLL.GetChannelSort();//获取品牌渠道
        if (sort != "")
        {
            o.Category = sort;
        }
        if (regtime1.Value != "" && regtime2.Value != "")
        {
            o.regtime1 = regtime1.Value.Trim() + " 00:00:00";
            o.regtime2 = regtime2.Value.Trim() + " 23:59:60";
        }
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {

        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的路段信息!");
        }  
        else if (regtime1.Value != "" && regtime2.Value == "")
        { WebClientHelper.DoClientMsgBox("时间二不能为空!"); }
        else if (regtime1.Value == "" && regtime2.Value != "")
        { WebClientHelper.DoClientMsgBox("时间一不能为空!"); }
        else
        {
            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.PageIndex = 0;
            GridView1.DataBind();
            if (GridView1.Rows.Count <= 0)
            {
                WebClientHelper.DoClientMsgBox("没有满足条件的路段信息!");
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        

        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            tb_site o = new tb_site();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.id = id;
                    int delectSum = SiteHelperBLL.Site_Times(id);
                    if (delectSum > 0)
                    {
                        sum++;
                    }
                    else
                    {
                        int spot_count = SiteHelperBLL.IsHasSpotBySiteid(id);
                        int m = Ims.Site.BLL.SiteHelperBLL.DeleteObject(o);
                        if (m > 0 && spot_count <=0)
                        {
                            count++;
                        }
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
                    log.logmsg = log.operater + "  操作完成,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "路段进行删除操作,成功删除数据" + count + "条记录!" + "未能删除" + sum + "条记录! 原因是这些路段正在处于使用状态,系统默认不能删除!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!" + "未能删除 " + sum + "条记录! 原因是这些路段正在处于使用状态,系统默认不能删除!");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败,原因是这些路段正在处于使用状态,系统默认不能删除!");
            }
        }
    }

}
