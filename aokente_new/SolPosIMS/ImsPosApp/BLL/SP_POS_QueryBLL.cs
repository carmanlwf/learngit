using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.DAL;
using Ims.Pos.Model;
using System.Data;
namespace Ims.Pos.BLL
{
    public class SP_POS_QueryBLL
    {

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Pos_QueryMoney(SP_POS_ALLParams o)
        {
            string RetStr = "";
            DataSet dsQuery = SP_POS_QueryDAL.Pos_Query(o);
            o.MAGCARD = string.IsNullOrEmpty(o.MAGCARD) ? o.CARDSNR.ToString() : o.MAGCARD;
            RetStr = "CMD=03\r\nPACKCOUNT=6\r\nPOSSNR=" + o.POSSNR + "\r\nFLAG=" + o.FLAG + "\r\nVERSIION=2.0\r\nMagcard=" + o.MAGCARD + "\r\nCardSnr=" + o.MAGCARD + "\r\nBalance=" + o.BALANCE + "\r\nTotalMoney=" + o.TOTALMONEY + "\r\nTotalIntegral=" + o.TOTALINTEGRAL + "\r\nBackByte=";
            return RetStr;
        }
    }
}
