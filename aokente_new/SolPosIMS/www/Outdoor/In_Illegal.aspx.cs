using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.Job.Model;
using Ims.Job.BLL;
using ZsdDotNetLibrary.Web;

public partial class Outdoor_In_Illegal : System.Web.UI.Page
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
            igID.Value = Request.QueryString["id"].ToString();
            ControlHelper.SetControlReadonly(igID, true);

            Illegal o = new Illegal();
            o.IgID = igID.Value;
            o.Flag = true;
            o = IllegalBLL.GetPagedObjects(0, 1, "", o)[0];
            o.IgID = igID.Value;
            igCarNumber.Value = o.IgCarNumber;
          
            igPlateImg.Value = o.IgPlateImg;
            igUploadTime.Value = o.IgUploadTime;
            igTerminalCard.Value = o.IgTerminalCard;
            igPoliceIP.Value = o.IgPoliceIP;
           igBodyworkImg.Value = o.IgBodyworkImg;
           igPoliceName.Value = o.IgPoliceName;
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
        Illegal o = new Illegal();
        int num = 0;
        try
        {
            if (!returnCheck(msg.Split(',')))
           {
 
                o.IgCarNumber = Request.Form["igCarNumber"].ToString();
                o.IgPlateImg = Request.Form["igPlateImg"].ToString();
                o.IgUploadTime = Request.Form["igUploadTime"].ToString();
                o.IgTerminalCard = Request.Form["igTerminalCard"].ToString();
                o.IgPoliceIP = Request.Form["igPoliceIP"].ToString();
                o.IgBodyworkImg = Request.Form["igBodyworkImg"].ToString();
                o.IgPoliceName = Request.Form["igPoliceName"].ToString();


                o.Flag = true;
                num = IllegalBLL.InsertObject(o);
            }
        }
        catch (Exception ex)
        {
            msg = ex.ToString();
        }

        if (num > 0 && string.IsNullOrEmpty(msg))
        {
            tb_Log tbl = new tb_Log();
            tbl.logid = "log" + o.IgCarNumber;
            tbl.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tbl.operater = Ims.Main.ImsInfo.CurrentUser.Id;
            tbl.type = "新增收费";
            tbl.flag = true;
            tbl.logmsg = Ims.Main.ImsInfo.CurrentUser.Id + "新增：" + o.IgCarNumber;

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
        Illegal o = new Illegal();
        int num = 0;
        try
        {
            if (!returnCheck(msg.Split(',')))
            {
                o.IgID = igID.Value;
                o.IgCarNumber = Request.Form["igCarNumber"].ToString();
           
                o.IgPlateImg = Request.Form["igPlateImg"].ToString();
                o.IgUploadTime = Request.Form["igUploadTime"].ToString();
                o.IgTerminalCard = Request.Form["igTerminalCard"].ToString();
                o.IgPoliceIP = Request.Form["igPoliceIP"].ToString();
                o.IgBodyworkImg = Request.Form["igBodyworkImg"].ToString();
                o.IgPoliceName = Request.Form["igPoliceName"].ToString();


                o.Flag = true;
                num = IllegalBLL.UpdateObject(o);
            }
        }
        catch (Exception ex)
        {
            msg = ex.ToString();
        }

        if (num > 0 && string.IsNullOrEmpty(msg))
        {
            tb_Log tbl = new tb_Log();
            tbl.logid = "log" + o.IgCarNumber;
            tbl.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tbl.operater = Ims.Main.ImsInfo.CurrentUser.Id;
            tbl.type = "更新收费";
            tbl.flag = true;
            tbl.logmsg = Ims.Main.ImsInfo.CurrentUser.Id + "更新：" + o.IgCarNumber;

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
