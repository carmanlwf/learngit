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
using Ims.Pay.BLL;

public partial class Pay_showDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            GetCarPicDetail();
    }
    public void GetCarPicDetail()
    {
        string transid = "";
        if (!string.IsNullOrEmpty(Request.QueryString["getcode"]))
        {
            transid = Request.QueryString["getcode"].ToString();
            DataTable dt = PayHelperBLL.GetTradeInfoByPayId(transid);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["carnum"] != null)
            {
                lbCarNum.Text = "车牌号:" + dt.Rows[0]["carnum"].ToString();
                lbContent.Text = dt.Rows[0]["tradecomment"] != null ? dt.Rows[0]["tradecomment"].ToString() : "暂无明细";
            }
        }
    }
}
