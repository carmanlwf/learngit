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
using Ims.Admin.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Admin.Model;
using Ims.Main;

public partial class Admin_SystemParameter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!ImsInfo.UserIsInRole("admin_syspara"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        //初始化风格
        GridViewHelper.InitDefaultGridViewEvent(gvPara, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (!e.ExecutingSelectCount)
        {
            SysParaData sheetRoleInfo = new SysParaData();
            e.InputParameters[0] = sheetRoleInfo;
        }
    }
    protected void gvPara_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (e.OldValues != null && e.OldValues.Count > 0 && e.NewValues != null && e.NewValues.Count > 1)
        {
            string msg = ValidateValue(e);
            if (!string.IsNullOrEmpty(msg))
            {
                WebClientHelper.DoClientMsgBox("保存失败!\r\n" + msg);
                e.Cancel = true;
                
            }
        }
    }

    private string ValidateValue(GridViewUpdateEventArgs e)
    {
        string code = e.OldValues[0].ToString().Trim();
        string value = e.NewValues[1].ToString().Trim();
        if (value.Length > 32) return "参数值不能大于32个字符、汉字";
        string retunvalue = "";
        switch (code)
        {
            case "querylistnum":
                try
                {
                    int temp = Convert.ToInt32(value);
                }
                catch
                {
                    retunvalue = "请输入整数类型！";
                }
                break;
            case "loginflag":
                if (value == "0" || value == "1")
                {
                    ;
                }
                else
                {
                    retunvalue = "只能输入1或0，1代表是；0代表否！";
                }
                break;
            case "logoutflag":
                if (value == "0" || value == "1")
                {
                    ;
                }
                else
                {
                    retunvalue = "只能输入1或0，1代表是；0代表否！";
                }
                break;
            case "telblackflag":
                if (value == "0" || value == "1")
                {
                    ;
                }
                else
                {
                    retunvalue = "只能输入1或0，1代表是；0代表否！";
                }
                break;
            case "insurblackflag":
                if (value == "0" || value == "1")
                {
                    ;
                }
                else
                {
                    retunvalue = "只能输入1或0，1代表是；0代表否！";
                }
                break;
            case "operblackflag":
                if (value == "0" || value == "1")
                {
                    ;
                }
                else
                {
                    retunvalue = "只能输入1或0，1代表是；0代表否！";
                }
                break;
        }
        return retunvalue;
    }
    protected void gvPara_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        
        string code = e.OldValues[0].ToString().Trim();
        if (!string.IsNullOrEmpty(code))
        {
            if (code == "querylistnum" || code == "telblackflag" || code == "insurblackflag" || code == "operblackflag" || code == "onlineoperator")
            {
                //重新初始化核心业务
                //NewWebServiceHelper.InitBizParaAgain();
            }
        }
    }
}
