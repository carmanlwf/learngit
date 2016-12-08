using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
[Serializable]
/// <summary>
///User 的摘要说明
/// </summary>
public class User
{
    string sql = string.Empty;
    string sql1 = string.Empty;
    string sql2 = string.Empty;
	public User()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public User(DataRow dr)
    {
        //_uID = Convert.ToInt32(dr["userID"]);
        //_loginName = dr["loginName"].ToString();
        //_userName = dr["userName"].ToString();
        //_password = dr["pwd"].ToString();
        //_userType = Convert.ToInt32(dr["userType"]);
        _card = dr["card"].ToString();
        _UserId = dr["userid"].ToString();
        _status = Convert.ToInt32((dr["status"].ToString()));
        _pass = dr["pass"].ToString();
        _RegionId = dr["regionId"].ToString();
        _RealName = dr["RealName"].ToString();
    }
    private string _Account;
    /// <summary>
    /// 登录帐号(卡号/手机)
    /// </summary>
    public string Account
    {
        get { return _Account; }
        set { _Account = value; }
    }
    private string _UserId;
    /// <summary>
    /// 用户编号
    /// </summary>
    public string UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    private string _card;
    /// <summary>
    /// 用户卡号
    /// </summary>
    public string card
    {
        get { return _card; }
        set { _card = value; }
    }
    private string _RealName;
    /// <summary>
    /// 用户姓名
    /// </summary>
    public string RealName
    {
        get { return _RealName; }
        set { _RealName = value; }
    }
    private string _RegionId;
    /// <summary>
    /// 所在分店编号
    /// </summary>
    public string RegionId
    {
        get { return _RegionId; }
        set { _RegionId = value; }
    }
    private string _pass;
    /// <summary>
    /// 用户密码
    /// </summary>
    public string pass
    {
        get { return _pass; }
        set { _pass = value; }
    }
    private int _status;
    /// <summary>
    /// 激活状态
    /// </summary>
    public int status
    {
        get { return _status; }
        set { _status = value; }
    }
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    //public bool Add(User user)
    //{
    //    //sql = "INSERT INTO USERS (loginName,userName,password,userType) VALUES(@loginName,@userName,@password,@userType)";
    //    sql = "INSERT INTO USERS (loginName,pwd,userName,userType) VALUES(@loginName,@pwd,@userName,@userType)";
    //    SqlParameter[] paras = new SqlParameter[] { 
    //        new SqlParameter("@loginName",user.LoginName),
    //        new SqlParameter("@pwd",StringOP.MD5EncryptOne(user.Password)),
    //        new SqlParameter("@userName",user.UserName),
    //        new SqlParameter("@userType",user.UserType)
    //    };
    //    int res = SQLHelper.ExecuteSql(sql, paras);
    //    if (res > 0) return true;
    //    return false;
    //}
    /// <summary>编辑用户
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    //public bool Edit(User user)
    //{
    //    sql = "UPDATE USERS SET loginName=@loginName,userName=@userName,pwd=@pwd,userType=@userType WHERE uID=@uID";
    //    SqlParameter[] paras = new SqlParameter[] { 
    //        new SqlParameter("@loginName",user.LoginName),
    //        new SqlParameter("@userName",user.UserName),
    //        new SqlParameter("@pwd",StringOP.MD5EncryptOne(user.Password)),
    //        new SqlParameter("@userType",user.UserType),
    //        new SqlParameter("@uID",user.UID)
    //    };
    //    int res = SQLHelper.ExecuteSql(sql, paras);
    //    if (res > 0) return true;
    //    return false;
    //}
    /// <summary>得到用户列表
    /// 
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    public DataSet GetList(string where)
    {
        sql = "SELECT * FROM USERS";
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
    /// <summary>
    /// 用户登录(通过卡号/手机号 +登录密码)
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    public bool Login(User user,out User userInfo)
    {
        string u_pass_encrpt = StringOP.MD5EncryptOne(user.pass);
        //sql = "SELECT COUNT(1) FROM USERS WHERE loginName=@loginName AND pwd=@pwd ";
        sql1 = "SELECT COUNT(1) FROM tb_Card WHERE card=@account AND pass=@pass  And status = 1";
        sql2 = "SELECT COUNT(1) FROM tb_Card WHERE userid in (select userid from tb_member where cellphone = @account) And status = 1";
        SqlParameter[] paras = new SqlParameter[] {
            new SqlParameter("@account",user.Account),
            new SqlParameter("@pass",u_pass_encrpt)
        };
        string res1 = (SQLHelper.GetSingle(sql1, paras)).ToString();
        string res2 = (SQLHelper.GetSingle(sql2, paras)).ToString();
        if (res1 == "1")
        {
            userInfo = GetInfoByCard(user.Account);
            return true;
        }
        else if (res2 == "1")
        {
            userInfo = GetInfoByCellPhone(user.Account);
            return true;
        }
        else
        {
            userInfo = null;
            return false;
        }
    }
    /// <summary>
    /// 根据卡号得到指定用户名的用户信息
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public User GetInfoByCard(string card)
    {
        sql = "Select a.card,a.userid,a.status,a.pass,a.regionid,b.realname from tb_card as a inner join tb_member as b on a.userid = b.userid where a.card = @card";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@card",card)
        };
        DataSet ds = SQLHelper.Query(sql, paras);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return new User(ds.Tables[0].Rows[0]);
        }
        return null;
    }
    /// <summary>
    /// 根据卡号得到指定用户名的用户信息
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public User GetInfoByCellPhone(string cellphone)
    {
        sql = "Select a.card,a.userid,a.status,a.pass,a.regionid,b.realname from tb_card as a inner join tb_member as b on a.userid = b.userid where b.cellphone = @Cellphone";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@Cellphone",cellphone)
        };
        DataSet ds = SQLHelper.Query(sql, paras);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return new User(ds.Tables[0].Rows[0]);
        }
        return null;
    }
    /// <summary>得到指定用户名编号的用户信息
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    //public User GetInfo(int uID)
    //{
    //    sql = "SELECT * FROM USERS WHERE userid=@userid";
    //    SqlParameter[] paras = new SqlParameter[] { 
    //        new SqlParameter("@userid",uID)
    //    };
    //    DataSet ds = SQLHelper.Query(sql, paras);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        return new User(ds.Tables[0].Rows[0]);
    //    }
    //    return null;
    //}
    /// <summary>删除用户
    /// 
    /// </summary>
    /// <param name="uID"></param>
    /// <returns></returns>
    public bool Del(int uID)
    {
        sql = "DELETE FROM USERS WHERE userID=@userID";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@userID",uID)
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }
    /// <summary>用户修改个人信息
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public bool ReUserInfo(User user)
    {
        sql = "UPDATE USERS SET userName=@userName WHERE userID=@userid";
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@userName",user.RealName),
            new SqlParameter("@userid",user.UserId)
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }
/// <summary>
/// 
/// </summary>
/// <param name="card"></param>
/// <param name="pwd"></param>
/// <param name="type">修改密码类型（1：登陆密码 2：交易密码）</param>
/// <returns></returns>
    public bool ReSetPwd(string card, string old_pwd, string new_pwd, string type)
    {
        string sql = "";
        if (type == "1")
        {
            sql = "UPDATE tb_card SET pass = @newpwd WHERE card = @CARD And pass=@oldpwd";
        }
        else
        {
            sql = "UPDATE tb_card SET tradepassword = @newpwd WHERE card = @CARD And tradepassword = @oldpwd";
        }
        SqlParameter[] paras = new SqlParameter[] { 
            new SqlParameter("@oldpwd",StringOP.MD5EncryptOne(old_pwd)),
            new SqlParameter("@newpwd",StringOP.MD5EncryptOne(new_pwd)),
            new SqlParameter("@CARD",card)
        };
        int res = SQLHelper.ExecuteSql(sql, paras);
        if (res > 0) return true;
        return false;
    }

}
