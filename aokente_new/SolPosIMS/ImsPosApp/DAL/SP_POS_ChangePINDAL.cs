using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ims.Pos.Model;

namespace Ims.Pos.DAL
{
    public class SP_POS_ChangePINDAL
    {

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="o">签到实体</param>
        /// <param name="Ostr">输出参数</param>
        /// <param name="Rstr">返回值</param>
        /// <returns>返回DataTable</returns>
        public static DataSet Pos_ChangePINDAL(SP_POS_ALLParams o)
        {
            SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("@PosSnr", SqlDbType.VarChar,20),   
               new SqlParameter("@CardSnr",SqlDbType.VarChar,20),
               new SqlParameter("@OldPIN",SqlDbType.VarChar,50),                  
               new SqlParameter("@NewPIN",SqlDbType.VarChar,50),
               new SqlParameter("@ReMessage",SqlDbType.VarChar,50),
               new SqlParameter("retstr",SqlDbType.Int,4),
            };
            Para[0].Value = o.POSSNR;//pos机号
            Para[1].Value = o.CARDSNR;//卡号
            Para[2].Value = o.PIN;
            Para[3].Value = o.NEWPIN;
            Para[4].Direction = ParameterDirection.Output;
            Para[5].Direction = ParameterDirection.ReturnValue;
            DataSet ds = SQLHelper.QueryStored("SP_POS_ChangePIN", CommandType.StoredProcedure, Para);
            o.REMESSAGE = Para[4].Value.ToString();
          
            if (!DBNull.Value.Equals(Para[5].Value))
            {
                o.FLAG = Para[5].Value.ToString();
            }
            return ds;
        }
    }
}
