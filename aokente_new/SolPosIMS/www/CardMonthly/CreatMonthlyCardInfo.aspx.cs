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
using Ims.Card.BLL;
using Ims.Card.Model;
using Ims.Card.Model.MonthlyCard;
using Ims.Card.BLL.MonthlyCard;

public partial class CardMonthly_CreatMonthlyCardInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindData();
  
        DataTable dataTable = ZsdDotNetLibrary.Data.DataExecSqlHelper.ExecuteQuerySql("select * from tb_CardType where TypeID='" + rbCardType.SelectedValue + "'");

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            bt_Batch.Value = "开通" + dataTable.Rows[0]["TypeName"].ToString();
        }
    }
    public void BindData()
    {
        InitListControlHelper.BindNormalTableToListControl(rbCardType, "TypeID", "TypeName", "tb_CardType", "", "IsMonthlyCard = 1", "");
        rbCardType.SelectedIndex = 0;
        GetCarInfo();
        SetMonthlyCardInfo();
        GetSiteList();
    }
    public void GetSiteList()
    {
        string strSiteList = "";
        DataTable dt = MonthlyCardHelperBLL.GetSiteListInfo();
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string siteid = dr["siteid"].ToString();
                string sitename = dr["sitename"].ToString();
                strSiteList += "<div class=\"item\" id=\"1\">";
                strSiteList += "<label title=\"" + sitename + "\" class=\"titem\"><input  type=\"checkbox\" value=\"" + siteid + "\"  title=\"" + sitename + "\" class=\"b\" />" + sitename + "</label> ";
                strSiteList += "<div class=\"sitem\"></div></div>";
            }
        }
        else
        {
            strSiteList = "No data display!";
        }
        ltSiteList.Text = strSiteList;
    }
    public void GetCarInfo()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["carnum"]))
        {
            string carnum = Request.QueryString["carnum"];
            tb_Card o = CardHelperBLL.GetObject(carnum);
            if (o != null)
            {
               
                ltcarnum.Text = carnum;
                RealName.Value = o.RealName;
                CellPhone.Value = o.CellPhone;
            }
            else 
            {
                ltcarnum.Text = carnum;
                RealName.Value = "";
                CellPhone.Value = "";
            }
        }
        else
        {
            Common.ShowDialogWin(this.Page, this, "获取车牌号失败!");
        }


    }
    protected void bt_Create_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(RealName.Value.Trim()))
        {
            Common.ShowDialogWin(this.Page, this, "姓名不能为空!");
            return;
        }
        if (!allSites.Checked && string.IsNullOrEmpty(citycategory.Value.Trim()))
        {
            Common.ShowDialogWin(this.Page, this, "停放路段不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(CellPhone.Value.Trim()))
        {
            Common.ShowDialogWin(this.Page, this, "联系电话不能为空!");
            return;
        }
        MonthlyCardCreate o = new MonthlyCardCreate();
        o.typeid = rbCardType.SelectedValue;
        o.carnum = ltcarnum.Text;
        o.cellphone = CellPhone.Value;
        o.monthlyamount = decimal.Parse(lbMonthlyCardPrice.Text);
        o.realname = RealName.Value;
        o.balance = 0 ;
        o.uptotime = lbUptotime.Text;
        if (allSites.Checked)
        {
            o.Sections = "1";
            //o.supportSites = "";
        }
        else
        {
            o.supportSites = citycategory.Value;
            //o.Sections = "";
        }
		DataTable dataTable = ZsdDotNetLibrary.Data.DataExecSqlHelper.ExecuteQuerySql("select * from tb_CardType where TypeID='" + rbCardType.SelectedValue + "'");
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
	        string ret = MonthlyCardHelperBLL.MonthlyCardCreate(o,Ims.Main.ImsInfo.CurrentUserId);
	        string mess = "";
	        if (ret == "0")
	            mess = "创建" + dataTable.Rows[0]["TypeName"].ToString()+"成功";
	        else
	            mess = "操作失败,请重试!";
	        Common.ShowDialogWin(this.Page, this, mess);
		}
    }
    protected void rbCardType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetMonthlyCardInfo();
    }
    public void SetMonthlyCardInfo()
    {
        MonthlyCardTypeInfo o = new MonthlyCardTypeInfo();
        o = tb_CardTypeBLL.GetMonthCardTypeInfo(rbCardType.SelectedValue);
        if (o != null)
        {
            lbMonthlyCardPrice.Text = o.price.ToString();
            if (o.IsDayCard == true)
            {
                lbUptotime.Text = DateTime.Now.Date.AddDays((int)o.months).ToString("yyyy-MM-dd 23:59:59");
            }
            else 
            { 
                lbUptotime.Text = DateTime.Now.Date.AddMonths((int)o.months).ToString("yyyy-MM-dd 23:59:59");
            }
            
        }
        else
        {
            Common.ShowDialogWin(this.Page, this, "未找到对应的月卡类型!");
        }
    }
}
