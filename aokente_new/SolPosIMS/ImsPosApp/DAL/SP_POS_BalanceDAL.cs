using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.Model;
using System.Data.SqlClient;

namespace Ims.Pos.DAL
{
   public class SP_POS_BalanceDAL
    {
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="o">余额实体</param>
        /// <param name="OBalance">输出余额</param>
        /// <param name="OTotalMoney">输出总金额</param>
        /// <param name="OTotalIntegral">输出总积分</param>
        /// <param name="Rstr">返回结果</param>
        /// <returns>DataSet</returns>
       public static DataSet SP_POS_Balance(SP_POS_ALLParams o)
        {
            SqlParameter[] Para = new SqlParameter[]{     
                   new SqlParameter("@ShopName", SqlDbType.VarChar,30),
                   new SqlParameter("@PosSnr", SqlDbType.VarChar,20), 
                   new SqlParameter("@BatchSnr", SqlDbType.BigInt,20),   
                   new SqlParameter("@UserID",SqlDbType.BigInt,20),
                   new SqlParameter("@BatchPassword",SqlDbType.VarChar,50), 
                   new SqlParameter("@BatchMode",SqlDbType.BigInt,20),  
                   new SqlParameter("@ReBatchSnr",SqlDbType.BigInt,20),  
                   new SqlParameter("@NextBatchSnr",SqlDbType.BigInt,20),  
                   new SqlParameter("@ReUserID",SqlDbType.BigInt,20),  
                   new SqlParameter("@StartDate",SqlDbType.VarChar,100),  
                   new SqlParameter("@EndDate",SqlDbType.VarChar,100),  
                   new SqlParameter("@BusinessAmount",SqlDbType.Real,20),  
                   new SqlParameter("@BusinessCount",SqlDbType.BigInt,20),  
                   new SqlParameter("@CancelAmount",SqlDbType.Real,20),
                   new SqlParameter("@CancelCount",SqlDbType.BigInt,20),
                   new SqlParameter("@IntegralAmount",SqlDbType.Real,20),
                   new SqlParameter("@IntegralCount",SqlDbType.BigInt,20),
                   new SqlParameter("@CancelIntegralAmount",SqlDbType.Real,20),
                   new SqlParameter("@CancelIntegralCount",SqlDbType.BigInt,20),
                   new SqlParameter("@ChargeAmount",SqlDbType.Real,20),
                   new SqlParameter("@ChargeCount",SqlDbType.BigInt,20),
                   new SqlParameter("@Remark",SqlDbType.VarChar,255),
                   new SqlParameter("Rstr",SqlDbType.Int,4)

            };
            Para[0].Direction = ParameterDirection.Output;//终端机号
            Para[1].Value = o.POSSNR;//终端机号
            Para[2].Value = o.BATCHSNR;//结算批次号
            Para[3].Value = o.USERID;//操作员ID
            Para[4].Value = o.BALANCEPASSWORD;//结算密码
            Para[5].Value = o.MODE;//结算类型
            Para[6].Direction = ParameterDirection.Output;//返回交易批次号
            Para[7].Direction = ParameterDirection.Output;//下一个结算的批次号
            Para[8].Direction = ParameterDirection.Output;//操作员ID
            Para[9].Direction = ParameterDirection.Output;//起始时间
            Para[10].Direction = ParameterDirection.Output;//结束时间
            Para[11].Direction = ParameterDirection.Output;//交易总额
            Para[12].Direction = ParameterDirection.Output;//交易总次数
            Para[13].Direction = ParameterDirection.Output;//辙单总额
            Para[14].Direction = ParameterDirection.Output;//辙单总次数
            Para[15].Direction = ParameterDirection.Output;//积分交易额
            Para[16].Direction = ParameterDirection.Output;//积分交易次数
            Para[17].Direction = ParameterDirection.Output;//积分辙单总额
            Para[18].Direction = ParameterDirection.Output;//积分辙单次数
            Para[19].Direction = ParameterDirection.Output;//充值交易金额
            Para[20].Direction = ParameterDirection.Output;//充值交易金额
            Para[21].Direction = ParameterDirection.Output;//结算提示
            Para[22].Direction = ParameterDirection.ReturnValue;
            DataSet ds = SQLHelper.QueryStored("SP_POS_Balance", CommandType.StoredProcedure, Para);
            if (!DBNull.Value.Equals(Para[0].Value))
            {
                o.SHOPNAME = Para[0].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[6].Value))
            {
                o.REBATCHSNR = long.Parse(Para[6].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[7].Value))
            {
                o.NEXTBATCHSNR = Para[7].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[8].Value))
            {
                o.USERID =int.Parse(Para[8].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[9].Value))
            {
                o.STARTDATE = Para[9].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[10].Value))
            {
                o.ENDDATE = Para[10].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[11].Value))
            {
                o.BUSINESSAMOUNT = decimal.Parse(Para[11].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[12].Value))
            {
                o.BUSINESSCOUNT =int.Parse(  Para[12].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[13].Value))
            {
                o.CANCELAMOUNT = decimal.Parse(Para[13].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[14].Value))
            {
                o.CANCELCOUNT =int.Parse( Para[14].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[15].Value))
            {
                o.INTEGRALAMOUNT =decimal.Parse( Para[15].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[16].Value))
            {
                o.INTEGRALCOUNT =int.Parse( Para[16].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[17].Value))
            {
                o.CANCELINTEGRALAMOUNT = decimal.Parse(Para[17].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[18].Value))
            {
                o.CANCELINTEGRALCOUNT = int.Parse(Para[18].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[19].Value))
            {
                o.ChargeAmount = Para[19].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[20].Value))
            {
                o.ChargeCount = Para[20].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[21].Value))
            {
                o.REMARK = Para[21].Value.ToString();
            }
            if (!DBNull.Value.Equals(Para[22].Value))
            {
                o.FLAG = Para[22].Value.ToString();
            }

            return ds;
        }


    }
}
