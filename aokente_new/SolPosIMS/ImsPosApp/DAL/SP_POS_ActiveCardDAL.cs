using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Ims.Pos.Model;

namespace Ims.Pos.DAL
{
    public class SP_POS_ActiveCardDAL
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="o">签到实体</param>
        /// <param name="Ostr">输出参数</param>
        /// <param name="Rstr">返回值</param>
        /// <returns>返回DataTable</returns>
        public static string SP_POS_ActiveCard(SP_POS_ALLParams o)
        {
            SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("@PosSnr", SqlDbType.VarChar,20), 
               new SqlParameter("@UID", SqlDbType.VarChar,20),
               new SqlParameter("@Magcard",SqlDbType.VarChar,20),                
               new SqlParameter("@Mobile",SqlDbType.VarChar,50),
               new SqlParameter("@ReMessage",SqlDbType.VarChar,50)
            };
            Para[0].Value = o.POSSNR;//pos机号
            Para[1].Value = o.USERID;//pos操作员
            Para[2].Value = o.CARDSNR;//卡号
            Para[3].Value = o.CELLPHONE;//手机号
            Para[4].Direction = ParameterDirection.ReturnValue;
            DataSet ds = SQLHelper.QueryStored("SP_POS_ActiveCard", CommandType.StoredProcedure, Para);

            if (!DBNull.Value.Equals(Para[4].Value))
            {
                o.FLAG = Para[4].Value.ToString();
            }
            return o.FLAG;
        }
    }
}
