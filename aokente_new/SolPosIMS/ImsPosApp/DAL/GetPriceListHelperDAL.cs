using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.DAL
{
    public class GetPriceListHelperDAL
    {
        /// <summary>
        /// 计价体系下载
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static DataTable GetParkSitePrice(string possnr)
        {
            string strSql = @"  SELECT a.segmentId,a.ruleId,a.timeNode1,a.isautoout,b.detailId,b.price,b.timeNode2,b.timeSpan
                        FROM price_priceRuleSegment AS a
                        INNER JOIN  dbo.price_priceRuleSegmentDetail AS b ON a.segmentId = b.segmentId 
                        INNER JOIN price_priceParkingLotRule as c ON c.ruleId = a.ruleId
                        LEFT join pos_poslist as d ON c.siteid = d.siteid  
                        WHERE d.posnum = ''";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
    }
}
