using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.Model;
using System.Data.SqlClient;

namespace Ims.Pos.DAL
{
    public class SP_POS_QueryDAL
    {
        /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="o">余额实体</param>
        /// <param name="OBalance">输出余额</param>
        /// <param name="OTotalMoney">输出总金额</param>
        /// <param name="OTotalIntegral">输出总积分</param>
        /// <param name="Rstr">返回结果</param>
        /// <returns>DataSet</returns>
        public static DataSet Pos_Query(SP_POS_ALLParams o)
        {
            SqlParameter[] Para = new SqlParameter[]{                
                   new SqlParameter("@posno", SqlDbType.VarChar,20), 
                   new SqlParameter("@Magcard", SqlDbType.VarChar,20),   
                   new SqlParameter("@CardSnr",SqlDbType.BigInt,20),
                   new SqlParameter("@PIN",SqlDbType.VarChar,50),                  
                   new SqlParameter("@CardType",SqlDbType.Int,4),
                   new SqlParameter("@Balance",SqlDbType.Real,20),
                   new SqlParameter("@TotalMoney",SqlDbType.Real,20),
                   new SqlParameter("@TotalIntegral",SqlDbType.BigInt,20),
                   new SqlParameter("Rstr",SqlDbType.Int,4)

            };
            Para[0].Value = o.POSSNR;//终端机号
            Para[1].Value = o.MAGCARD;//磁条卡卡号
            Para[2].Value = o.CARDSNR;//IC卡卡号
            //用户密码
            Para[3].Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(o.PIN, "MD5");
            Para[4].Value = o.CARDTYPE;//查询的卡类型
            Para[5].Direction = ParameterDirection.Output;//卡上余额
            Para[6].Direction = ParameterDirection.Output;//交易总额
            Para[7].Direction = ParameterDirection.Output;//当前积分
            Para[8].Direction = ParameterDirection.ReturnValue;
            DataSet ds = SQLHelper.QueryStored("SP_POS_Query", CommandType.StoredProcedure, Para);
            if (!DBNull.Value.Equals(Para[5].Value))
            {
                o.BALANCE = Convert.ToDecimal(Para[5].Value.ToString());
            }
            if (!DBNull.Value.Equals(Para[6].Value))
            {
                o.TOTALMONEY = Convert.ToDecimal(Para[6].Value);
            }
            if (!DBNull.Value.Equals(Para[7].Value))
            {
                o.TOTALINTEGRAL =Convert.ToDecimal(Para[7].Value);
            }
            if (!DBNull.Value.Equals(Para[8].Value))
            {
                o.FLAG = Para[8].Value.ToString();
            }           
            return ds;
        }
    }
}
