using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Card.DAL
{
    public class CardRuleHelperDAL
    {
        static public string getRule(decimal amount, string type)
        {
            if(type.Trim() =="临时卡")
                return "当前无任何优惠,0";
            string sql = "Select top 1 rulename,gift From card_chargerule Where flag = 1 And amount ="+amount+"";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["rulename"].ToString() + "," + dt.Rows[0]["gift"].ToString(); ;
            return "该金额不享受任何优惠,0";
        }
    }
}
