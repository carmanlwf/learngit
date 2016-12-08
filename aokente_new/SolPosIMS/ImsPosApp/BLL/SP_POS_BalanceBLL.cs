using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.DAL;
using Ims.Pos.Model;
using System.Data;

namespace Ims.Pos.BLL
{
    public class SP_POS_BalanceBLL
    {

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string POS_Balance(SP_POS_ALLParams o)
        {
            string RetStr = "";
            DataSet dsQuery = SP_POS_BalanceDAL.SP_POS_Balance(o);
            RetStr = "CMD=97\r\nPACKCOUNT=15\r\nSHOPNAME=" + o.SHOPNAME + "\r\nFLAG=" + o.FLAG + "\r\nPOSSNR=" + o.POSSNR + "\r\nVERSIION=20141203\r\nBatchSnr=" + o.BATCHSNR + "\r\nNextBatchSnr=" + o.NEXTBATCHSNR + "\r\nUserID=" + o.USERID + "\r\nStartDate=" + o.STARTDATE + "\r\nEndDate=" + o.ENDDATE + "\r\nBusinessAmount=" + o.BUSINESSAMOUNT * 100 + "\r\nBusinessCount=" + o.BUSINESSCOUNT + "\r\nCancelAmount=" + o.CANCELAMOUNT * 100 + "\r\nCancelCount=" + o.CANCELCOUNT + "\r\nIntegralAmount=" + o.INTEGRALAMOUNT * 100 + "\r\nIntegralCount=" + o.INTEGRALCOUNT + "\r\nCancelIntegralAmount=" + o.CANCELINTEGRALAMOUNT * 100 + "\r\nCancelIntegralCount=" + o.CANCELINTEGRALCOUNT + "\r\nChargeAmount=" + decimal.Parse(o.ChargeAmount) * 100 + "\r\nChargeCount=" + o.ChargeCount + "\r\nRemark=" + o.REMARK + "\r\nBackByte=1";
            return RetStr;
        }
    }
}
