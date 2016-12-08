using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Web;
using Ims.Pos.Model;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.Pos.BLL;

public partial class Report_Con_banners : System.Web.UI.Page
{
    Ims_Config o = new Ims_Config();
    List<Ims_Config> lc = null;
    int num = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        loadData();
    }
  
    public void loadData()
    {
       lc = Ims_ConfigBLL.GetPagedObjects(0, 1, "", o);
        if (lc != null && lc.Count > 0)
        {
            num = 1;
            Banners.Value = lc[0].Banners;
        }
    }

    public void JsMsg(string text)
    {
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>Msg('" + text + "');</script>");
        }
    
    }
  
    protected void btnNew_Confirm(object sender, EventArgs e)
    {
       o.SysName = lc[0].SysName;
       o.DomainName = lc[0].DomainName;
       o.SiteIp = lc[0].SiteIp;
       o.Banners = Request.Form["Banners"];
       try
       {
           int leng = System.Text.Encoding.Default.GetBytes(o.Banners.ToCharArray()).Length;
           if (leng > 50)
           {
               JsMsg("输入太长，只能是50是个字符!");
           }
           else
           {
               if (num != 1)
               {
                   Ims_ConfigBLL.InsertObject(o);
                   WriteLoginLog("小票增加");
               }
               else
               {
                   Ims_ConfigBLL.UpdateObject(o);
                   WriteLoginLog("小票修改");
               }
               loadData();
           }
       }
       catch (Exception ex)
       { }
        
    }
    public void WriteLoginLog(string operation)
    {
        tb_Log log = new tb_Log();
        log.logid = DateTime.Now.ToString("yyMMddhhmmssfff");
        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        log.operater = Ims.Main.ImsInfo.CurrentUserId;
        log.type = operation;
        log.logmsg = "用户:" + Ims.Main.ImsInfo.CurrentUserId + "于" + log.operate_date + "登录系统.客户端IP:" + Request.UserHostAddress + "客户端名称:" + Request.UserHostName + "代理信息:" + Request.UserAgent;
        log.flag = true;
        LogHelperBLL.InsertObject(log);
        JsMsg(operation + "成功!");
    }


}
    
