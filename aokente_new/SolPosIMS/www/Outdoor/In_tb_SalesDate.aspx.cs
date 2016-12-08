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
using ZsdDotNetLibrary.Web.BindParameter;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.Job.Model;
using Ims.Job.BLL;

public partial class In_tb_SalesDate : FormNormalEditPage
{

    protected void Page_Load(object sender, EventArgs e)
    {//权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
     
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            btnUpdate.Visible = true;
            btnInsert.Visible = false;
            rdID.Value = Request.QueryString["id"].ToString();
            ControlHelper.SetControlReadonly(rdID, true);

            RoadDate o = new RoadDate();
            o.RdID = rdID.Value;
            o.Flag = true;
            o = RoadDateBLL.GetPagedObjects(0, 1, "", o)[0];

            rdStopCName.Value =o.RdStopCName;
            rdParkServerIP.Value = o.RdParkServerIP;
            rdLongitude.Value = o.RdLongitude;
            rdlatitude.Value = o.Rdlatitude;
            rdFier.Value =  o.RdFier;
            rdDescription.Value = o.RdDescription;
        }
        else
        {
            btnUpdate.Visible = false;
            btnInsert.Visible = true;

        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        RoadDate o = new RoadDate();
        int num = 0;

        try
        {
            if (!returnCheck(msg.Split(',')))
            {
                o.RdStopCName = Request.Form["rdStopCName"].ToString();
                o.RdParkServerIP = Request.Form["rdParkServerIP"].ToString();
                o.RdLongitude = Request.Form["rdLongitude"].ToString();
                o.Rdlatitude = Request.Form["rdlatitude"].ToString();
                o.RdFier = Request.Form["rdFier"].ToString();
                o.RdDescription = Request.Form["rdDescription"].ToString();
                o.RdCreateTime = o.RdUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                o.Flag = true;
                num = RoadDateBLL.InsertObject(o);
            }
        }
        catch (Exception ex)
        {
            msg = ex.ToString();
        }

        if (num > 0 &&  string.IsNullOrEmpty(msg))
        {
            tb_Log tbl = new tb_Log();
            tbl.logid = "log" + o.RdStopCName;
            tbl.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tbl.operater = Ims.Main.ImsInfo.CurrentUser.Id;
            tbl.type = "新增收费";
            tbl.flag = true;
            tbl.logmsg = Ims.Main.ImsInfo.CurrentUser.Id + "新增：" + o.RdStopCName;

            LogHelperBLL.InsertObject(tbl);

            msg = num + "条新增成功！";
            ClientScriptManager cs = Page.ClientScript;
            Type cstype = this.GetType();
            if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
            {
                cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

            }
        }
        
    }

 

    public bool returnCheck(string[] value)
    {

        for (int i = 0; i < value.Length; i++)
        {
            if (!string.IsNullOrEmpty(value[i]))
            {
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>Check('" + value[i] + "');</script>");

                    return true;
                }
            }
        }
        return false;

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;
        RoadDate o = new RoadDate();
        int num = 0;
        try
        {
            if (!returnCheck(msg.Split(',')))
            {
                o.RdID = rdID.Value;
                o.RdStopCName = Request.Form["rdStopCName"].ToString();
                o.RdParkServerIP = Request.Form["rdParkServerIP"].ToString();
                o.RdLongitude = Request.Form["rdLongitude"].ToString();
                o.Rdlatitude = Request.Form["rdlatitude"].ToString();
                o.RdFier = Request.Form["rdFier"].ToString();
                o.RdDescription = Request.Form["rdDescription"].ToString();
                o.RdUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                o.Flag = true;
            o.Flag = true;
            num = RoadDateBLL.UpdateObject(o);
            }
        }
        catch (Exception ex)
        {
            msg = ex.ToString();
        }

        if (num > 0 && string.IsNullOrEmpty(msg))
            {
                tb_Log tbl = new tb_Log();
                tbl.logid = "log" + o.RdStopCName;
                tbl.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tbl.operater = Ims.Main.ImsInfo.CurrentUser.Id;
                tbl.type = "更新收费";
                tbl.flag = true;
                tbl.logmsg = Ims.Main.ImsInfo.CurrentUser.Id + "更新：" + o.RdStopCName;

                LogHelperBLL.InsertObject(tbl);

                msg = num + "条更新成功！";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");

                }
        }

    }


}
