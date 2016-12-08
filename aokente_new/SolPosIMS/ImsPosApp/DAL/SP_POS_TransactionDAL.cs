using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Ims.Pos.Model;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.DAL
{
    public class SP_POS_TransactionDAL
    {
        /// <summary>
        /// pos交易存储
        /// </summary>
        /// <param name="o">SP_POS_Transaction实体</param>
        /// <param name="OReBatchSnr">返回交易批次号</param>
        /// <param name="OReCredenceSnr">返回交易凭证号</param>
        /// <param name="OBalance">卡上余额</param>
        /// <param name="OIntegral">本次积分</param>
        /// <param name="OTotalInteger">累计积分</param>
        /// <param name="OShopCode">商户编号</param>
        /// <param name="OShopName">商户名称</param>
        /// <param name="OServerWasteSnr">服务器端流水号</param>
        /// <param name="OExpDate">卡有效期</param>
        /// <param name="ORemark">备注信息</param>
        /// <param name="Rstr">返回结果</param>
        /// <returns>DataSet</returns>
        public static DataSet Pos_Trans(
            SP_POS_ALLParams o)
        {
            SqlParameter[] Para = new SqlParameter[]{                 
               new SqlParameter("POSSNR", SqlDbType.VarChar,20), 
               new SqlParameter("@BatchSnr", SqlDbType.BigInt,50),   
               new SqlParameter("@CredenceSnr",SqlDbType.VarChar,30),
               new SqlParameter("@Magcard",SqlDbType.VarChar,16),                  
               new SqlParameter("@CardSnr",SqlDbType.VarChar,16),
               new SqlParameter("@UserID", SqlDbType.Int,4), 
              
               new SqlParameter("@PIN",SqlDbType.VarChar,50),                  
               new SqlParameter("@Money",SqlDbType.Decimal,10),
               new SqlParameter("@Datetime", SqlDbType.VarChar,20), 
               new SqlParameter("@Mode", SqlDbType.Int,4),   
               new SqlParameter("@RecordType",SqlDbType.Int,4),
               new SqlParameter("@CardType",SqlDbType.Int,4), 
             

               new SqlParameter("@ReBatchSnr",SqlDbType.VarChar,30),
               new SqlParameter("@ReCredenceSnr",SqlDbType.VarChar,30),
               new SqlParameter("@Balance",SqlDbType.VarChar,15),
               new SqlParameter("@Integral",SqlDbType.Int),
               new SqlParameter("@TotalInteger",SqlDbType.BigInt),
               new SqlParameter("@ShopCode",SqlDbType.VarChar,20),
               new SqlParameter("@ShopName",SqlDbType.VarChar,50),
               new SqlParameter("@ServerWasteSnr",SqlDbType.VarChar,35),
               new SqlParameter("@ExpDate",SqlDbType.VarChar,20),
               new SqlParameter("@Remark",SqlDbType.VarChar,128),               
               new SqlParameter("Rstr",SqlDbType.Int)
              

            };
            Para[0].Value = string.IsNullOrEmpty(o.POSSNR) ? "" : o.POSSNR;//终端号
            Para[1].Value = o.BATCHSNR.ToString();//交易批次号
            Para[2].Value = string.IsNullOrEmpty(o.CREDENCESNR) ? "" : o.CREDENCESNR;//交易凭证号
            Para[3].Value = string.IsNullOrEmpty(o.CARDSNR) ? "" : o.CARDSNR;//磁条卡卡号 磁条卡已暂停使用暂用CARDSNR替代
            Para[4].Value = string.IsNullOrEmpty(o.CARDSNR) ? "" : o.CARDSNR; //IC卡卡号
            Para[5].Value = o.USERID;
            Para[6].Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(string.IsNullOrEmpty(o.PIN) ? "" : o.PIN, "MD5"); ;//密码

            Para[7].Value = o.MONEY;//交易金额
            Para[8].Value = string.IsNullOrEmpty(o.DATETIME) ? DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") : o.DATETIME.Replace("-", "/");//发生时间
            Para[9].Value = o.MODE;
            Para[10].Value = o.RECORDTYPE;
            Para[11].Value = o.CARDTYPE;//返回交易批次号
            Para[12].Direction = ParameterDirection.Output;//返回交易批次号
            Para[13].Direction = ParameterDirection.Output;//返回交易凭证号
            Para[14].Direction = ParameterDirection.Output;//卡上余额
            Para[15].Direction = ParameterDirection.Output;//本次积分
            Para[16].Direction = ParameterDirection.Output;//累计积分
            Para[17].Direction = ParameterDirection.Output;//商户编号
            Para[18].Direction = ParameterDirection.Output;//商户名称
            Para[19].Direction = ParameterDirection.Output;//服务器端流水号
            Para[20].Direction = ParameterDirection.Output;//卡有效期
            Para[21].Direction = ParameterDirection.Output;//备注信息
            Para[22].Direction = ParameterDirection.ReturnValue;//备用字节

            DataSet ds = SQLHelper.QueryStored("SP_POS_Transaction", CommandType.StoredProcedure, Para);//参数是否缺失
            if (!DBNull.Value.Equals(Para[12].Value))
            {
                o.REBATCHSNR = Convert.ToInt32(Para[12].Value);
            }
            if (!DBNull.Value.Equals(Para[13].Value))
            {
                o.RECREDENCESNR = Para[13].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[14].Value))
            {
                o.BALANCE = Convert.ToDecimal(Para[14].Value);
            }
            if (!DBNull.Value.Equals(Para[15].Value))
            {
                o.INTEGRAL = Convert.ToDecimal(Para[15].Value);
            }
            if (!DBNull.Value.Equals(Para[16].Value))
            {
                o.TOTALINTEGER = Convert.ToDecimal(Para[16].Value);
            }
            if (!DBNull.Value.Equals(Para[17].Value))
            {
                o.SHOPCODE = Para[17].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[18].Value))
            {
                o.SHOPNAME = Para[18].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[19].Value))
            {
                o.SERVERWASTESNR = Para[19].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[20].Value))
            {
                o.EXPDATE = Para[20].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[22].Value))
            {
                o.FLAG = Para[22].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[21].Value))
            {
                o.REMARK = Para[21].Value.ToString();
            }
            return ds;
        }

        /// <summary>
        /// 根据时间删除交易记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int DeletePOS_TransactionbyTime(string time1, string time2)
        {
            string strSQL = "delete from POS_Transaction  where  Datetime>='" + time1 + "' and Datetime<='" + time2 + "' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        /// 删除全部交易记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int DeletePOS_Transaction()
        {
            string strSQL = "delete from POS_Transaction";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        public static bool IsConsumed(string card)
        {
            string strSql = "select count(1) from tb_POS_Transaction where CardSnr = '"+card+"'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql) > 0 ? true : false;
        }
    }
}
