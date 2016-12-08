using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model.ModifyPass;
using Ims.Pos.DAL;
using Newtonsoft.Json;
using System.Web.Security;

namespace Ims.Pos.BLL
{
    public class ModifyPassHelperBLL
    {
        public static string modifyPass(input_ModifyPass oInput)
        {
            string RetStr = "";
            output_ModifyPass oOutput = new output_ModifyPass();
            if (!ModifyPassHelperDAL.checkUserExist(oInput.userid))
            {
                oOutput.FLAG = "0";
                oOutput.MESSAGE = "用户不存在";
                RetStr = JavaScriptConvert.SerializeObject(oOutput);
                return RetStr;
            }

            if (!ModifyPassHelperDAL.checkPassIsCorrect(oInput.userid, FormsAuthentication.HashPasswordForStoringInConfigFile(oInput.oldpass, "MD5")))
            {
                oOutput.FLAG = "0";
                oOutput.MESSAGE = "密码错误";
                RetStr = JavaScriptConvert.SerializeObject(oOutput);
                return RetStr;
            }

            ModifyPassHelperDAL.modifyPass(oInput.userid, FormsAuthentication.HashPasswordForStoringInConfigFile(oInput.newpass, "MD5"));
            oOutput.FLAG = "1";
            oOutput.MESSAGE = "修改密码成功";
            RetStr = JavaScriptConvert.SerializeObject(oOutput);
            return RetStr;
            
        }
    }
}
