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
using ZsdDotNetLibrary.Web;

public partial class Utility_Grant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string uid = "";
        string pwd = "";
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(Server.MapPath("../Utility/grant.xml"));

        XmlNodeList nodelist = xmldoc.SelectSingleNode("config").ChildNodes;//获取employees节点的所有子节点 

        foreach (XmlNode xn in nodelist)//遍历所有子节点 
        {
            XmlElement xe = (XmlElement)xn;//将子节点类型转换为xmlelement类型 
            if (xe.Name == "username")//如果genre属性值为“张三” 
            {
                uid = xe.InnerText;
            }
            else if (xe.Name == "password")
            {
                pwd = xe.InnerText;
            }
        }
        string my_uid = WebHelper.Encrypt(MembershipPasswordFormat.Hashed, Common.InputText(username.Value.Trim(), 20), WebHelper.tradepassword_salt);
        string my_pwd = WebHelper.Encrypt(MembershipPasswordFormat.Hashed, Common.InputText(password.Value.Trim(), 20), WebHelper.tradepassword_salt);
        string status = "";
        if (my_pwd == pwd && my_uid == uid)
        {
            foreach (XmlNode xn in nodelist)//遍历所有子节点 
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为xmlelement类型 
                if (xe.Name == "status")//如果genre属性值为“张三” 
                {
                    if (xe.InnerText == "ok")
                    {
                        xe.InnerText = "shutdown";
                        status = "shutdown";
                    }
                    else
                    {
                        xe.InnerText = "ok";
                        status = "ok";
                    }
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
            WebClientHelper.DoClientMsgBox("操作成功!系统当前状态:" + status);
        }
    }
}
