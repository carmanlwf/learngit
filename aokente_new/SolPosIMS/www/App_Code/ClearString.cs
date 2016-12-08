using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

/// <summary>
/// ClearString 的摘要说明
/// </summary>
public sealed class ClearString
{
    public ClearString()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static string InputText(string inputString, int maxLength)
    {
        StringBuilder retVal = new StringBuilder();
        if ((inputString != null) && (inputString != String.Empty))
        {
            inputString = inputString.Trim();
            if (inputString.Length > maxLength)
                inputString = inputString.Substring(0, maxLength);
            for (int i = 0; i < inputString.Length; i++)
            {
                switch (inputString[i])
                {
                    case '\'':
                        retVal.Append("");
                        break;
                    case '<':
                        retVal.Append("&lt;");
                        break;
                    case '>':
                        retVal.Append("&gt;");
                        break;
                    default:
                        retVal.Append(inputString[i]);
                        break;
                }
            }
            retVal.Replace("'", " ");
        }
        return retVal.ToString();
        }
    }


