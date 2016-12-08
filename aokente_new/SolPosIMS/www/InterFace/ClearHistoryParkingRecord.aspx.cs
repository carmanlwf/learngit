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

public partial class InterFace_ClearHistoryParkingRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void ClearParkingRecord()
    {
        string strSql = "Update ";
        DataExecSqlHelper.ExecuteNonQuerySql(strSql);
    }

}
