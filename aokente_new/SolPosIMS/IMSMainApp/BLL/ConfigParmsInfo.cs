using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Ims.Main.BLL
{
    public class ConfigParmsInfo
    { //
        //TODO: 在此处添加构造函数逻辑

        /// <summary>
        /// 是否自动签退(配置信息)
        /// </summary>
        static string s_strIsAutoSignOut = null;
        /// <summary>
        /// 获取自动签退的配置信息
        /// </summary>
        /// <returns></returns>
        static public bool IsAutoSignOut
        {
            get
            {
                bool isAuto = false;
                if (string.IsNullOrEmpty(s_strIsAutoSignOut))
                {
                    s_strIsAutoSignOut = ConfigurationManager.AppSettings["IsAutoSignOut"].ToString();
                }
                bool.TryParse(s_strIsAutoSignOut, out isAuto);
                return isAuto;
            }
        }
        /// <summary>
        /// 是否开启车位(配置信息)
        /// </summary>
        static string s_strIsHasSpot = null;
        /// <summary>
        /// 获取开启车位的配置信息
        /// </summary>
        /// <returns></returns>
        static public bool IsHasSpot
        {
            get
            {
                bool isAuto = false;
                if (string.IsNullOrEmpty(s_strIsHasSpot))
                {
                    s_strIsHasSpot = ConfigurationManager.AppSettings["IsHasSpot"].ToString();
                }
                bool.TryParse(s_strIsHasSpot, out isAuto);
                return isAuto;
            }
        }
        /// <summary>
        /// 是否开启图片(配置信息)
        /// </summary>
        static string s_strIsOpenPic = null;
        /// <summary>
        /// 获取开启图片的配置信息
        /// </summary>
        /// <returns></returns>
        static public bool IsOpenPic
        {
            get
            {
                bool isAuto = false;
                if (string.IsNullOrEmpty(s_strIsOpenPic))
                {
                    s_strIsOpenPic = ConfigurationManager.AppSettings["IsOpenPic"].ToString();
                }
                bool.TryParse(s_strIsOpenPic, out isAuto);
                return isAuto;
            }
        }
        /// <summary>
        /// 是否开启交易日志(配置信息)
        /// </summary>
        static string s_strIsTradeLog = null;
        /// <summary>
        /// 获取开启交易日志的配置信息
        /// </summary>
        /// <returns></returns>
        static public bool IsTradeLog
        {
            get
            {
                bool isAuto = false;
                if (string.IsNullOrEmpty(s_strIsTradeLog))
                {
                    s_strIsTradeLog = ConfigurationManager.AppSettings["IsWriteLog"].ToString();
                }
                bool.TryParse(s_strIsTradeLog, out isAuto);
                return isAuto;
            }
        }
        static string strLongitude = null;
        static string strLatitude = null;
        /// <summary>
        /// 获取默认的地图坐标配置信息
        /// </summary>
        /// <returns></returns>
        static public MapPositionXY mapPositionXY
        {
            get
            {
                MapPositionXY oMapPositionXY = new MapPositionXY();
                if (string.IsNullOrEmpty(strLongitude))
                {
                    strLongitude = ConfigurationManager.AppSettings["Longitude"].ToString();
                    
                }
                oMapPositionXY.longitude = strLongitude;
                if (string.IsNullOrEmpty(strLatitude))
                {
                    strLatitude = ConfigurationManager.AppSettings["Latitude"].ToString();

                }
                oMapPositionXY.latitude = strLatitude;
                return oMapPositionXY;
            }
        }
    }
}

