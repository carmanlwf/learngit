using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.DAL;
using Ims.Pos.Model.SiteList;
using ZsdDotNetLibrary.Data;
using Newtonsoft.Json;

namespace Ims.Pos.BLL
{
    public class GetSiteListHelperBLL
    {
        public static string GetSiteListInfo()
        {
            string ret_str = "";
            output_SiteList oOutput = new output_SiteList();
            oOutput.FLAG = "-1";
            oOutput.MESSAGE = "server error";
            DataTable dt = GetSiteListHelperDAL.GetSiteListInfo();
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<SiteInfo> list = new List<SiteInfo>();
                    DataBindHelper.BindDataTableToObjArray(dt, typeof(SiteInfo), list);
                    oOutput.sitelist = list;
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
