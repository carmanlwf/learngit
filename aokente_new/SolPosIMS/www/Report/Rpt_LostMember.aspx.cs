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
using Ims.Card.BLL;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using System.IO;
using Ims.PM.BLL;
public partial class Report_Rpt_LostMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
 
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_loss_Member_info o = ParameterBindHelper.BindParameterToObject(typeof(v_loss_Member_info), BindParameterUsage.OpQuery) as v_loss_Member_info;
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId); 
        }
        o.flag = true;
        o.status = 1;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的会员卡信息!");
        }
    }
    protected void btnOut_Click(object sender, EventArgs e)
    {
        string car = string.IsNullOrEmpty(card.Value.ToString().Trim()) == true ? "" : card.Value.ToString().Trim();
        string nam = string.IsNullOrEmpty(RealName.Value.ToString().Trim()) == true ? "" : RealName.Value.ToString().Trim();
        string mon = string.IsNullOrEmpty(monthquantry.Value.ToString().Trim()) == true ? "" : monthquantry.Value.ToString().Trim();
        string siteid = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            siteid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        DataTable dt = v_loss_Member_infoBLL.VlossMemberInfo(car, nam, mon,siteid);
        StringWriter sw = new StringWriter(); //创建对象
        sw.WriteLine("\t\t\t会员流失信息 ");  //输入标题 
        sw.WriteLine("会员卡号\t会员姓名\t多久没来消费");//输入字段
        sw.WriteLine(car + "\t" + nam + "\t" + mon);
        sw.Close(); //关闭数据流
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls"); //test.xls导入Excel得文件名
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(sw);
        DataToExcel.CreateExcel(dt, "huiyuanliushi");
    }
}
