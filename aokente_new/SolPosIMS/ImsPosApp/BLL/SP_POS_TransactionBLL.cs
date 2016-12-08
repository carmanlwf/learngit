using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ims.Pos.Model;
using Ims.Pos.DAL;
using System.Xml;

namespace Ims.Pos.BLL
{
    public class SP_POS_TransactionBLL
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
        public static DataSet Pos_Trans(
            SP_POS_ALLParams o)
        {
            return SP_POS_TransactionDAL.Pos_Trans(o);
        }

        /// <summary>
        /// 根据时间删除交易记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int DeletePOS_TransactionbyTime(string time1, string time2)
        {
            return DAL.SP_POS_TransactionDAL.DeletePOS_TransactionbyTime(time1, time2);
        }

        /// <summary>
        /// 删除全部交易记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int DeletePOS_Transaction()
        {
            return DAL.SP_POS_TransactionDAL.DeletePOS_Transaction();
        }
        public static string Ds_XML(DataSet ds)
        {
            System.IO.TextWriter TW = new System.IO.StringWriter();
            ds.WriteXml(TW);
            return TW.ToString();
        }
        public static string[] GetBackByte(int Rstr)
        {

            string[] Str = new string[2];
            Str[1] = "01";
            switch (Rstr)
            {
                case 0:
                    Str[0] = "交易成功";
                    Str[1] = "00";
                    break;
                case 1:
                    Str[0] = "卡不存在";
                    break;
                case 2:
                    Str[0] = "卡已挂失";
                    break;
                case 3:
                    Str[0] = "用户卡密码错误";
                    break;
                case 4:
                    Str[0] = "余额不足";
                    break;
                case 6:
                    Str[0] = "卡已过期";
                    break;
                case 7:
                    Str[0] = "终端未注册";
                    break;
                case 192:
                case 193:
                case 194:
                case 294:
                    Str[0] = "交易成功";
                    Str[1] = "00";
                    break;
                case 255:
                    Str[0] = "卡已过期";
                    break;
            }
            return Str;
        }
        public static string PosReturnStr(SP_POS_ALLParams OParams)
        {
            string RetStr = "";

            OParams.MONEY = OParams.MONEY / 100;
            try
            {
                switch (OParams.CMD)
                {
                    case "01": //签到 
                        //RetStr = SP_POS_SignINBLL.Pos_In(OParams);
                        break;
                    case "02": //签退
                       // RetStr = SP_POS_SignOutBLL.Pos_Out(OParams);
                        break;
                    case "03": //查询余额
                        RetStr = SP_POS_QueryBLL.Pos_QueryMoney(OParams);
                        break;
                    case "04":// 消费 
                        RetStr = Pos_Consume(OParams);
                        break;
                    case "97":// 结算 
                        RetStr = SP_POS_BalanceBLL.POS_Balance(OParams);
                        break;

                    case "80":// 修改密码 
                        RetStr = SP_POS_ChangePINBLL.Pos_ChangePINDAL(OParams);
                        break;
                    case "90":// 卡片激活 
                        RetStr = SP_POS_ActiveCardBLL.Pos_ActiveCard(OParams);
                        break;
                    case "98": //同步交易密钥
                        RetStr = "CMD=98\r\nPACKCOUNT=2\r\nPOSSNR=" + OParams.POSSNR + "\r\nFLAG=00\r\nVERSIION=1.0\r\nPasswordData=!@#$QWER|12345678|12345678|12345678|12345678|12345678|12345678|12345678\r\nBackByte=";
                        break;
                    case "99": //更新系统参数
                        RetStr = "CMD=99\r\nPACKCOUNT=9\r\nPOSSNR=" + OParams.POSSNR + "\r\nFLAG=00\r\nVERSIION=1.0\r\nShopSnr=10000001\r\nShopName=网络部测试店\r\nBatchSnr=001\r\nICPWD=\r\nICScr=\r\nOther=\r\nPrintMsg=\r\nFlag=00\r\nBackByte=";
                        break;
                    default:
                        RetStr = "{\"FLAG\":\"315\",\"BackByte\":\"没有对应的返回值 \"}";
                        break;
                }
            }
            catch (Exception ex)
            {
                RetStr = "{\"FLAG\":\"0\",\"MSG\":\"" + ex.Message + "\"}";
            }
            return RetStr;
        }
        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static string Pos_Consume(SP_POS_ALLParams o)
        {
            string RetStr = "";
            DataSet ds_Trans = new DataSet();
            ds_Trans = SP_POS_TransactionBLL.Pos_Trans(o);
            o.MAGCARD = string.IsNullOrEmpty(o.MAGCARD) ? o.CARDSNR : o.MAGCARD;
            //if (ds_Trans != null && ds_Trans.Tables.Count > 0)
            //{
            o.REMARK = GetErrMsgByErrCode(o.FLAG);
                RetStr = "CMD=04\r\nPACKCOUNT=18\r\nPOSSNR=" + o.POSSNR + "\r\nFLAG=" + o.FLAG + "\r\nVERSIION=1.0\r\nBatchSnr=" + o.BATCHSNR.ToString() + "\r\nCredenceSnr=" + o.RECREDENCESNR + "\r\nMagcard=" + o.CARDSNR.ToString() + "\r\nUserID=" + o.USERID.ToString() + "\r\nPIN=" + o.PIN + "\r\nMoney=" + (o.MONEY * 100).ToString() + "\r\nBalance=" + (o.BALANCE * 100).ToString() + "\r\nIntegral=" + o.INTEGRAL.ToString() + "\r\nTotalInteger=" + o.TOTALINTEGER.ToString() + "\r\nShopCode=" + o.SHOPCODE + "\r\nShopName=" + o.SHOPNAME + "\r\nServerWasteSnr=" + o.SERVERWASTESNR + "\r\nDatetime=" + o.DATETIME + "\r\nExpDate=" + o.EXPDATE + "\r\nMode=" + o.MODE.ToString() + "\r\nRecordType=" + o.RECORDTYPE.ToString() + "\r\nCardType=" + o.CARDTYPE.ToString() + "\r\nFLAG=" + o.FLAG + "\r\nRemark=" + o.REMARK;
            //}
            //else//冲正交易，返回金额，积分为0
            //{
            //    RetStr = "CMD=04\r\nPACKCOUNT=18\r\nPOSSNR=" + o.POSSNR + "\r\nFLAG=8\r\nVERSIION=1.0\r\nBatchSnr=" + o.BATCHSNR.ToString() + "\r\nCredenceSnr=" + o.RECREDENCESNR + "\r\nMagcard=" + o.CARDSNR.ToString() + "\r\nUserID=" + o.USERID.ToString() + "\r\nPIN=" + o.PIN + "\r\nMoney=" + (o.MONEY * 100).ToString() + "\r\nBalance=" + (o.BALANCE * 100).ToString() + "\r\nIntegral=" + o.INTEGRAL.ToString() + "\r\nTotalInteger=" + o.TOTALINTEGER.ToString() + "\r\nShopCode=" + o.SHOPCODE + "\r\nShopName=" + o.SHOPNAME + "\r\nServerWasteSnr=" + o.SERVERWASTESNR + "\r\nDatetime=" + o.DATETIME + "\r\nExpDate=" + o.EXPDATE + "\r\nMode=" + o.MODE.ToString() + "\r\nRecordType=" + o.RECORDTYPE.ToString() + "\r\nCardType=" + o.CARDTYPE.ToString() + "\r\nFLAG=" + o.FLAG + "\r\nRemark=服务器操作失败";
            //}
            return RetStr;
        }
        public static string GetErrMsgByErrCode(string errCode)
        {
            switch (errCode)
            {
                case "0":
                    return "交易成功【OK】";
                case "1":
                    return "卡不存在【!!!】";
                case "2":
                    return "卡已挂失【!!!】";
                case "3":
                    return "用户卡密码错误【!!!】";
                case "4":
                    return "卡上余额不足本次交易【!!!】";
                case "5":
                    return "卡上积分不足本次交易【!!!】";
                case "6":
                    return "卡已过期【!!!】";
                case "7":
                    return "终端未注册【!!!】";
                case "8":
                    return "服务器操作失败【!!!】";
                case "9":
                    return "操作员不存在【!!!】";
                case "10":
                    return "操作员未授权【!!!】";
                case "11":
                    return "辙单交易凭证号不存在【!!!】";
                case "12":
                    return "辙单金额大于原交易金额【!!!】";
                case "13":
                    return "辙单交易不能再次辙单【!!!】";
                case "14":
                    return "结算密钥不正确【!!!】";
                case "15":
                    return "手机号码已存在【!!!】";
                case "16":
                    return "卡片状态异常【!!!】";
                case "17":
                    return "操作员密码错误【!!!】";
                case "18":
                    return "POS充值金额已达上限【!!!】";
                case "255":
                    return "该功能被关闭【!!!】";
                default:
                    return "未定义错误【???】";
            }
        }
        public static bool IsConsumed(string card)
        {
            return SP_POS_TransactionDAL.IsConsumed(card);
        }
    }
}
