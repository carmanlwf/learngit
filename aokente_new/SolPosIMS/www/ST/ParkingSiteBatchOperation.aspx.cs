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
using Ims.Site.BLL;
using Ims.Site.Model;
using ZsdDotNetLibrary.Data;

public partial class ST_ParkingSiteBatchOperation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,manager,seller,channel") == "")
        {

            Response.Redirect("../Unauthorized.aspx");
        }
        Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
        Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site");
        }
    }
    public void InsertSites()
    {
        DataTable dt = new DataTable("dt_batchInsert_spots");
        dt.Columns.Add("parkingid");
        dt.Columns.Add("siteid");
        dt.Columns.Add("parkingname");
        dt.Columns.Add("lat");
        dt.Columns.Add("lon");
        dt.Columns.Add("magicid");
        dt.Columns.Add("isbusy");
        dt.Columns.Add("femaleonly");
        dt.Columns.Add("currentcarnum");
        dt.Columns.Add("ishidden");
        dt.Columns.Add("addtime");
        dt.Columns.Add("updatetime");
        dt.Columns.Add("opt_user");
        dt.Columns.Add("flag");

        if(string.IsNullOrEmpty(parkingid.Value.Trim())||string.IsNullOrEmpty(parksiteCount.Value.Trim()))
            return;
        int parkingsite_count = 0;//要添加的车位数(整型，取值范围1-999)
        int pn_num_start = 0;//起始序号(仅为数字)
        string pn_pre = preNum.Value;//前缀字母或数字(固定)
        string parkingname = "";//入库时的车位自定义编号
        int success_count = 0;//成功添加的个数
        int.TryParse(parkingid.Value.Trim(), out pn_num_start);
        int.TryParse(parksiteCount.Value.Trim(),out parkingsite_count);

        WebHelper.WriteLog("\r\n------------------\r\n", "T1", 1, "total");

        string strParkingId = DateTime.Now.ToString("yyMMddHHmmssfff");

        for (int i = 0; i < parkingsite_count; i++)
        {

            try
            {
                strParkingId = (long.Parse(strParkingId) + 1).ToString();
            }
            catch (Exception e)
            {
                strParkingId = DateTime.Now.ToString("yyMMddHHmmssfff");
            }

            parkingname = pn_pre + addZero(pn_num_start, parksiteCount.Value.Trim().Length);//addZero(pn_num_start.ToString());
            int ret_parking = parkingsiteinfoHelper.IsExistsParkingName(parkingname);
            if (ret_parking <= 0)
            {
                park_parkingsite o = new park_parkingsite();
                o.parkingid = "P" + strParkingId;//DateTime.Now.ToString("yyMMddHHmmssfff");
                o.parkingname = parkingname;
                o.isbusy = 0;
                o.ishidden = false;
                o.magicid = "";
                o.opt_user = Ims.Main.ImsInfo.CurrentUserId;
                o.siteid = Site_Code.SelectedValue;
                o.updatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                o.flag = true;


                try
                {
                    dt.Rows.Add(o.parkingid, o.siteid, o.parkingname, o.lat, o.lon, o.magicid, o.isbusy, o.femaleonly, o.currentcarnum, o.ishidden, o.addtime, o.updatetime, o.opt_user, o.flag);
                }
                catch (Exception e)
                {
                }
                pn_num_start++;
                success_count++;

                //System.Threading.Thread.Sleep(100);

                //WebHelper.WriteLog("i" + i + "\r\n", "T1", 1, "total");
            }
        }
        string msg ="操作失败,请重试!";
        bool ret = parkingsiteinfoHelper.InsertObjects("park_parkingsite", dt);
        if(ret)
        msg = "车位添加操作完成!累计添加:"+success_count+"个";
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

        }

    }
    
    /*
    public string addZero(string parm)
    {
        int len = parkingid.Value.Trim().Length;
        int len_parm = parm.Length;
        while (len < len_parm)
        {
            parm = "0" + parm;
            parkingid.Value = parm;
        }
        return parm;
    }*/

    /**
     * 功能:
     *   用于追加零。
     * 参数:
     *   strSrc 源字符串。
     *   iLen 需要添加到多长。
     * 返回值:
     *   追加零后的字符串。
     **/
    public static string addZero(int iSrc, int iLen)
    {
        string strSrc = "" + iSrc;

        for (int i = strSrc.Length; i < iLen; i++)
        {
            strSrc = "0" + strSrc;
        }

        return strSrc;
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        InsertSites();
    }
    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            //Site_Code.Items.Clear();
            //Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            //Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
    }
}
