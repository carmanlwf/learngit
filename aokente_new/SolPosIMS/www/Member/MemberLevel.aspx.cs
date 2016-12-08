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
using Ims.Member.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Member.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Member_MemberLevel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////权限验证
 
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!IsPostBack)
        {
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                GridView1.Columns[0].Visible = false;
                GridView1.Columns[2].Visible = false;
                GridView1.Columns[6].Visible = false;
                btnNew.Visible = false;
                delPanel.Visible = false;
            }
            if (Ims.Main.ImsInfo.UserIsInRoles("admin") != "")//店长
            {
                GridView1.Columns[3].Visible = false;
        
            }
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
            WebClientHelper.DoClientMsgBox("没有满足条件的会员等级信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_MemberRanks o = ParameterBindHelper.BindParameterToObject(typeof(tb_MemberRanks), BindParameterUsage.OpQuery) as tb_MemberRanks;
        o.flag = false;
        e.InputParameters[0] = o;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            tb_MemberRanks o = new tb_MemberRanks();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.id = id;
                    if (MemberHelperBLL.MemberRank_Times(id) > 0 || o.id == "0" || o.Name == "默认等级")//判断此等级是否正在处于使用之中，大于0则为使用
                    {
                        sum++;
                    }
                    else
                    {
                        int m = Ims.Member.BLL.MemberRanksHelper.DeleteObject(o);
                        if (m > 0)
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
            //删除成功才写入操作日志
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
                    log.logmsg = log.operater + "对会员等级进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "对会员等级进行删除操作,成功删除数据" + count + "条记录!" + "未能删除" + sum + "条记录! 原因是这些等级正处于使用之中!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!" + "未能删除  " + sum + "条记录! 原因是这些等级正处于使用之中!");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!原因是这些等级正处于使用之中!");
            }
        }
    }
}
