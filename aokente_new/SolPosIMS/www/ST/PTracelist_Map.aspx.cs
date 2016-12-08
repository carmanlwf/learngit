using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ims.Site.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Web;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class ST_PTracelist_Map : System.Web.UI.Page
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
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的人员执勤信息!");
        }
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

        V_AlarmTracelist o = ParameterBindHelper.BindParameterToObject(typeof(V_AlarmTracelist), BindParameterUsage.OpQuery) as V_AlarmTracelist;

        e.InputParameters[0] = o;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            V_AlarmTracelist o = new V_AlarmTracelist();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.Id = id;
                    int m = Ims.Site.BLL.AlarmTracelistBLL.DeleteObject(o);
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
                    log.logmsg = log.operater + "  对区域内容进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "区域内容进行删除操作,成功删除数据" + count + "条记录!" + "未能删除" + sum + "条记录! 原因是这些类别下有商品,系统默认不能删除!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!" + "未能删除 " + sum + "条记录! 原因是这些区域下有站点,系统默认不能删除!");
                }

            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!原因是这些区域下有站点,系统默认不能删除!");
            }
        }
    }
}
