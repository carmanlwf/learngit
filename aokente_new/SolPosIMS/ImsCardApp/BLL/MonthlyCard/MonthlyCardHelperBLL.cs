using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.DAL.MonthlyCard;
using Ims.Card.Model.MonthlyCard;
using System.Data;

namespace Ims.Card.BLL.MonthlyCard
{
    public class MonthlyCardHelperBLL
    {
        /// <summary>
        ///  新建月卡（新办用户卡/消费卡->月卡/月卡->月卡）
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string MonthlyCardCreate(MonthlyCardCreate o, string operatorid)
        {
            return MonthlyCardHelperDAL.MonthlyCardCreate(o,operatorid);
        }
        /// <summary>
        /// 获取站点信息列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSiteListInfo()
        {
            DataTable dt = MonthlyCardHelperDAL.GetSiteListInfo();
            return dt;
        }
    }
}
