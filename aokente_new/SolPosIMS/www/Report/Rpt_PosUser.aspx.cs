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
using System.IO;
using ZsdDotNetLibrary.Data;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.Card.BLL;
using Ims.Card.Model;

public partial class Report_Rpt_PosUser : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
      

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_card_chargelist_area o = ParameterBindHelper.BindParameterToObject(typeof(v_card_chargelist_area), BindParameterUsage.OpQuery) as v_card_chargelist_area;
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的充值信息!");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            card_chargelist o = new card_chargelist();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.transId = id;
                    int deletesum =
                        CardChargeListBLL.DeleteObject(o);

                    if (deletesum > 0)
                    {
                        count++;
                    }
                    else
                    {
                        sum++;
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

            }
            else
            {
                if (count > 0)
                {

                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    //log.operater = "admin";
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "  对充值记录进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);

                    GridView1.DataSourceID = "ObjectDataSource1";
                    GridView1.PageIndex = 0;
                    GridView1.DataBind();

                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    WebClientHelper.DoClientMsgBox("删除失败,请重试!");
                }
            }
        }
    }

    /// <summary>
    /// 导出充值记录表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOut_Click1(object sender, EventArgs e)
    {
        string car = string.IsNullOrEmpty(operid.Value.ToString().Trim()) ? "" : operid.Value.ToString().Trim();
      
        string siteid = "";
        DataTable dt = CardChargeListBLL.DTTransLogTaday(car);
        StringWriter sw = new StringWriter(); //创建对象
        sw.WriteLine("\t\t\t充值记录信息 ");  //输入标题 
        sw.WriteLine("操作员名称");//输入字段
        sw.WriteLine(car + "\t");
        sw.Close(); //关闭数据流
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls"); //test.xls导入Excel得文件名
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(sw);
        DataToExcel.CreateExcel(dt, "chongzhi biao jilu");
    }
}
