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
using Ims.Card.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;
using System.IO;
using Ims.PM.BLL;
public partial class Sysem_TransLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!IsPostBack)
        {
            typename.DataSource = TransLogHelperBLL.BrandNameTable();
            typename.DataTextField = "typename";
            typename.DataValueField = "typename";
            typename.DataBind();

            typename.Items.Insert(0, new ListItem("全部", ""));
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_TransLog o = ParameterBindHelper.BindParameterToObject(typeof(tb_TransLog), BindParameterUsage.OpQuery) as tb_TransLog;
        if (!string.IsNullOrEmpty(OperateDate1.Value) && !string.IsNullOrEmpty(OperateDate2.Value))
        {
            o.OperateDate1 = OperateDate1.Value.ToString() + " 00:00:00";
            o.OperateDate2 = OperateDate2.Value.ToString() + " 23:59:60";
        } 
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
               o.regionid=   PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }    
    
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        string car = string.IsNullOrEmpty(Card.Value.ToString().Trim()) ? "" : Card.Value.ToString().Trim();
        string dat1 = string.IsNullOrEmpty(OperateDate1.Value.ToString().Trim()) ? "" : OperateDate1.Value.ToString().Trim() + " 00:00:00";
        string dat2 = string.IsNullOrEmpty(OperateDate2.Value.ToString().Trim()) ? "" : OperateDate2.Value.ToString().Trim() + " 23:59:60";
        DataTable ta = TransLogHelperBLL.HavetimeCountTransLog(car, dat1, dat2, typename.Value.ToString());
        Label2.Text = ta.Rows[0][0].ToString();
        Label3.Text = ta.Rows[0][1].ToString();
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的充值信息!");
        }
        else if (OperateDate1.Value != "" && OperateDate2.Value == "")
        { WebClientHelper.DoClientMsgBox("时间一不能为空!"); }
        else if (OperateDate1.Value == "" && OperateDate2.Value != "")
        { WebClientHelper.DoClientMsgBox("时间二不能为空!"); }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            tb_TransLog o = new tb_TransLog();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.TransNo = id;
                    int deletesum = TransLogHelperBLL.DeleteObject(o);

                    if (deletesum > 0)
                    {
                        count++;
                    }
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
        string car = string.IsNullOrEmpty(Card.Value.ToString().Trim()) ? "" : Card.Value.ToString().Trim();
        string dat1 = string.IsNullOrEmpty(OperateDate1.Value.ToString().Trim()) ? "" : OperateDate1.Value.ToString().Trim() + " 00:00:00";
        string dat2 = string.IsNullOrEmpty(OperateDate2.Value.ToString().Trim()) ? "" : OperateDate2.Value.ToString().Trim() + " 23:59:60";
        string tpename = typename.Value.ToString();
        string siteid = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            siteid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        DataTable dt = TransLogHelperBLL.DTTransLog(car,tpename, dat1, dat2, siteid);
        StringWriter sw = new StringWriter(); //创建对象
        sw.WriteLine("\t\t\t充值记录信息 ");  //输入标题 
        sw.WriteLine("会员卡号\t日期");//输入字段
        sw.WriteLine(car + "\t" + dat1 + "~" + dat2);
        sw.Close(); //关闭数据流
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls"); //test.xls导入Excel得文件名
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(sw);
        DataToExcel.CreateExcel(dt, "chongzhi biao jilu");
    }
}

