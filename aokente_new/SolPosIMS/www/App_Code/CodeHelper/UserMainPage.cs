using System;
using System.Web.UI;
using System.Web.Security;
using System.Web;

/// <summary>
///UserInfo 的摘要说明
/// </summary>
public class UserMainPage : Page
{
    public UserMainPage()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    protected User UserInfo
    {
        get
        {
            string strUser = ((FormsIdentity)this.Context.User.Identity).Ticket.UserData;
            User u = new User();
            return Serialize.Decrypt<User>(u, strUser);
        }
    }


}
