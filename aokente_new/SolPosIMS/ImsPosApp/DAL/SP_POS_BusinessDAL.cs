using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ims.Pos.Model;
using Ims.Pos.BLL;
using System.Web;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.DAL
{
    public class SP_POS_BusinessDAL
    {
        /// <summary>
        /// pos交易存储
        /// </summary>
        /// <param name="o">SP_POS_Transaction实体</param>
        /// <param name="OReBatchSnr">返回交易批次号</param>
        /// <param name="OReCredenceSnr">返回交易凭证号</param>
        /// <param name="OBalance">卡上余额</param>
        /// <param name="OIntegral">本次积分</param>
        /// <param name="OTotalInteger">累计积分</param>
        /// <param name="OShopCode">商户编号</param>
        /// <param name="OShopName">商户名称</param>
        /// <param name="OServerWasteSnr">服务器端流水号</param>
        /// <param name="OExpDate">卡有效期</param>
        /// <param name="ORemark">备注信息</param>
        /// <param name="Rstr">返回结果</param>
        /// <returns>DataSet</returns>
        public static output_Business Pos_Trans(string possnr,string version,BusinessObjects oInput)
        {
            SqlParameter[] Para = new SqlParameter[]{                 
               new SqlParameter("POSSNR", SqlDbType.VarChar,20), 
               new SqlParameter("@BatchSnr", SqlDbType.VarChar,20),   
               new SqlParameter("@CredenceSnr",SqlDbType.VarChar,50),                  
               new SqlParameter("@CardSnr",SqlDbType.VarChar,16),
               new SqlParameter("@UserID", SqlDbType.VarChar,15),
               new SqlParameter("@PIN",SqlDbType.VarChar,50),                  
               new SqlParameter("@Money",SqlDbType.Decimal,10),
               new SqlParameter("@RealMoney",SqlDbType.Decimal,10),
               new SqlParameter("@ReturnMoney",SqlDbType.Decimal,10),
               new SqlParameter("@Datetime", SqlDbType.VarChar,20), 
               new SqlParameter("@Mode", SqlDbType.VarChar,5),   
               new SqlParameter("@RecordType",SqlDbType.VarChar,5),
               new SqlParameter("@CardType",SqlDbType.VarChar,5), 
               new SqlParameter("@SysID",SqlDbType.VarChar,10),
               new SqlParameter("@StartTime",SqlDbType.VarChar,20),
               new SqlParameter("@EndTime",SqlDbType.VarChar,20),
               new SqlParameter("@BackByte",SqlDbType.VarChar,20),
               new SqlParameter("@carpicture",SqlDbType.Text),
               new SqlParameter("@giving",SqlDbType.Decimal),
               new SqlParameter("@memo",SqlDbType.VarChar,500),
               new SqlParameter("@ret",SqlDbType.Int),
            };
            Para[0].Value = string.IsNullOrEmpty(possnr) ? "nothing" : possnr;//终端号
            Para[1].Value = oInput.BatchSnr;//交易批次号
            Para[2].Value = string.IsNullOrEmpty(oInput.CredenceSnr) ? "" : oInput.CredenceSnr;//交易凭证号
            Para[3].Value = string.IsNullOrEmpty(oInput.CardSnr) ? "" : oInput.CardSnr;//磁条卡卡号 磁条卡已暂停使用暂用CARDSNR替代
            Para[4].Value = oInput.UserID;
            //Para[5].Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(string.IsNullOrEmpty(oInput.Pin) ? "" : oInput.Pin, "MD5"); ;//密码
            Para[5].Value = oInput.Pin;//密码
            Para[6].Value = oInput.Money;//应当缴费金额
            Para[7].Value = oInput.RealMoney;//实际缴费金额
            Para[8].Value = oInput.ReturnMoney;//退款金额
            Para[9].Value = oInput.DateTime;//发生时间
            Para[10].Value = oInput.Mode;
            Para[11].Value = "0";//记录类型目前都为0
            Para[12].Value = oInput.CardType;//车辆类型
            Para[13].Value = version;//协议版本号
            Para[14].Value = oInput.StartTime;//停车开始时间
            Para[15].Value = oInput.EndTime;//停车开始时间
            Para[16].Value = oInput.BackByte;//车位编号
            //oInput.carpicture = HttpContext.Current.Server.UrlEncode(oInput.carpicture);//将urlencode的图片字符串直接存到数据库，取出来时再decode，防止数据库存储错误
            Para[17].Value = oInput.carpicture;//车的图片
            Para[18].Value = oInput.giving;//押金
            Para[19].Value = oInput.memo;//备注
            Para[20].Direction = ParameterDirection.ReturnValue;

            DataSet ds = SQLHelper.QueryStored("SP_POS_Transaction", CommandType.StoredProcedure, Para);//参数是否缺失
            output_Business oOutput = new output_Business();
            oOutput.FLAG = Para[20].Value.ToString();
            return oOutput;
        }

        public static DataTable uploadParkingRecord(string successid)
        { 
            string sql = "select CredenceSnr,CardSnr,CardType,sitename,BackByte,Mode,UserID,PosSnr,Money,giving,RealMoney,ReturnMoney,StartTime,EndTime,SysID,memo " +
                         " from tb_pos_transaction where CredenceSnr in (" + successid + ")";

            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dt;
        }
    }
}
