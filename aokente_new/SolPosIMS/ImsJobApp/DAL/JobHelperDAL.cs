using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using System.Data.SqlClient;
using Ims.Pos.DAL;
using Ims.Job.Model;

namespace Ims.Job.DAL
{
    public class JobHelperDAL
    {
        /// <summary>
        /// 根据条件进行收费员业绩统计
        /// </summary>
        /// <param name="person"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <returns></returns>
        public static DataTable GetJobStaticsInfo(string persons, string s_time, string e_time)
        {
            if (string.IsNullOrEmpty(persons)) return null;
            string strSql = "";
            if (!string.IsNullOrEmpty(s_time) && !string.IsNullOrEmpty(e_time))
            {
                strSql = @"SELECT ISNULL(x.amount_real,0.00) as amount_real,ISNULL(x.amount_receivable,0.00) as amount_receivable,ISNULL(x.giving_amount,0.00) as giving_amount,y.operatorid,y.name  FROM (SELECT UserID, SUM([Money]) as amount_receivable,SUM([RealMoney]) as amount_real,SUM(giving) as giving_amount FROM tb_POS_Transaction WHERE EndTime >='" + s_time + "' AND EndTime <='" + e_time + "' GROUP BY UserID) as x RIGHT JOIN (SELECT operatorid,name FROM tb_Pos_Operator  WHERE operatorid in (" + persons + ")) as y ON x.UserID = y.operatorid";
            }
            else
            {
                strSql = @"SELECT ISNULL(x.amount_real,0.00) as amount_real,ISNULL(x.amount_receivable,0.00) as amount_receivable,ISNULL(x.giving_amount,0.00) as giving_amount,y.operatorid,y.name  FROM (SELECT UserID, SUM([Money]) as amount_receivable,SUM([RealMoney]) as amount_real,SUM(giving) as giving_amount FROM tb_POS_Transaction GROUP BY UserID) as x 
                            RIGHT JOIN
                            (SELECT operatorid,name FROM tb_Pos_Operator WHERE operatorid in ("+persons+")) as y ON x.UserID = y.operatorid";
            }
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// 查询统计语句
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="operatorid"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <param name="isSignleOrMutiply"></param>
        /// <returns></returns>
        public static DataTable GetJobStaticsInfows(string persons,string operatorid, string s_time, string e_time,bool isSignleOrMutiply)
        {
            SqlParameter[] Para = new SqlParameter[]{                 
               new SqlParameter("@persons", SqlDbType.VarChar,20), 
               new SqlParameter("@startTime", SqlDbType.VarChar,30),   
               new SqlParameter("@endTime",SqlDbType.VarChar,30),                  
               new SqlParameter("Rstr",SqlDbType.Int)
               };

            persons = persons.Replace("'", "");
            Para[0].Value = persons;
            Para[1].Value = s_time;
            Para[2].Value = e_time;
            Para[3].Direction = ParameterDirection.ReturnValue;

            DataSet ds = SQLHelper.QueryStored("SP_CalcTollCollectorFeat", CommandType.StoredProcedure, Para);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取操作员列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPosOperators()
        {
            string strSql = "SELECT operatorid from tb_Pos_Operator";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }

        /// <summary>
        /// 统计业绩存储过程
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetDataTable_Collector_Persons(SP_CalcTollCollectorFeat o)
        {
            SqlParameter[] Para = new SqlParameter[]{                
                   new SqlParameter("@startTime", SqlDbType.VarChar,20), 
                   new SqlParameter("@endTime", SqlDbType.VarChar,20),   
                   new SqlParameter("@persons",SqlDbType.VarChar,8000)
            };
            Para[0].Value = o.startTime;//开始时间
            Para[1].Value = o.endTime;//结束时间
            Para[2].Value = o.persons;//人员id

            DataSet ds = SQLHelper.QueryStored("SP_CalcTollCollectorFeat", CommandType.StoredProcedure, Para);         
            return ds.Tables[0];
        }

        /// <summary>
        /// 统计个人业绩存储过程
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetDataTable_Collector_Persons_One(SP_CalcTollCollectorFeat o)
        {
            SqlParameter[] Para = new SqlParameter[]{
                   new SqlParameter("@type", SqlDbType.Int),
                   new SqlParameter("@startTime", SqlDbType.VarChar,20),
                   new SqlParameter("@endTime", SqlDbType.VarChar,20),
                   new SqlParameter("@persons",SqlDbType.VarChar,8000)
            };
            Para[0].Value = o.type;//类型
            Para[1].Value = o.startTime;//开始时间
            Para[2].Value = o.endTime;//结束时间
            Para[3].Value = o.persons;//人员id

            DataSet ds = SQLHelper.QueryStored("SP_CalcTollCollectorFeat_One", CommandType.StoredProcedure, Para);
            return ds.Tables[0];
        }
    }
}
