using System;
using System.Collections.Generic;
using System.Text;
using Ims.PM.BLL;

namespace Ims.PM.DAL
{
    public class PmEnableDAL
    {
        /// <summary>
        /// 获取能力资格认证的获取途径
        /// </summary>
        /// <param name="MethodId"></param>
        /// <returns></returns>
        public static string GetEnableMethod(string MethodId)
        {
            return PmTtBLLHelper.fromCodeToName(MethodId, "emethod");
        }
    }
}
