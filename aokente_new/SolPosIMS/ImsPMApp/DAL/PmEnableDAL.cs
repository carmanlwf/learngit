using System;
using System.Collections.Generic;
using System.Text;
using Ims.PM.BLL;

namespace Ims.PM.DAL
{
    public class PmEnableDAL
    {
        /// <summary>
        /// ��ȡ�����ʸ���֤�Ļ�ȡ;��
        /// </summary>
        /// <param name="MethodId"></param>
        /// <returns></returns>
        public static string GetEnableMethod(string MethodId)
        {
            return PmTtBLLHelper.fromCodeToName(MethodId, "emethod");
        }
    }
}
