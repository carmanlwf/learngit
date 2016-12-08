using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///LogCategory 的摘要说明
/// </summary>
public class LogCategory
{
    string sql = string.Empty;
	public LogCategory()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public LogCategory(string caname,int caid)
    {
        _caName = caname;
        _caID = caid;
    }

    private int _caID;
    /// <summary>分类编号
    /// 
    /// </summary>
    public int CaID
    {
        get { return _caID; }
        set { _caID = value; }
    }
    private string _caName;
    /// <summary>分类名
    /// 
    /// </summary>
    public string CaName
    {
        get { return _caName; }
        set { _caName = value; }
    }
    /// <summary>添加文档类型
    /// 
    /// </summary>
    /// <param name="logCa"></param>
    /// <returns></returns>
    public bool Add(LogCategory logCa)
    {
        sql = "INSERT INTO LOGCATEGORY (caName) VALUES(@caName)";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@caName",logCa.CaName)
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }
    /// <summary>编辑文档类型
    /// 
    /// </summary>
    /// <param name="logCa"></param>
    /// <returns></returns>
    public bool Edit(LogCategory logCa)
    {
        sql = "UPDATE LOGCATEGORY SET caName=@caName WHERE caID=@caID";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@caName",logCa.CaName),
            new SqlParameter("@caID",logCa.CaID)
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }
    /// <summary>取得分类列表
    /// 
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    public DataSet GetList(string where)
    {
        sql = "SELECT * FROM LOGCATEGORY";
        if (where!=string.Empty)
        {
            sql += " WHERE " + where;
        }
        DataSet ds = SQLHelper.Query(sql);
        if (ds.Tables[0].Rows.Count>0)
        {
            return ds;
        }
        return null;
    }
    /// <summary>删除文档类型
    /// 
    /// </summary>
    /// <param name="caID"></param>
    /// <returns></returns>
    public bool Del(int caID)
    {
        sql = "DELETE FROM LOGCATEGORY WHERE CAID=@CAID";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@caID",caID)
        };
        int res = SQLHelper.ExecuteSql(sql,paras);
        if (res > 0) return true;
        return false;
    }
}
