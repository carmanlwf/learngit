using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.DAL;
using Ims.Pos.Model;
using Newtonsoft.Json;

namespace Ims.Pos.BLL
{
    public class SP_POS_SignOutBLL
    {

        /// <summary>
        /// 签退
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Pos_Out(input_SignOut oInput)
        {
            int Rstr = 0;
            string RetStr = "";
            output_SignOut oOutput = SP_POS_SignOutDAL.Pos_Out(oInput, ref Rstr);
            if (oOutput.BackByte == null) oOutput.BackByte = "";
            if (oOutput.UserID == null) oOutput.UserID = "";
            RetStr = JavaScriptConvert.SerializeObject(oOutput);
            return RetStr;
        }

    }
}
