using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using System.Data.SqlClient;
using Ims.Pos.Model;

namespace Ims.Pos.DAL
{
    public class CheckIsArrearageHelperDAL
    {
        public static DataTable GetAccountInfoByCardSnr(string CardSnr)
        {
            string strSql = "SELECT [card],[TypeName],[balance],[Expenditure],[Points],[validDate],[CellPhone],[LastSaleTime1],[IsByTime],[uptotime],[supportSites] FROM [v_card_MemberCardInfo] WHERE [card] = '" + CardSnr + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
                /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="o">签到实体</param>
        /// <param name="Ostr">输出参数</param>
        /// <param name="Rstr">返回值</param>
        /// <returns>返回DataTable</returns>
        public static string SP_POS_ActiveCard(input_CheckIsArrearage oInput)
        {
            SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("@PosSnr", SqlDbType.VarChar,20), 
               new SqlParameter("@UID", SqlDbType.VarChar,20),
               new SqlParameter("@Magcard",SqlDbType.VarChar,20),                
               new SqlParameter("@Mobile",SqlDbType.VarChar,50),
               new SqlParameter("@ReMessage",SqlDbType.VarChar,50)
            };
            Para[0].Value = oInput.POSSNR;//pos机号
            Para[1].Value = oInput.Uid;//pos操作员
            Para[2].Value = oInput.CardSnr;//卡号
            Para[3].Value = "";//手机号
            Para[4].Direction = ParameterDirection.ReturnValue;
            try
            {
                DataSet ds = SQLHelper.QueryStored("SP_POS_ActiveCard", CommandType.StoredProcedure, Para);
            }
            catch
            { }
            string retstr = "";
            if (!DBNull.Value.Equals(Para[4].Value))
            {
                retstr = Para[4].Value.ToString();
            }
            return retstr;
        }
    }
}
