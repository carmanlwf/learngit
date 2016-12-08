using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
//using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
    /// <summary>
    ///SQLHelper 的摘要说明
    /// </summary>
public class SQLHelper
{
    public SQLHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
    //todo:数据库连接字符串    
    public static string connectionString = GetConnString();

    //public static string GetConnString()
    //{
    //    string DatabaseName = ConfigurationManager.AppSettings["conStr"];
    //    string DBName = ConfigurationManager.AppSettings["DBName"];
    //    return DatabaseName + System.Web.HttpContext.Current.Server.MapPath(DBName);
    //}

    public static string GetConnString()
    {
        string ConnStr = ConfigurationManager.AppSettings["conStr"];
        //string ConnStr = ConfigurationManager.ConnectionStrings["NSKConnectString"].ConnectionString;
        //string ProviderName = ConfigurationManager.ConnectionStrings["NSKConnectString"].ProviderName;
        return ConnStr;
    }
    #region  执行简单SQL语句

    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();

                    connection.Close();

                    return rows;
                }
                catch (SqlException e)
                {
                    connection.Close();

                    throw new Exception(e.Message);
                }
            }
        }
    }

    /// <summary>
    /// 执行多条SQL语句，实现数据库事务。
    /// </summary>
    /// <param name="SQLStringList">多条SQL语句</param>		
    public static void ExecuteSqlTran(ArrayList SQLStringList)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            SqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                    }
                }

                tx.Commit();

                conn.Close();
            }
            catch (System.Data.OleDb.OleDbException E)
            {
                tx.Rollback();
                conn.Close();
                throw new Exception(E.Message);
            }
        }
    }
    /// <summary>
    /// 执行带一个存储过程参数的的SQL语句。
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString, string content)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SQLString, connection);

            SqlParameter myParameter = new SqlParameter("@content", SqlDbType.VarChar);
            myParameter.Value = content;

            cmd.Parameters.Add(myParameter);

            try
            {
                connection.Open();

                int rows = cmd.ExecuteNonQuery();

                cmd.Dispose();
                connection.Close();

                return rows;
            }
            catch (System.Data.OleDb.OleDbException E)
            {
                cmd.Dispose();
                connection.Close();

                throw new Exception(E.Message);
            }


        }
    }
    /// <summary>
    /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
    /// </summary>
    /// <param name="strSQL">SQL语句</param>
    /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            SqlParameter myParameter = new SqlParameter("@fs", SqlDbType.Binary);
            myParameter.Value = fs;
            cmd.Parameters.Add(myParameter);
            try
            {
                connection.Open();
                int rows = cmd.ExecuteNonQuery();

                cmd.Dispose();
                connection.Close();

                return rows;
            }
            catch (System.Data.OleDb.OleDbException E)
            {
                cmd.Dispose();
                connection.Close();

                throw new Exception(E.Message);
            }

        }
    }

    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        connection.Close();
                        return null;
                    }
                    else
                    {
                        connection.Close();
                        return obj;
                    }
                }
                catch (System.Data.OleDb.OleDbException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }
    }
    /// <summary>
    /// 执行查询语句，返回SqlDataReader
    /// </summary>
    /// <param name="strSQL">查询语句</param>
    /// <returns>SqlDataReader</returns>
    public static SqlDataReader ExecuteReader(string strSQL)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(strSQL, connection);
        try
        {
            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader();

            connection.Close();
            return myReader;
        }
        catch (System.Data.OleDb.OleDbException e)
        {
            connection.Close();
            throw new Exception(e.Message);
        }

    }
    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);

                command.Fill(ds, "ds");


            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                connection.Close();
                throw new Exception(ex.Message);
            }

            connection.Close();


            return ds;
        }
    }


    #endregion

    #region 执行带参数的SQL语句

    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    connection.Close();

                    return rows;
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }
    }


    /// <summary>
    /// 执行多条SQL语句，实现数据库事务。
    /// </summary>
    /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
    public static void ExecuteSqlTran(Hashtable SQLStringList)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    //循环
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string cmdText = myDE.Key.ToString();
                        SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        trans.Commit();
                    }

                    conn.Close();
                }
                catch
                {
                    trans.Rollback();
                    conn.Close();
                    throw;
                }
            }
        }
    }


    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        connection.Close();
                        return null;
                    }
                    else
                    {
                        connection.Close();
                        return obj;
                    }
                }
                catch (System.Data.OleDb.OleDbException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }
    }

    /// <summary>
    /// 执行查询语句，返回SqlDataReader
    /// </summary>
    /// <param name="strSQL">查询语句</param>
    /// <returns>SqlDataReader</returns>
    public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        try
        {
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);

            SqlDataReader myReader = cmd.ExecuteReader();
            cmd.Parameters.Clear();

            connection.Close();

            return myReader;
        }
        catch (System.Data.OleDb.OleDbException e)
        {
            connection.Close();

            throw new Exception(e.Message);
        }

    }

    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }

                connection.Close();

                return ds;
            }
        }
    }


    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        if (trans != null)
            cmd.Transaction = trans;
        cmd.CommandType = CommandType.Text;//cmdType;
        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }
    private static void PrepareCommandStore(SqlCommand cmd, SqlConnection conn, CommandType type, string cmdText, SqlParameter[] cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        cmd.CommandType = type;
        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }


    /// <summary>
    /// 异步执行无参数，无返回值的存储过程。
    /// </summary>
    /// <param name="strStoredName">需要执行的存储过程的名字。</param>
    public static void AsyncExcStored(string strStoredName)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(strStoredName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    return;
                }

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                }

                conn.Close();
            }
        }
    }


    /// <summary>
    /// 执行存储  返回dataset
    /// </summary>
    /// <param name="SQLString">sql语句</param>
    /// <param name="type"></param>
    /// <param name="cmdParms">参数</param>
    /// <returns></returns>
    public static DataSet QueryStored(string SQLString, CommandType type, params SqlParameter[] cmdParms)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCommandStore(cmd, conn, type, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        conn.Close();
                        throw new Exception(ex.Message);
                    }

                    conn.Close();

                    return ds;
                }

            }

        }
    }
    #endregion
    /// <summary>
    /// 执行存储  返回dataset
    /// </summary>
    /// <param name="SQLString">sql语句</param>
    /// <param name="type"></param>
    /// <param name="cmdParms">参数</param>
    /// <returns></returns>
    public static DataSet QueryStored_noAsync(string SQLString, CommandType type, params SqlParameter[] cmdParms)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCommandStore(cmd, conn, type, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();

                        conn.Close();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        conn.Close();
                        throw new Exception(ex.Message);
                    }

                    return ds;
                }
            }
        }
    }
    public static void InsertTable(DataTable dt, string TabelName, DataColumnCollection dtColum)
    {

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            //声明SqlBulkCopy ,using释放非托管资源
            using (SqlBulkCopy sqlBC = new SqlBulkCopy(conn))
            {
                //一次批量的插入的数据量
                sqlBC.BatchSize = 5000;
                //完成操作所允许的秒数，如果超时则事务将回滚，所有已复制的行都会从目标表中移除
                sqlBC.BulkCopyTimeout = 60;
                //指定目标数据库的表名
                sqlBC.DestinationTableName = TabelName;
                //建立数据源表字段和目标表中的列之间的映射                    
                for (int i = 0; i < dtColum.Count; i++)
                {
                    sqlBC.ColumnMappings.Add(dtColum[i].ColumnName.ToString(), dtColum[i].ColumnName.ToString());
                }
                //批量写入
                sqlBC.WriteToServer(dt);
                conn.Close();
            }
        }
    }
}