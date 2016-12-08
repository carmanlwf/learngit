using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;
using System.Text;
using NJDesEncrypt;

/// <summary>
/// Des64_Dll 的摘要说明
/// </summary>
public class Des64_Dll
{
    [DllImport("des64.dll")]
    private static extern void b64_des(StringBuilder in_str, StringBuilder out_str, string key, int lenth, uint option);
    ///第一个参数就是你要进行加密解密的字符串，第二个参数就是要输出的字符串，第三个是指定参数，第四个是字符串长度，最后一个是加密解密参数。0加密 1解密。
    [DllImport("des64.dll")]
    private static extern int b64_size(int length, uint option);

    /// <summary>
    /// <param name="m_Str"></param>
    /// <param name="m_key"></param>
    /// <param name="flag"></param>
    /// <returns></returns>
    /// </summary>
    public static string KeyOrNoKey(string m_Str, string m_key, uint flag)
    {/*
        int outLen = b64_size(m_Str.Length, flag);
        StringBuilder Result = new StringBuilder(0xff);
        Result.Capacity = outLen;
        Result.Length = outLen;
        StringBuilder Source = new StringBuilder(m_Str);
        b64_des(Source, Result, m_key, m_Str.Length, flag);
        string s = Result.ToString().Trim();
        return Result.ToString().Trim();
      * */

        if (flag == 1)
        {
            return DESEncrypt.Encrypt(m_Str, m_key);//"gb2312"
        }
        else
        {
            return DESEncrypt.DeEncrypt(m_Str, m_key);
        }
    }
    public Des64_Dll()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
}
