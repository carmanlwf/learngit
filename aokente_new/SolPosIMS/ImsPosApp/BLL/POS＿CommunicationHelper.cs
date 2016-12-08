using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.BLL
{
    public class POS＿CommunicationHelper
    {
        public static string GetErrMsgByErrCode(string errCode)
        {
            string rtnMess = "";
            switch (errCode)
            {
                case "0":
                    rtnMess = "comm success";
                    break;
                case "1":
                    rtnMess = "no card exists";
                    break;
                case "2":
                    rtnMess = "card has been locked";
                    break;
                case "3":
                    rtnMess = "wrong user pass";
                    break;
                case "4":
                    rtnMess = "not sufficient funds";
                    break;
                case "5":
                    rtnMess = "not sufficient point funds";
                    break;
                case "6":
                    rtnMess = "card overdue";
                    break;
                case "7":
                    rtnMess = "pos not registered";
                    break;
                case "8":
                    rtnMess = "server error";
                    break;
                case "9":
                    rtnMess = "operator does not exist";
                    break;
                case "10":
                    rtnMess = "unauthorized";
                    break;
                case "11":
                    rtnMess = "revoke number not exist";
                    break;
                case "12":
                    rtnMess = "revoke value exceed the original";
                    break;
                case "13":
                    rtnMess = "repeat revoke operation";
                    break;
                case "14":
                    rtnMess = "wrong batch key";
                    break;
                case "15":
                    rtnMess = "mobile already exist";
                    break;
                case "16":
                    rtnMess = "account status wrong";
                    break;
                case "17":
                    rtnMess = "wrong pass of operator";
                    break;
                case "18":
                    rtnMess = "reach the max charge value";
                    break;
                case "101":
                    rtnMess = "no magics status";
                    break;
                case "255":
                    rtnMess = "shut down fun";
                    break;
                default:
                    rtnMess = "no define error";
                    break;
            }
            return rtnMess;
        }
    }
}