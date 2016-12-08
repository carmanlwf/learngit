using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.DAL;
using Ims.Pos.Model;
using ZsdDotNetLibrary.Data;
using Newtonsoft.Json;
using Ims.Pos.Model.MonthlyCard;

namespace Ims.Pos.BLL
{
    public class GetParkingRecrodHelperBLL
    {
        /// <summary>
        /// 根据pos机号获取所属停车场的所有记录
        /// </summary>
        /// <param name="Possnr"></param>
        /// <returns></returns>
        public static string GetParkingRecordByPossnr(string Possnr,long timestamp)
        {
            string ret_str = "";
            output_SyncParkingRecord oOutput = new output_SyncParkingRecord();
            oOutput.FLAG = "-1";
            oOutput.MESSAGE = "server error";
            DataTable dt = GetParkingRecordHelperDAL.GetParkingRecordByPossnr(Possnr,timestamp);
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<ParkingRecordObjects> list = new List<ParkingRecordObjects>();
                    DataBindHelper.BindDataTableToObjArray(dt, typeof(ParkingRecordObjects), list);
                    oOutput.ParkingRecordItems = list;
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
                oOutput.ParkingRecordItems = new List<ParkingRecordObjects>();
            }

            DataTable dt1 = GetMonthlyCardListHelperDAL.GetMonthlyCardListInfo(Possnr);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                try
                {
                    List<CardInfo> list = new List<CardInfo>();
                    DataBindHelper.BindDataTableToObjArray(dt1, typeof(CardInfo), list);
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
                oOutput.cardlist = new List<CardInfo>();
                if (null == dt || dt.Rows.Count == 0)
                {
                    oOutput.FLAG = "-1";
                    oOutput.MESSAGE = "datatable is null";
                }
            }
            ret_str = JavaScriptConvert.SerializeObject(oOutput);
            return ret_str;
        }
        /// <summary>
        /// 在场车辆记录
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static string GetParkingRecordBySiteID(string siteid)
        {
            string ret_str = "";
            output_SyncParkingRecord oOutput = new output_SyncParkingRecord();
            oOutput.FLAG = "-1";
            oOutput.MESSAGE = "server error";
            DataTable dt = GetParkingRecordHelperDAL.GetParkingRecordBySiteID(siteid);
            string count = GetParkingRecordHelperDAL.getCountBySiteId(siteid);
            oOutput.count = count;
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    List<ParkingRecordObjects> list = new List<ParkingRecordObjects>();
                    DataBindHelper.BindDataTableToObjArray(dt, typeof(ParkingRecordObjects), list);
                    oOutput.ParkingRecordItems = list;
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
        /// <summary>
        /// 定时记录终端的gps坐标
        /// </summary>
        /// <param name="Possnr"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int Insert_GPS_Points(string Possnr, string lng, string lat, string uid, string isOutBounds)
        {
            return GetParkingRecordHelperDAL.Insert_GPS_Points(Possnr, lng, lat, uid, isOutBounds);
        }
    }
}
