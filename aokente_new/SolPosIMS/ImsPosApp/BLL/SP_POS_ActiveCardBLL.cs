using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model;
using Ims.Pos.DAL;

namespace Ims.Pos.BLL
{
    public class SP_POS_ActiveCardBLL
    {
        /// <summary>
        /// 激活卡片
        /// </summary>
        /// <param name="o">签到实体</param>
        /// <param name="Ostr">输出参数</param>
        /// <param name="Rstr">返回值</param>
        /// <returns>返回DataTable</returns>
        public static string Pos_ActiveCard(SP_POS_ALLParams o)
        {
            string RetStr = "";
            o.FLAG = SP_POS_ActiveCardDAL.SP_POS_ActiveCard(o);
            o.REMESSAGE = "操作成功!";
            if (o.FLAG == "1")
            {
                o.REMESSAGE = "卡不存在!";
            }
            else if (o.FLAG == "7")
            {
                o.REMESSAGE = "终端未注册!";
            }
            else if (o.FLAG == "15")
            {
                o.REMESSAGE = "手机号码已存在!";
            }
            RetStr = "CMD=80\r\nPACKCOUNT=4\r\nMESSAGE=" + o.REMESSAGE + "\r\nFLAG=" + o.FLAG + "";
            return RetStr;
        }
    }
}
