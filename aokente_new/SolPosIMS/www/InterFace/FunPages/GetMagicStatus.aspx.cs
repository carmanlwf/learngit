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
using System.Text;
using Newtonsoft.Json;

public partial class InterFace_FunPages_GetMagicStatus : System.Web.UI.Page
{

    StringBuilder sb_Log = new StringBuilder();
    string LogId = "Magic_Log" + DateTime.Now.ToString("HHmmssfff");//Logid
    string PosId = "Defalut";
    string Pos370 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        WebHelper.SetNoCache();//设置不缓存
        AnalyzingData();

    }


    public void AnalyzingData()
    {
        string RetStr = "";//返回POS的字符串
        try
        {
            //RetStr = JavaScriptConvert.SerializeObject(CommunicationHelperBLL.GetParkingSiteStatus());
            RetStr = CommunicationHelperBLL.GetParkingSiteStatus();
        }
        catch (Exception ex)
        {
            sb_Log.Append(ex.Message);
        }
        finally
        {

            sb_Log.Append("[" + DateTime.Now.ToString() + "] 返回的字符串：Rtn：" + RetStr + "\r\n");
            sb_Log.Append("[" + DateTime.Now.ToString() + "] Rtn加密：" + RetStr + "\r\n");
            sb_Log.Append("客户端名称：" + Request.UserHostName + "\r\n");
            sb_Log.Append("客户端IP：" + Request.UserHostAddress + "\r\n");
            sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");

            WebHelper.WriteLog(sb_Log.ToString(), PosId, 1, "magic");

            //WebHelper.OutPutRetStr(RetStr);//输出到pos端
           
        }
    }
}
