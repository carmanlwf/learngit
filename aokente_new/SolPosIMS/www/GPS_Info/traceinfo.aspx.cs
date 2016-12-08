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
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Web;
using Ims.Main.BLL;

public partial class GPS_Info_traceinfo : System.Web.UI.Page
{

    public string[,] refPoints = new string[2, 2];
    public DataTable dt_Points = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //GetPointsDataByPossnr("", "15", DateTime.Now.Date.ToString("yyyy-MM-dd"));
        if (!Page.IsPostBack)
        {
            BindMapData();
        }
    }
    public void BindMapData()
    {
        InitListControlHelper.BindNormalTableToListControl(list_operator, "operatorid", "name", "tb_Pos_Operator", "", "", "");
        if (!string.IsNullOrEmpty(Request.QueryString["opid"]))
        {
            string opid = Request.QueryString["opid"].ToString();
            list_operator.SelectedIndex = list_operator.Items.IndexOf(list_operator.Items.FindByValue(opid));
            GetPointsDataByPossnr("", opid, DateTime.Now.Date.ToString("yyyy-MM-dd"));
        }
    }
    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        if (start_date_begin.Value == "")
        {
            start_date_begin.Value = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }
        GetPointsDataByPossnr("", list_operator.SelectedValue, start_date_begin.Value);
    }
    /// <summary>
    /// 根据条件查询gps集合
    /// </summary>
    /// <param name="possnr"></param>
    /// <param name="uid"></param>
    /// <param name="starttime"></param>
    /// <param name="endtime"></param>
    public void GetPointsDataByPossnr(string possnr, string uid, string starttime)
    {
        //if (string.IsNullOrEmpty(possnr))
        //    possnr = "001";
        string strSql = "SELECT DISTINCT lng,lat,logtime FROM pos_tracelist";
        strSql += " WHERE 1=1 ";
        if (!string.IsNullOrEmpty(possnr))
            strSql += "AND possnr = '" + possnr + "'";
        if (!string.IsNullOrEmpty(uid))
            strSql += "AND operatorid = '" + uid + "'";
        if (!string.IsNullOrEmpty(starttime))
            strSql += "AND LEFT(logtime,10) = '" + starttime + "'";
        strSql += " ORDER BY logtime asc";
        dt_Points = DataExecSqlHelper.ExecuteQuerySql(strSql);
        if (dt_Points != null && dt_Points.Rows.Count > 0)
        {
            refPoints[0, 0] = dt_Points.Rows[0]["lng"].ToString();
            refPoints[0, 1] = dt_Points.Rows[0]["lat"].ToString();
            refPoints[1, 0] = dt_Points.Rows[dt_Points.Rows.Count - 1]["lng"].ToString();
            refPoints[1, 1] = dt_Points.Rows[dt_Points.Rows.Count - 1]["lat"].ToString();
        }
        else
        {
            refPoints[0, 0] = ConfigParmsInfo.mapPositionXY.longitude;
            refPoints[0, 1] = ConfigParmsInfo.mapPositionXY.latitude;
            refPoints[1, 0] = ConfigParmsInfo.mapPositionXY.longitude;
            refPoints[1, 1] = ConfigParmsInfo.mapPositionXY.latitude;
            dt_Points.Rows.Add(refPoints[0, 0], refPoints[0, 1]);
            dt_Points.Rows.Add(refPoints[1, 0], refPoints[1, 1]);
            WebClientHelper.DoClientMsgBox("暂无相关的坐标记录!");
        }
    }
    protected void btnRtn_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("operator_list.aspx");
    }
}