using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ims.Pos.Model;
using Ims.Pos.BLL;
using ZsdDotNetLibrary.Data;
using Ims.Pos.Model.SignIn;
using System.Configuration;
using Ims.Main.BLL;
namespace Ims.Pos.DAL
{
    public class SP_POS_SignINDAL
    {
        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="o">签到实体</param>
        /// <param name="Ostr">输出参数</param>
        /// <param name="Rstr">返回值</param>
        /// <returns>返回DataTable</returns>
        public static output_SignIn Pos_In(input_SignIn oInput)
        {
            SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("PosSnr", SqlDbType.VarChar,20),   
               new SqlParameter("UserID",SqlDbType.VarChar,20),
               new SqlParameter("UserPIN",SqlDbType.VarChar,50),                  
               new SqlParameter("retstr",SqlDbType.Int,4),
               new SqlParameter("CommPassword",SqlDbType.VarChar,50),
               new SqlParameter("Datetime",SqlDbType.VarChar,50),
               new SqlParameter("PWDID",SqlDbType.VarChar,50)

            };
            Para[0].Value = oInput.POSSNR;//pos机号
            Para[1].Value = oInput.UserID;//用户编号
            Para[2].Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oInput.Password, "MD5");
            Para[3].Direction = ParameterDirection.ReturnValue;
            Para[4].Direction = ParameterDirection.Output;
            Para[5].Direction = ParameterDirection.Output;
            Para[6].Direction = ParameterDirection.Output;
            DataSet ds = SQLHelper.QueryStored("SP_POS_SignIN", CommandType.StoredProcedure, Para);
            output_SignIn oOutput = new output_SignIn();
            oOutput.CommPassword = Para[4].Value.ToString();
            oOutput.Datetime = Para[5].Value.ToString();
            oOutput.PWDID = Para[6].Value.ToString();
            string[] val = GetSiteConfigInfoByPossnr(oInput.POSSNR);
            if(val!=null)
            {
                oOutput.sitename = val[0];//机器号获取路段名称
                oOutput.Longitude = val[1];//经度
                oOutput.LimitsFar = val[2];//限制距离
                oOutput.Latitude = val[3];//纬度
            }

            oOutput.note = TipTltle();// "欢迎使用路边停车收费管理系统";
            oOutput.sitefeelist = GetSitePriceByPossnr(oInput.POSSNR);//机器号获取路段收费价格体系
            bool isopenpic = ConfigParmsInfo.IsOpenPic;
            oOutput.IsOpenPic = isopenpic;
            bool ishasspot = ConfigParmsInfo.IsHasSpot;
            oOutput.IsHasSpot = ishasspot;
            if (!DBNull.Value.Equals(Para[3].Value))
            {
                oOutput.FLAG = Para[3].Value.ToString();
                oOutput.MESSAGE = POS＿CommunicationHelper.GetErrMsgByErrCode(oOutput.FLAG);
            }
            return oOutput;
        }

        public static string TipTltle()
        {
            string sql = @"select (case when  Banners is null then '欢迎使用路边停车收费管理系统' else Banners end ) as banners from dbo.Ims_Config";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
           string val = "欢迎使用路边停车收费管理系统";
           if (dt != null && dt.Rows.Count > 0)
            {
                val = dt.Rows[0]["banners"].ToString();
            }

            return val;
        }
       
        /// <summary>
        /// 根据机器号获取相应的路段名称
        /// </summary>
        /// <param name="possnr"></param>
        /// <returns></returns>
        public static string[] GetSiteConfigInfoByPossnr(string possnr)
        {
            string[] s_config = null;
            string strSql = @"SELECT a.sitename,
case when ISNUMERIC(a.Longitude) = 0  then '0' else a.Longitude end as Longitude,
case when ISNUMERIC(a.LimitsFar) = 0  then '0' else a.LimitsFar end as LimitsFar,
case when ISNUMERIC(a.Latitude) = 0  then '0' else a.Latitude end as Latitude FROM tb_site as a WHERE a.id in(SELECT siteid FROM pos_poslist WHERE posnum = '" + possnr + "')";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                s_config = new string[]{ dt.Rows[0]["sitename"].ToString(), dt.Rows[0]["Longitude"].ToString(), dt.Rows[0]["LimitsFar"].ToString(), dt.Rows[0]["Latitude"].ToString() };
            }
            return s_config;
        }
        /// <summary>
        /// 根据机器号获取相应的路段的收费标准(多条)
        /// </summary>
        /// <param name="possnr"></param>
        /// <returns></returns>
        public static List<p_sitefeelist> GetSitePriceByPossnr(string possnr)
        {
            List<p_sitefeelist> oList =new List<p_sitefeelist>();

            string strSql = @"SELECT carType,startWorkTime,endWorkTime,minPayment,maxPayment,firstChargingTimeSeg,normalChargingTimeSeg,normalChargingPrice,freeTimeSeg,isChargByTimes,memo,IsFullTiming,FisrtChargingTimes FROM dbo.v_price_temp_sitefeelist WHERE siteid in(SELECT siteid FROM pos_poslist WHERE posnum = '" + possnr + "')";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataBindHelper.BindDataTableToObjArray(dt, typeof(p_sitefeelist), oList);
            }
            return oList;
        }

        /// <summary>
        /// 操作员登录
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool CheckUserLogin(string uid, string pass)
        {
            string strSql = "SELECT COUNT(1) FROM tb_Pos_Operator WHERE [operatorid] ='"+uid+"' And pass = '"+pass+"'";
            int ret = (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
            if (ret > 0)
                return true;
            else
                return false;
        }
    }
}
