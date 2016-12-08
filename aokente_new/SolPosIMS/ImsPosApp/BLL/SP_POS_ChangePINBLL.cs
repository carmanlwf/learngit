using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.Model;
using Ims.Pos.DAL;

namespace Ims.Pos.BLL
{
   public  class SP_POS_ChangePINBLL
    {

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="o">签到实体</param>
        /// <param name="Ostr">输出参数</param>
        /// <param name="Rstr">返回值</param>
        /// <returns>返回DataTable</returns>
       public static string Pos_ChangePINDAL(SP_POS_ALLParams o)
        {
            string RetStr = "";
            DataSet DsIn = SP_POS_ChangePINDAL.Pos_ChangePINDAL(o);
            RetStr = "CMD=80\r\nPACKCOUNT=4\r\nMESSAGE=" + o.REMESSAGE + "\r\nFLAG=" + o.FLAG + "";
            return RetStr;
        }
    }
}
