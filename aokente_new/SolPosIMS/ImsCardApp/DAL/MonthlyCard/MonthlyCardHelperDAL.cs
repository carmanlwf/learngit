using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Ims.Pos.DAL;
using Ims.Card.Model.MonthlyCard;
using ZsdDotNetLibrary.Data;

namespace Ims.Card.DAL.MonthlyCard
{
    public class MonthlyCardHelperDAL
    {
        /// <summary>
        /// 月卡开卡
        /// </summary>
        /// <param name="carnum"></param>
        /// <param name="supportSites"></param>
        /// <param name="uptoTime"></param>
        /// <returns></returns>
        public static string MonthlyCardCreate(MonthlyCardCreate o,string operatorid)
        {
            SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("@carnum", SqlDbType.VarChar,20), 
               new SqlParameter("@realname", SqlDbType.VarChar,20),
               new SqlParameter("@sex", SqlDbType.Int),
               new SqlParameter("@cellphone", SqlDbType.VarChar,11),
               new SqlParameter("@typeid", SqlDbType.VarChar,20),
               new SqlParameter("@balance", SqlDbType.Decimal),
               new SqlParameter("@monthlyamount", SqlDbType.Decimal),
               new SqlParameter("@uptotime", SqlDbType.VarChar,20),
               new SqlParameter("@operatorid", SqlDbType.VarChar,15),
               new SqlParameter("@supportSites", SqlDbType.VarChar,8000),
               new SqlParameter("@Sections", SqlDbType.VarChar, 5),
               new SqlParameter("Rstr",SqlDbType.Int)
            };
            Para[0].Value = o.carnum;
            Para[1].Value = o.realname;
            Para[2].Value = 1;//默认男性
            Para[3].Value = o.cellphone;
            Para[4].Value = o.typeid;
            Para[5].Value = o.balance;
            Para[6].Value = o.monthlyamount;
            Para[7].Value = o.uptotime;
            Para[8].Value = operatorid;//平台操作员
            Para[9].Value = o.supportSites;
            Para[10].Value = o.Sections;
            Para[11].Direction = ParameterDirection.ReturnValue; ;
            try
            {
                DataSet ds = SQLHelper.QueryStored("SP_Member_CreateMonthlyCardUser", CommandType.StoredProcedure, Para);
            }
            catch
            { }
            string retstr = "";
            if (Para[11].Value != null)
            {
                retstr = Para[11].Value.ToString();
            }
            return retstr;
        }
        /// <summary>
        /// 获取站点信息列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSiteListInfo()
        {
            string strSql = "SELECT id as siteid,SiteName FROM tb_Site";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
    }
}