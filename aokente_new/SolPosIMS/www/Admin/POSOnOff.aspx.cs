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
using ZsdDotNetLibrary.Web;

public partial class Admin_POSOnOff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            bool TerminalISTrue = WebHelper.GetEnablePosTerminal();
            if (TerminalISTrue == true)
            {
                RadioTerminalOn.Checked = true;
            }
            else
            {
                RadioTerminalOff.Checked = true;
            }

            bool PosChargeIsTrue = WebHelper.GetEnablePosCharge();
            if (PosChargeIsTrue == true)
            {
                RadioChargeOn.Checked = true;
            }
            else
            {
                RadioChargeOff.Checked = true;
            }
        }
    }
    protected void ButtOK_ServerClick(object sender, EventArgs e)
    {
        if (RadioTerminalOn.Checked == true && RadioChargeOn.Checked == true)
        {
           if (WebHelper.Up_Ims_Config_EnablePosTerminalandEnablePosCharge(1,1)>0)
           {
               WebClientHelper.DoClientMsgBox("更新成功!");
                return;
           }
        }
        if (RadioTerminalOn.Checked == true && RadioChargeOff.Checked == true)
        {
            if (WebHelper.Up_Ims_Config_EnablePosTerminalandEnablePosCharge(1, 0) > 0)
            {
                WebClientHelper.DoClientMsgBox("更新成功!");
                return;
            }
        }
        if (RadioTerminalOff.Checked == true && RadioChargeOn.Checked == true)
        {
            if (WebHelper.Up_Ims_Config_EnablePosTerminalandEnablePosCharge(0, 1) > 0)
            {
                WebClientHelper.DoClientMsgBox("更新成功!");
                return;
            }
        }
        if (RadioTerminalOff.Checked == true && RadioChargeOff.Checked == true)
        {
            if (WebHelper.Up_Ims_Config_EnablePosTerminalandEnablePosCharge(0, 0) > 0)
            {
                WebClientHelper.DoClientMsgBox("更新成功!");
                return;
            }
        }
    }

 }
