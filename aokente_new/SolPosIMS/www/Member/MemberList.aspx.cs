using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Member.Model;
using Ims.PM.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.Member.BLL;
using System.IO;
using System.Data.SqlClient;
using System.Text;
public partial class Member_MemberList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }

        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
            }
            if (Ims.Main.ImsInfo.UserIsInRoles("seller") != "")//销售人员
            {
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;
            }
            if (Ims.Main.ImsInfo.UserIsInRoles("channel") != "")//录入员
            {
                GridView1.Columns[9].Visible = false;
                GridView1.Columns[10].Visible = false;
                btnOut.Visible = false;
            }
        }
    }
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_ServerClick(object sender, EventArgs e)
    {

        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的会员信息!");
        }

    }
    /// <summary>
    /// 绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Member o = ParameterBindHelper.BindParameterToObject(typeof(tb_Member), BindParameterUsage.OpQuery) as tb_Member;
        if (addeddate1.Value != "" && addeddate2.Value != "")
        {
            o.addeddate1 = addeddate1.Value + " 00:00:00";
            o.addeddate2 = addeddate2.Value + " 23:59:60";
        }
        if (Ims.Main.ImsInfo.UserIsInRoles("admin") != "")//Admin
        {
            o.id = Request.Form.Get("Site_Code");
        }

        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长 
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId); 
        }

        if (Ims.Main.ImsInfo.UserIsInRoles("seller") != "")//销售人员
        {
            o.GroupID = PmTtBLLHelper.GetManagerGroupID(Ims.Main.ImsInfo.CurrentUserId);//获取当用销售人员所在的组号
        }

        o.flag = true;
        e.InputParameters[0] = o;

    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            tb_Member o = new tb_Member();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.Userid = id;
                    if (MemberHelperBLL.MemberCard_Times(id) > 0)//判断此会员是否正处于有卡状态，大于0则为使用
                    {
                        sum++;
                    }
                    else
                    {
                        int m = Ims.Member.BLL.MemberHelperBLL.DeleteObject(o);
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
                    log.logmsg = log.operater + "对会员进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "对会员进行删除操作,成功删除数据" + count + "条记录!" + "未能删除" + sum + "条记录! 原因是这些此会员正在处于使用中!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!" + "未能删除  " + sum + "条记录! 原因是这些此会员正在处于使用中!");
                }

            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!原因是这些会员都是拥有卡的会员,系统默认不能删除!");
            }
        }
    }

    /// <summary>
    /// 导出表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOut_Click(object sender, EventArgs e)
    {
        string name = string.IsNullOrEmpty(RealName.Value.ToString().Trim()) ? "" : RealName.Value.ToString().Trim();
        string userid = "";
        string card = string.IsNullOrEmpty(Card.Value.ToString().Trim()) ? "" : Card.Value.ToString().Trim();
        string telphone = "";
        string celphone = "";
        string sex = Gender.Value.ToString() == "" ? "" : (Gender.Value.ToString() == "1" ? "男" : "女");
        string data1 = string.IsNullOrEmpty(addeddate1.Value.ToString()) ? "" : addeddate1.Value.ToString() + " 00:00:00";
        string data2 = string.IsNullOrEmpty(addeddate2.Value.ToString()) ? "" : addeddate2.Value.ToString() + " 23:59:60";
        string rank = "";
        string siteid = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            siteid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        DataTable dt = MemberHelperBLL.MemberInfo(name, userid, card, telphone, celphone, sex, rank, data1, data2, siteid);
        StringWriter sw = new StringWriter(); //创建对象
        sw.WriteLine("\t\t\t会员基本信息 ");  //输入标题 
        sw.WriteLine("会员姓名\t会员编号\t会员卡号\t联系电话");//输入字段
        sw.WriteLine(name + "\t" + userid + "\t" + card + "\t" + telphone);
        sw.WriteLine("联系手机\t性别\t注册时间\t会员等级");//输入字段
        sw.WriteLine(celphone + "\t" + sex + "\t" + data1 + "~" + data2 + "\t" + rank);
        sw.Close(); //关闭数据流
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls"); //test.xls导入Excel得文件名
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(sw);
        DataToExcel.CreateExcel(dt, "haojuhaosan");
    }
}

