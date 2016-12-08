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
using Ims.Main;
using NewSoftDotNetLibrary.Web;
using Ims.Site.BLL;
using Ims.Member.BLL;
using System.Web.UI.MobileControls;
using ZsdDotNetLibrary.Data;
using System.Collections.Generic;
using System.Text;
using Ims.Main.BLL;

public partial class Notice_NoticeBoard : System.Web.UI.Page
{
    public static int colorFlag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel,manager") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            BindData();
            BindConfigParms();
        }
    }
    public void BindData()
    {
        List<objectRets> objRets = GetStaticsRets();
        StringBuilder sb = new StringBuilder();
        if (objRets != null && objRets.Count > 0)
        {

            foreach (objectRets obj in objRets)
            {
                string [] colors = GetMyColor().Split(',');
                string color_bg = colors[0];
                string color_fg = colors[1];
                string str = "<div class=\"skillbar clearfix \" data-percent=\"" + obj.Busyrate + "%\"><div class=\"skillbar-title\" style=\"background: " + colors[0] + ";\"><span>" + obj.sitename + "(" + obj.sumBusy + "/" + obj.sumParkingSites + ")" + "</span></div><div class=\"skillbar-bar\" style=\"background: " + colors[1] + ";\"></div>	<div class=\"skill-bar-percent\">车位使用率:" + obj.Busyrate + "%" + "</div></div> <!-- End Skill Bar -->";
                sb.Append(str);
            }

            this.ParkingStatics.Text = sb.ToString();
        }
    }
    public void BindConfigParms()
    {
        //车位模式
        bool IsHasSpot = false;
        IsHasSpot = ConfigParmsInfo.IsHasSpot;
        lbSpot.Text = IsHasSpot ? "随机车位" : "随机车位";
        //自动签退
        bool IsAutoSign = false;
        IsAutoSign = ConfigParmsInfo.IsAutoSignOut;
        lbAutoSign.Text = IsAutoSign ? "开启" : "关闭";
        //是否有图
        bool IsHasPic = false;
        IsHasPic = ConfigParmsInfo.IsOpenPic;
        lbPic.Text = IsHasPic ? "有图模式" : "无图模式";
        //是否写日志
        bool IsTradeLog = false;
        IsTradeLog = ConfigParmsInfo.IsTradeLog;
        lbTradeLog.Text = IsTradeLog ? "开启" : "关闭";

    }
    public string GetMyColor()
    {
        if (colorFlag >= 6)
            colorFlag = 0;
        string[] colors = { "#d35400,#e67e22", "#2980b9,#3498db", "#2c3e50,#3E5678", "#46465e,#5a68a5", "#333333,#525252", "#27ae60,#2ecc71", "#124e8c,#4288d0" };
        ++colorFlag;
        return colors[colorFlag];
    }
    /// <summary>
    /// 返回统计结果对象objectRets
    /// </summary>
    /// <returns></returns>
    public List<objectRets> GetStaticsRets()
    {
        string strSql = "SELECT ISNULL(x.siteid,'') as siteid,x.sumBusy,x.sumParkingSites,Convert(decimal(18,2),x.sumBusy *1.0/x.sumParkingSites*100) as Busyrate,ISNULL(y.sitename,'') as sitename FROM (SELECT a.siteid, COUNT(1) as sumParkingSites ,SUM(CASE ISNULL(a.isbusy,0) WHEN 1 THEN 1 ELSE 0 END) as sumBusy FROM park_parkingsite as a GROUP BY siteid) as x LEFT JOIN (SELECT b.id,b.sitename FROM tb_site as b) as y ON x.siteid = y.id";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        List<objectRets> objList = new List<objectRets>();
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                objectRets objects = new objectRets();
                List list = new List();
                objList.Add(new objectRets(dr["siteid"].ToString(),dr["sumBusy"].ToString(),dr["sumParkingSites"].ToString(),dr["Busyrate"].ToString(),dr["sitename"].ToString()));
            }
        }
        return objList;
    }

}
public class objectRets
{
    public objectRets(string siteid,string sumbusy,string sumparkingsites,string busyrate,string sitename)
    {
        this._siteid = siteid;
        this.sumBusy = sumbusy;
        this.sumParkingSites = sumparkingsites;
        this.Busyrate = busyrate;
        this.sitename = sitename;
    }
    public objectRets()
    {
    }
    private string _siteid;
    /// <summary>
    /// 路段编号
    /// </summary>
    public string siteid
    {
        get { return _siteid; }
        set { _siteid = value; }
    }
    private string _sumBusy;
    /// <summary>
    /// 累计占用车位数
    /// </summary>
    public string sumBusy
    {
        get { return _sumBusy; }
        set { _sumBusy = value; }
    }
    private string _sumParkingSites;
    /// <summary>
    /// 累计车位数
    /// </summary>
    public string sumParkingSites
    {
        get { return _sumParkingSites; }
        set { _sumParkingSites = value; }
    }
    private string _Busyrate;
    /// <summary>
    /// 车位占用率
    /// </summary>
    public string Busyrate
    {
        get { return _Busyrate; }
        set { _Busyrate = value; }
    }
    private string _sitename;
    /// <summary>
    /// 路段名称
    /// </summary>
    public string sitename
    {
        get { return _sitename; }
        set { _sitename = value; }
    }
}
