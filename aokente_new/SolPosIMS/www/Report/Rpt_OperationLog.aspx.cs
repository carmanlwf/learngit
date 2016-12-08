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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Log.Model;

public partial class Report_Rpt_OperationLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证    
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,manager,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            type.Items.Insert(0, new ListItem("全部", ""));
            type.Items.Insert(1, new ListItem("平台充值", "平台充值"));
            //type.Items.Insert(2, new ListItem("充值规则", "充值规则"));
            //type.Items.Insert(3, new ListItem("积分规则", "积分规则"));
            //type.Items.Insert(4, new ListItem("批量发卡", "批量发卡"));
            type.Items.Insert(2, new ListItem("密码重设", "密码重设"));
            //type.Items.Insert(6, new ListItem("在线转账", "在线转账"));
            type.Items.Insert(3, new ListItem("卡片挂失", "卡片挂失"));
            type.Items.Insert(4, new ListItem("卡片解挂", "卡片解挂"));
            type.Items.Insert(5, new ListItem("用户登录", "用户登录"));
            type.Items.Insert(6, new ListItem("会员销卡", "会员销卡")); 
            type.Items.Insert(7, new ListItem("卡片激活", "卡片激活"));
            type.Items.Insert(8, new ListItem("删除操作", "删除操作"));
            type.Items.Insert(9, new ListItem("添加收费", "添加收费"));
            type.Items.Insert(10, new ListItem("更新收费", "更新收费"));
        }
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的日志信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Log o = ParameterBindHelper.BindParameterToObject(typeof(tb_Log), BindParameterUsage.OpQuery) as tb_Log;

        if (operate_date_begin.Value != "" && operate_date_end.Value != "")
        {
            o.operate_date_begin = operate_date_begin.Value + " 00:00:00";
            o.operate_date_end = operate_date_end.Value + " 23:59:60";
        }
        else if (operate_date_begin.Value != "" && operate_date_end.Value == "")
        {
            o.operate_date_begin = operate_date_begin.Value + " 00:00:00";
        }
        else if (operate_date_begin.Value == "" && operate_date_end.Value != "")
        {
            o.operate_date_end = operate_date_end.Value + " 23:59:60";
        }

        o.flag = true;
        e.InputParameters[0] = o;
    }
}
