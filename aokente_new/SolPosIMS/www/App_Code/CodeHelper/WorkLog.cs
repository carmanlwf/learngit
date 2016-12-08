using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
/// <summary>
///WorkLog 的摘要说明
/// </summary>
public class WorkLog
{
    string sql = string.Empty;
	public WorkLog()
	{
		
	}

    public WorkLog(DataRow dr)
    {
        _logID = Convert.ToInt32(dr["ID"]);
        _userID = Convert.ToInt32(dr["userID"]);
        _caID = Convert.ToInt32(dr["caID"]);
        _logContent = dr["logContent"].ToString();
        _addDate = Convert.ToDateTime(dr["addDate"]);
        _title = dr["logTitle"].ToString();
    }

    private int _logID;
    /// <summary>
    /// 日志编号
    /// </summary>
    public int LogID
    {
        get { return _logID; }
        set { _logID = value; }
    }
    private int _userID;
    /// <summary>
    /// 用户编号
    /// </summary>
    public int UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }
    private int _caID;
    /// <summary>
    /// 分类编号
    /// </summary>
    public int CaID
    {
        get { return _caID; }
        set { _caID = value; }
    }
    private string _title;
    /// <summary>文章标题
    /// 
    /// </summary>
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    private string _logContent;
    public string LogContent
    {
        get { return _logContent; }
        set { _logContent = value; }
    }
    private DateTime _addDate;
    public DateTime AddDate
    {
        get { return _addDate; }
        set { _addDate = value; }
    }
    /// <summary>添加日志
    /// 
    /// </summary>
    /// <param name="log"></param>
    /// <returns></returns>
    public bool Add(WorkLog log)
    {
        sql = "INSERT INTO WORKLOG (userID,caID,addDate,logTitle,logContent) VALUES(@userID,@caID,@addDate,@title,@logContent)";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@userID",log.UserID),
            new SqlParameter("@caID",log.CaID),
            new SqlParameter("@addDate",log.AddDate.ToString()),
            new SqlParameter("@title",log.Title),
            new SqlParameter("@logContent",log.LogContent)
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }
    /// <summary>编辑日志
    /// 
    /// </summary>
    /// <param name="log"></param>
    /// <returns></returns>
    public bool Edit(WorkLog log)
    {
        sql = "UPDATE WORKLOG SET userID=@userID,caID=@caID,logContent=@logContent,logTitle=@title WHERE ID=@ID";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@userID",log.UserID),
            new SqlParameter("@caID",log.CaID),
            new SqlParameter("@logContent",log.LogContent),
            new SqlParameter("@logTitle",log.Title),
            new SqlParameter("@ID",log.LogID)
            
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }
    /// <summary>取得日志列表
    /// 
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    public DataSet GetList(string where)
    {
        sql = "SELECT * FROM WORKLOG";
        if (where != string.Empty)
        {
            sql += " WHERE " + where;
        }
        DataSet ds = SQLHelper.Query(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds;
        }
        return null;
    }
    public DataSet GetAll(string where)
    {
        string orderBy = " ORDER BY ID DESC";
        sql = @"SELECT LogCategory.caName, users.loginName, users.userName, WorkLog.*
FROM LogCategory, users INNER JOIN WorkLog ON users.userID = WorkLog.userID";
        if (where != string.Empty)
        {
            sql += " WHERE " + where;
        }
        DataSet ds = SQLHelper.Query(sql+orderBy);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds;
        }
        return null;
    }
    /// <summary>取得指定编号的日志
    /// 
    /// </summary>
    /// <param name="logID"></param>
    /// <returns></returns>
    public WorkLog GetWorkLog(int logID)
    {
        sql = "SELECT * FROM WORKLOG WHERE ID=@logID";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@logID",logID)
        };
        DataSet ds = SQLHelper.Query(sql, paras);
        if (ds.Tables[0].Rows.Count>0)
        {
            return new WorkLog(ds.Tables[0].Rows[0]);
        }
        return null;
    }
    /// <summary>取得指定编号的文档信息
    /// 
    /// </summary>
    /// <param name="logID"></param>
    /// <returns></returns>
    public DataSet GetDocInfo(int logID)
    {
        sql = @"SELECT LogCategory.caName, WorkLog.*, users.userName
FROM LogCategory INNER JOIN (users INNER JOIN WorkLog ON users.userID = WorkLog.userID) ON LogCategory.caID = WorkLog.caID where ID=@ID";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@ID",logID)
            
        };
        DataSet ds = SQLHelper.Query(sql,paras);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds;
        }
        return null;
    }
    /// <summary>删除文档
    /// 
    /// </summary>
    /// <param name="uID"></param>
    /// <returns></returns>
    public bool Del(int logID)
    {
        sql = "DELETE FROM WORKLOG WHERE ID=@ID";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("ID",logID)
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }
    /// <summary>检测指定编号用户当日是否有重复信息
    /// 
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="theDate"></param>
    /// <returns>true:有重复日志，false:没有重复日志</returns>
    public bool CheckUserDate(int uid)
    {
        sql = "select  count(*) from worklog where userid=@userid and DATEDIFF('d', addDate, Now())=0";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@userid",uid)
        };
        string res = SQLHelper.GetSingle(sql, paras).ToString();
        if (res!="0")
        {
            return true;
        }
        return false;
    }
}
