using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Ims.Site.DAL
{
    public class InsertDataTable_SpotDAL
    {

        /// <summary>   
        /// 使用SqlBulkCopy将DataTable中的数据批量插入数据库中   
        /// </summary>   
        /// <param name="strTableName">数据库中对应的表名</param>   
        /// <param name="dtData">数据集</param>   
        public static bool SqlBulkCopyInsert(string strTableName, DataTable dtData)
        {
            string ConStr = ConfigurationManager.AppSettings["conStr"];// 数据库连接字符串   

            try
            {
                using (SqlBulkCopy sqlRevdBulkCopy = new SqlBulkCopy(ConStr))//引用SqlBulkCopy   
                {
                    sqlRevdBulkCopy.DestinationTableName = strTableName;//数据库中对应的表名   

                    sqlRevdBulkCopy.NotifyAfter = dtData.Rows.Count;//有几行数据   

                    sqlRevdBulkCopy.WriteToServer(dtData);//数据导入数据库   

                    sqlRevdBulkCopy.Close();//关闭连接   
                }
            }
            catch(Exception ex) 
            {
                string s = ex.Message.ToString();
                return false;
            }
            return true;
        }
    }
}
