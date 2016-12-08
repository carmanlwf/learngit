using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.DAL;
using System.Data;
using Ims.Pos.Model.PriceList;
using Newtonsoft.Json;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.BLL
{
    public class GetPriceListHelperBLL
    {
        /// <summary>
        /// 在场车辆记录
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static string GetParkSitePrice(string possnr)
        {
            string ret_str = "";
            output_PriceList oOutput = new output_PriceList();
            oOutput.FLAG = "-1";
            oOutput.MESSAGE = "server error";
            DataTable dt = GetPriceListHelperDAL.GetParkSitePrice(possnr);
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    DataBindHelper.BindDataRowToObj(dt.Rows[0], oOutput);
                    oOutput.FLAG = "0";
                    oOutput.MESSAGE = "";
                }
                catch
                {
                    oOutput.FLAG = "-1";
                    oOutput.MESSAGE = "expection occurs";
                }
            }
            else
            {
                oOutput.FLAG = "-1";
                oOutput.MESSAGE = "datatable is null";
            }
            ret_str = JavaScriptConvert.SerializeObject(oOutput);
            return ret_str;
        }
    }
}