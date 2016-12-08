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
using Ims.Card.Model;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web.BindParameter;
using System.IO;
using Ims.PM.BLL;

public partial class Report_Rpt_Memberlost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!IsPostBack)
        {
            //validDatetuse.Items.Insert(0, new ListItem("全部", ""));
            //validDatetuse.Items.Insert(1, new ListItem("过期", "过期"));
            //validDatetuse.Items.Insert(2, new ListItem("有效", "有效"));
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Card o = ParameterBindHelper.BindParameterToObject(typeof(tb_Card), BindParameterUsage.OpQuery) as tb_Card;
 
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId); 
        }
        o.validDatetuse = "过期";
        o.chflag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的账户信息!");
        }
    }
    protected void btnOut_Click(object sender, EventArgs e)
    {
        //string car = string.IsNullOrEmpty(card.Value.ToString().Trim()) ? "" : card.Value.ToString().Trim();
        //string nam = string.IsNullOrEmpty(RealName.Value.ToString().Trim()) ? "" : RealName.Value.ToString().Trim();
        //string val = string.IsNullOrEmpty(validDatetuse.Value.ToString().Trim()) ? "" : validDatetuse.Value.ToString().Trim();
        //string siteid = "";
        //if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        //{
        //    siteid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        //}
        //DataTable dt = CardHelperBLL.MemberCardDateTongji(car, nam, val,siteid);
        //StringWriter sw = new StringWriter(); //创建对象
        //sw.WriteLine("\t\t\t会员卡期限信息 ");  //输入标题 
        //sw.WriteLine("会员卡号\t用户名\t使用状态");//输入字段
        //sw.WriteLine(car + "\t" + nam + "\t" + val);
        //sw.Close(); //关闭数据流
        //Response.AddHeader("Content-Disposition", "attachment; filename=memlost.xls"); //test.xls导入Excel得文件名
        //Response.ContentType = "application/ms-excel";
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //Response.Write(sw);
        //DataToExcel.CreateExcel(dt, "huiyuan ka qixian tongji ");
    }
}