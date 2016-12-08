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
using ZsdDotNetLibrary.Data;
using System.Collections.Generic;
using System.IO;

public partial class ReportViewer_DataBackUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,small,maintenance") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }

    }

    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(date_end.Value.Trim()))
        {
            //WebClientHelper.DoClientMsgBox("截止时间不能为空");
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "alert('截止时间不能为空');", true);
            return;
        }
        if (dataBackUp() < 0)
            //WebClientHelper.DoClientMsgBox("数据备份失败");
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "alert('数据备份失败');", true);
        else
            //WebClientHelper.DoClientMsgBox("数据备份成功");
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "alert('数据备份成功');", true);

    }

    protected void btnClear_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(date_end.Value.Trim()))
        {
            //WebClientHelper.DoClientMsgBox("截止时间不能为空");
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "alert('截止时间不能为空');", true);
            return;
        }
        dataCleanUp();
        //WebClientHelper.DoClientMsgBox("数据清除成功");
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "alert('数据清除成功');", true);
    }

    public int dataBackUp()
    {
        //string strSql = "truncate table RoadParking_Bak.dbo.tb_log truncate table RoadParking_Bak.dbo.tb_pos_transaction truncate table RoadParking_Bak.dbo.pay_paydetail truncate table RoadParking_Bak.dbo.tb_Pos_Operator truncate table RoadParking_Bak.dbo.tb_Operator_Schedule truncate table RoadParking_Bak.dbo.tb_Site truncate table RoadParking_Bak.dbo.pos_tracelist";
        string strSql = "if object_id(N'RoadParking_Bak.dbo.tb_log',N'U') is not null drop table RoadParking_Bak.dbo.tb_log";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "if object_id(N'RoadParking_Bak.dbo.tb_pos_transaction',N'U') is not null drop table RoadParking_Bak.dbo.tb_pos_transaction";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "if object_id(N'RoadParking_Bak.dbo.pay_paydetail',N'U') is not null drop table RoadParking_Bak.dbo.pay_paydetail";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "if object_id(N'RoadParking_Bak.dbo.tb_Pos_Operator',N'U') is not null drop table RoadParking_Bak.dbo.tb_Pos_Operator";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "if object_id(N'RoadParking_Bak.dbo.tb_Operator_Schedule',N'U') is not null drop table RoadParking_Bak.dbo.tb_Operator_Schedule";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "if object_id(N'RoadParking_Bak.dbo.tb_Site',N'U') is not null drop table  RoadParking_Bak.dbo.tb_Site";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "if object_id(N'RoadParking_Bak.dbo.pos_tracelist',N'U') is not null drop table  RoadParking_Bak.dbo.pos_tracelist";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "select * into RoadParking_Bak.dbo.tb_log from tb_log where operate_date < '" + date_end.Value.Trim() + "'";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

//        strSql = "insert into RoadParking_Bak.dbo.tb_pos_transaction(PosSnr,siteid,sitename,BatchSnr,CredenceSnr,Magcard,CardSnr,UserID,PIN,Money,RealMoney,Datetime,Mode,RecordType,CardType,OrderID," +
//"flag,SysID,TransType,giving,logtime,DisMoney,DisCard,TStatus,Point,BeforeBalance,AfterBalance," + 
//"StartTime,EndTime,sumMins,BackByte,carpicture,update_timestamp,memo,ReturnMoney,isClear,isAutoOut,exceptionflag) select PosSnr,siteid,sitename,BatchSnr,CredenceSnr,Magcard,CardSnr,UserID,PIN,Money,RealMoney,Datetime,Mode,RecordType,CardType,OrderID," + 
//"flag,SysID,TransType,giving,logtime,DisMoney,DisCard,TStatus,Point,BeforeBalance,AfterBalance," + 
//"StartTime,EndTime,sumMins,BackByte,carpicture,update_timestamp,memo,ReturnMoney,isClear,isAutoOut,exceptionflag from tb_pos_transaction where endtime < '" + date_end.Value.Trim() + "'";
        strSql = "select * into RoadParking_Bak.dbo.tb_pos_transaction from tb_pos_transaction where endtime < '" + date_end.Value.Trim() + "'";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "select * into RoadParking_Bak.dbo.pay_paydetail from pay_paydetail where tradetime < '" + date_end.Value.Trim() + "'";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "select * into RoadParking_Bak.dbo.tb_pos_operator from tb_pos_operator ";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "select * into RoadParking_Bak.dbo.tb_operator_schedule from tb_operator_schedule where addtime < '" + date_end.Value.Trim() + "'";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "select * into RoadParking_Bak.dbo.tb_Site from tb_Site";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }

        strSql = "select * into RoadParking_Bak.dbo.pos_tracelist from pos_tracelist where logtime < '" + date_end.Value.Trim() + "'";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }
        string p = HttpContext.Current.Server.MapPath("~//backup");
        if (!Directory.Exists(p))
            Directory.CreateDirectory(p);
        strSql = "backup database RoadParking_Bak to disk='" + p + "//" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".bak'";
        try
        {
            DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
        catch (Exception e)
        {
            WebClientHelper.DoClientMsgBox(e.Message);
            return -1;
        }
        return 0;
    }

    public void dataCleanUp()
    {
        string strSql = "delete from tb_log where operate_date < '" + date_end.Value.Trim() + "'";
        DataExecSqlHelper.ExecuteNonQuerySql(strSql);

        strSql = "delete from tb_pos_transaction where endtime < '" + date_end.Value.Trim() + "'";
        DataExecSqlHelper.ExecuteNonQuerySql(strSql);

        strSql = "delete from pay_paydetail where tradetime < '" + date_end.Value.Trim() + "'";
        DataExecSqlHelper.ExecuteNonQuerySql(strSql);

        strSql = "delete from tb_operator_schedule where addtime < '" + date_end.Value.Trim() + "'";
        DataExecSqlHelper.ExecuteNonQuerySql(strSql);

        strSql = "delete from pos_tracelist where logtime < '" + date_end.Value.Trim() + "'";
        DataExecSqlHelper.ExecuteNonQuerySql(strSql);
    }
}
