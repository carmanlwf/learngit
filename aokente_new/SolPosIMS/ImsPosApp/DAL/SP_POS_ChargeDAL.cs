using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Ims.Pos.Model.Charge;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.DAL
{
    public class SP_POS_ChargeDAL
    {
        public static DataTable GetAccountInfoByCardSnr(string CardSnr)
        {
            string strSql = "SELECT [card],[TypeName],[balance],[Expenditure],[Points],[validDate],[CellPhone],[LastSaleTime1] FROM [v_card_MemberCardInfo] WHERE [card] = '" + CardSnr + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// charge
        /// </summary>
        /// <param name="o">签到实体</param>
        /// <param name="Ostr">输出参数</param>
        /// <param name="Rstr">返回值</param>
        /// <returns>返回DataTable</returns>
        public static string SP_POS_ChargeByCardSnr(input_charge oInput, string now)
        {
            SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("@PosSnr", SqlDbType.VarChar,20), 
               new SqlParameter("@UserID", SqlDbType.VarChar,20),
               new SqlParameter("@CardSnr",SqlDbType.VarChar,20),                
               new SqlParameter("@Amount",SqlDbType.Decimal),
               new SqlParameter("@AndroidID",SqlDbType.VarChar,50),
               new SqlParameter("@Now",SqlDbType.VarChar,50),
               new SqlParameter("@ReMessage",SqlDbType.VarChar,50)
            };
            Para[0].Value = oInput.POSSNR;//pos机号
            Para[1].Value = oInput.UserID;//pos操作员
            Para[2].Value = System.Web.HttpContext.Current.Server.UrlDecode(oInput.CardSnr);//车牌号
            Para[3].Value = oInput.Amount;//手机号
            Para[4].Value = oInput.AndroidID;
            Para[5].Value = now;
            Para[6].Direction = ParameterDirection.ReturnValue;
            //Para[4].Direction = ParameterDirection.ReturnValue;
            try
            {
                DataSet ds = SQLHelper.QueryStored("SP_POS_Charge", CommandType.StoredProcedure, Para);
            }
            catch
            { }
            string retstr = "";
            if (!DBNull.Value.Equals(Para[6].Value))
            {
                retstr = Para[6].Value.ToString();
            }
            return retstr;
        }

    }
}
