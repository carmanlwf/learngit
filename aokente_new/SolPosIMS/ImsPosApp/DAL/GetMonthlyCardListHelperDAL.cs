using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.DAL
{
    public class GetMonthlyCardListHelperDAL
    {
        public static DataTable GetMonthlyCardListInfo(string posnum)
        {
            string siteid = GetSiteIDByPosnum(posnum);
            string strSql = "SELECT [card] as CardSnr,[uptotime] FROM tb_card WHERE uptotime >= (CONVERT([varchar](20),getdate(),(120))) AND (supportSites LIKE '%" + siteid + "%' or Sections = '1')";
            //string strSql = "SELECT [card] as CardSnr,[uptotime] FROM tb_card WHERE uptotime >= (CONVERT([varchar](20),getdate(),(120))) AND supportSites LIKE '%" + siteid + "%'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// 根据机器号获取siteid
        /// </summary>
        /// <param name="posnum"></param>
        /// <returns></returns>
        public static string GetSiteIDByPosnum(string posnum)
        {
            string strSql = "SELECT siteid FROM pos_poslist WHERE posnum = '"+posnum+"'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["siteid"].ToString();
            return "";
        }
    }
}
