<%@ WebHandler Language="C#" Class="ShitStuffDuty" %>

using System;
using System.Web;

public class ShitStuffDuty : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        string ret = ""; 
        string tid = "t" + DateTime.Now.ToString("yyMMddHHmmssfff");
        string dt1 = "";
        string dt2 = "";
        int zccount = 0;
        int kcount = 0;
        decimal zcmoney = 0;
        decimal kmoney = 0;
        decimal moneysum = 0;
        decimal vipamount = 0;
        int vipcount = 0;
        try
        {
            System.Data.DataTable dt_batchinfo = (System.Data.DataTable)Ims.Card.BLL.BatchHelperBLL.GetBatchStatus();
            if (dt_batchinfo != null && dt_batchinfo.Rows.Count > 0)
            {
                dt1 = dt_batchinfo.Rows[0]["starttime"] != null ? dt_batchinfo.Rows[0]["starttime"].ToString() : "";
                dt2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Ims.Card.Model.card_chargelist cc = new Ims.Card.Model.card_chargelist();
                cc.operid = Ims.Main.ImsInfo.CurrentUserId;
                cc.OperateDate1 = dt1;
                cc.OperateDate2 = dt2;
                
                System.Data.DataTable dt_batchstatics = Ims.Card.BLL.CardChargeListBLL.ChargeListStaticsByOperator(cc);
  
                if (dt_batchstatics != null && dt_batchstatics.Rows.Count > 0)
                {
                    zccount = int.Parse(dt_batchstatics.Rows[0]["ZCCount"].ToString());
                    kcount = int.Parse(dt_batchstatics.Rows[0]["KCount"].ToString());
                    zcmoney = decimal.Parse(dt_batchstatics.Rows[0]["ZCMoney"].ToString());
                    kmoney = decimal.Parse(dt_batchstatics.Rows[0]["KMoney"].ToString());
                    moneysum = decimal.Parse(dt_batchstatics.Rows[0]["ZCMoney"].ToString()) - decimal.Parse(dt_batchstatics.Rows[0]["KMoney"].ToString());
                    vipamount = decimal.Parse(dt_batchstatics.Rows[0]["VipAmount"].ToString());
                    vipcount = int.Parse(dt_batchstatics.Rows[0]["VipCount"].ToString());
                    
                }
            }
        }
        catch (Exception ex)
        {
            WebHelper.Record(WebHelper.错误日志, ex.Message);
        }
        finally
        {
            //int result = Ims.Card.BLL.BatchHelperBLL.InsertBatchRecordByOperator(tid, Ims.Main.ImsInfo.CurrentUserId, dt1, dt2, zccount, zcmoney, kcount, kmoney, moneysum);
            //int flag = 0;
            
            //flag = Ims.Card.BLL.BatchHelperBLL.DeleteLastRecord();//删除batchstatus记录 
            bool result = Ims.Card.BLL.BatchHelperBLL.BatchingByOperator(tid, Ims.Main.ImsInfo.CurrentUserId, dt1, dt2, zccount, zcmoney, kcount, kmoney, moneysum,vipcount,vipamount);
                
                if(result)
                ret = "0";
            else
                ret = "";
            context.Response.Write(ret);
        }
    
        
        //context.Response.ContentType = "text/plain";

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}