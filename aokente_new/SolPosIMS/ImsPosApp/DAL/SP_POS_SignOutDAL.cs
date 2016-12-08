using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Ims.Pos.Model;
using Ims.Pos.BLL;

namespace Ims.Pos.DAL
{
    public class SP_POS_SignOutDAL
    {
        /// <summary>
        /// 签退
        /// </summary>
        /// <param name="o">SP_POS_SignOut实体</param>
        /// <param name="Rstr">返回结果</param>
        /// <returns>DataSet</returns>
        public static output_SignOut Pos_Out(input_SignOut oInput, ref int Rstr)
        {
            SqlParameter[] Para = new SqlParameter[]{
               new SqlParameter("@PosSnr", SqlDbType.VarChar,20),   
               new SqlParameter("@UserID",SqlDbType.VarChar,20),
               new SqlParameter("@Password",SqlDbType.VarChar,50),                  
               new SqlParameter("@BatchSnr",SqlDbType.VarChar,15),
               new SqlParameter("@StartDate",SqlDbType.VarChar,20),
               new SqlParameter("@EndDate",SqlDbType.VarChar,20),

               new SqlParameter("@BusinessAmount",SqlDbType.VarChar,15),
               new SqlParameter("@BusinessCount",SqlDbType.VarChar,15),
               new SqlParameter("Rstr",SqlDbType.Int,4),
            };
            Para[0].Value = oInput.POSSNR;
            Para[1].Value = oInput.UserID;
            Para[2].Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oInput.Password, "MD5");
            Para[3].Value = oInput.BatchSnr;
            Para[4].Value = oInput.StartDate;
            Para[5].Value = oInput.EndDate;
            Para[6].Value = oInput.BusinessAmount;
            Para[7].Value = oInput.BunsinessCount;
            Para[8].Direction = ParameterDirection.ReturnValue;
            //Para[15].Direction = ParameterDirection.Output;  
           
            DataSet ds = SQLHelper.QueryStored("SP_POS_SignOut", CommandType.StoredProcedure, Para);
            output_SignOut oOutput = new output_SignOut();
            oOutput.UserID = oInput.UserID;
            oOutput.BackByte = "";
            oOutput.FLAG = Para[8].Value.ToString();
            oOutput.MESSAGE = POS＿CommunicationHelper.GetErrMsgByErrCode(oOutput.FLAG);
            return oOutput;
        }
    }
}
