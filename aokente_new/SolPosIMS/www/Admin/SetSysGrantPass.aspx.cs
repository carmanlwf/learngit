using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Ims.Main;
using ZsdDotNetLibrary.Web;

public partial class Admin_SetSysGrantPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }
    protected void btnConfirm_ServerClick(object sender, EventArgs e)
    {
        if (pwd.Value.Trim() != pwdconfirm.Value.Trim())
        {
            WebClientHelper.DoClientMsgBox("两次密码输入不一致!");
        }
        else
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("../Utility/grant.xml"));

            XmlNodeList nodelist = xmldoc.SelectSingleNode("config").ChildNodes;//获取employees节点的所有子节点 

            foreach (XmlNode xn in nodelist)//遍历所有子节点 
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为xmlelement类型 
                if (xe.Name == "username")//如果genre属性值为“张三” 
                {
                    //xe.SetAttribute("username", "update张三");//则修改该属性为“update张三” 
                    xe.InnerText = WebHelper.Encrypt(MembershipPasswordFormat.Hashed, uid.Value.Trim(), WebHelper.tradepassword_salt);
                }
                else if (xe.Name == "password")
                {
                    xe.InnerText = WebHelper.Encrypt(MembershipPasswordFormat.Hashed, pwd.Value.Trim(), WebHelper.tradepassword_salt);
                }
            }
            try
            {
                xmldoc.Save(Server.MapPath("../Utility/grant.xml"));//保存。
            }
            catch (Exception ex)
            {
                throw ex;
            }
            WebClientHelper.DoClientMsgBox("系统授权账户信息修改成功!");
        }
    }
}
