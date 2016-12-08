<%@ WebHandler Language="C#" Class="MemberInfo" %>

using System;
using System.Web;
using System.Data;
using ZsdDotNetLibrary.Data;
using System.Data.SqlClient;
public class MemberInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";
        string cardOrcell = context.Request.Form["cardOrcell"];
        context.Response.Write(GetUserinfoAndCaridByCardId(cardOrcell));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
            /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="o">余额实体</param>
        /// <param name="OBalance">输出余额</param>
        /// <param name="OTotalMoney">输出总金额</param>
        /// <param name="OTotalIntegral">输出总积分</param>
        /// <param name="Rstr">返回结果</param>
        /// <returns>DataSet</returns>
    public static string GetUserinfoAndCaridByCardId(string card)
        {
            card = System.Web.HttpUtility.UrlDecode(card, System.Text.Encoding.GetEncoding("UTF-8"));
            SqlParameter[] Para = new SqlParameter[]{                
                   new SqlParameter("@CardSnr", SqlDbType.VarChar,20)

            };
            Para[0].Value = card;//终端机号
            DataSet ds = SQLHelper.QueryStored("QuikGetMemberInfoByCardOrMobile", CommandType.StoredProcedure, Para);
            DataTable dt = new DataTable();
        if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if(dt!=null&&dt.Rows.Count>0)
                return WebHelper.TableToSingleJson(dt);
                    else
                return "{no:0}";
        }

}