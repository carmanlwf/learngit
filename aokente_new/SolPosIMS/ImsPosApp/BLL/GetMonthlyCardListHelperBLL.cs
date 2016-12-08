using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model.MonthlyCard;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Pos.DAL;
using Newtonsoft.Json;

namespace Ims.Pos.BLL
{
    public class GetMonthlyCardListHelperBLL
    {
        public static string GetMonthlyCardListInfo(string posnum)
        {
            string ret_str = "";
            output_MonthlyCard oOutput = new output_MonthlyCard();
            oOutput.FLAG = "-1";
            oOutput.MESSAGE = "server error";
            DataTable dt = GetMonthlyCardListHelperDAL.GetMonthlyCardListInfo(posnum);
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<CardInfo> list = new List<CardInfo>();
                    DataBindHelper.BindDataTableToObjArray(dt, typeof(CardInfo), list);
                    oOutput.cardlist = list;
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
