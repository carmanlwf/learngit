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
using Ims.Card.Model;
using Ims.Log.BLL;
using Ims.Log.Model;
using Ims.Card.BLL;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Web;

public partial class Card_CardChargeRule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        card_chargerule o = ParameterBindHelper.BindParameterToObject(typeof(card_chargerule), BindParameterUsage.OpQuery) as card_chargerule;
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
            WebClientHelper.DoClientMsgBox("没有满足条件的信息!");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    card_chargerule o = new card_chargerule();
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;//卡号
                    o.ruleid = id;
                    if (CardRuleHelperBLL.DeleteObject(o)>0)
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
                    log.logmsg = log.operater + "对会员卡进行删除操作,成功删除" + count + "条数据记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "对会员卡进行删除操作,成功删除数据" + count + "条记录!" + "未能删除" + sum + "条记录! 原因是这些卡正在处于使用状态,系统默认不能删除!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!" + "未能删除  " + sum + "条记录! 原因是这些卡正在处于使用状态,系统默认不能删除!");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败,原因是这些卡都处于正常使用中，系统默认不能删除!");
            }
        }
    }
}

