using System;
using System.Collections.Generic;
using System.Text;
using Ims.PM.BLL;

namespace Ims.PM.DAL
{
    public class PmMoveDAL
    {
        /// <summary>
        /// 获取原岗位信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetStation(string code)
        {
            string wheresql = " where code = '" + code + "'";
            string station = PmTtBLLHelper.GetSingleString(wheresql, "pm_employee", "station");
            string stationname = "";
            if (station != "")
            {
                string otherwheresql = " where code = '" + station + "' and typecode = 'station'";
                stationname = PmTtBLLHelper.GetSingleString(otherwheresql, "pm_codes", "name");
            }
            return stationname;
        }
    }
}
