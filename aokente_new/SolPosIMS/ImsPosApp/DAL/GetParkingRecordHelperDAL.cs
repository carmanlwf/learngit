using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;
using System.Data;

namespace Ims.Pos.DAL
{
    public class GetParkingRecordHelperDAL
    {


        public static DataTable GetParkingRecordByPossnr(string Possnr, long timestamp)
        {
            string strSql = @"SELECT TOP 100 a.CredenceSnr,a.CardSnr,a.CardType,a.StartTime,a.EndTime,a.giving,a.UserID,a.BackByte,a.[Money],a.memo,a.Mode,a.RealMoney,a.UserID,a.carpicture,b.balance as userMoney FROM tb_POS_Transaction as a 
            LEFT JOIN tb_card as b on a.CardSnr = b.[card]  WHERE left(StartTime,10)=LEFT((CONVERT([varchar](20),getdate(),(120))),10) AND Possnr in (SELECT posnum FROM pos_poslist WHERE siteid in (Select siteid from pos_poslist Where posnum ='" + Possnr + "')) And update_timestamp > " + timestamp + "";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// 在场车辆记录
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static DataTable GetParkingRecordBySiteID(string siteid)
        {
            string strSql = "SELECT distinct TOP 100  CredenceSnr,CardSnr,CardType,StartTime,EndTime,giving,UserID,BackByte,Money,memo,Mode,RealMoney,UserID,'' FROM tb_POS_Transaction Where Possnr in (SELECT posnum FROM pos_poslist WHERE siteid = '" + siteid + "') And Mode = 0 And StartTime >= '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
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
            string strSql = "INSERT INTO pos_tracelist (lng,lat,possnr,operatorid,isOutBounds)VALUES('" + lng + "','" + lat + "','" + Possnr + "','" + uid + "','" + isOutBounds + "')";
            int ret = DataExecSqlHelper.ExecuteNonQuerySql(strSql);
            return ret;
        }

        public static string getCountBySiteId(string siteid)
        {
            string strSql = "SELECT count(*) FROM park_parkingsite WHERE siteid = '" + siteid + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt.Rows[0][0].ToString();
        }


    }
        
}
