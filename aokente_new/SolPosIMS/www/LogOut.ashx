<%@ WebHandler Language="C#" Class="LogOut" %>

using System;
using System.Web;

public class LogOut : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string ret = "";
        try
        {
            System.Data.DataTable dt_batchinfo = (System.Data.DataTable)Ims.Card.BLL.BatchHelperBLL.GetBatchStatus();
            if (dt_batchinfo != null && dt_batchinfo.Rows.Count > 0)
            {
                string dt1 = dt_batchinfo.Rows[0]["starttime"] != null ? dt_batchinfo.Rows[0]["starttime"].ToString() : "";
                string dt2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Ims.Card.Model.card_chargelist cc = new Ims.Card.Model.card_chargelist();
                cc.operid = Ims.Main.ImsInfo.CurrentUserId;
                cc.OperateDate1 = dt1;
                cc.OperateDate2 = dt2;

                System.Data.DataTable dt_batchstatics = Ims.Card.BLL.CardChargeListBLL.ChargeListStaticsByOperator(cc);
                if (dt_batchstatics != null && dt_batchstatics.Rows.Count > 0)
                {
                    ret = "交班信息：\r\n";
                    ret += "---------------------------\r\n";
                    ret += "营业员工号:" + Ims.Main.ImsInfo.CurrentUserId + "\r\n\r\n";
                    ret += "接班时间:" + dt1 + "\r\n";
                    ret += "交班时间:" + dt2 + "\r\n\r\n";
                    ret += "累计充值笔数:" + dt_batchstatics.Rows[0]["ZCCount"] + "笔\r\n";
                    ret += "累计充值金额:" + dt_batchstatics.Rows[0]["ZCMoney"] + "元\r\n\r\n";
                    ret += "累计退款笔数:" + dt_batchstatics.Rows[0]["KCount"] + "笔\r\n";
                    ret += "累计退款金额:" + dt_batchstatics.Rows[0]["KMoney"] + "元\r\n\r\n";
                    ret += "累计营收金额:" + (decimal.Parse(dt_batchstatics.Rows[0]["ZCMoney"].ToString()) - decimal.Parse(dt_batchstatics.Rows[0]["KMoney"].ToString())).ToString() + "元\r\n";
                }
                else
                {
                    ret = "交班信息：\r\n";
                    ret += "---------------------------\r\n";
                    ret += "营业员工号:" + Ims.Main.ImsInfo.CurrentUserId + "\r\n\r\n";
                    ret += "接班时间:" + dt1 + "\r\n";
                    ret += "交班时间:" + dt2 + "\r\n\r\n";
                    ret += "累计充值笔数:0笔\r\n";
                    ret += "累计充值金额:0元\r\n\r\n";
                    ret += "累计退款笔数:0笔\r\n";
                    ret += "累计退款金额:0元\r\n\r\n";
                    ret += "累计营收金额:0元\r\n";
                }
            }
        }
        catch (Exception ex)
        {
            WebHelper.Record(WebHelper.错误日志, ex.Message);
        }
        finally
        {
            context.Response.Write(ret);
        }
    
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}