using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Log;
using System.Security.Principal;
using ZsdDotNetLibrary.Project.User;
using ZsdDotNetLibrary.Data;

namespace Ims.Main.BLL
{
    public class CallTools
    {
        static public object lockobj = new object();

        public delegate string FunCallback(string[] allParams);
        static private Dictionary<string, FunCallback> FunCallbacks = new Dictionary<string, FunCallback>();
        static private DataTable areainfoTable = InitAreaInfoTable();

        static private DataTable InitAreaInfoTable()
        {
            try
            {
                DataTable dt = DataExecSqlHelper.ExecuteQuerySql("select * from tb_site");
                return dt;
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex);
            }
            return null;
        }
        ///// <summary>
        ///// 根据区号获取地区代码及名称
        ///// </summary>
        ///// <param name="areacode"></param>
        ///// <param name="telno"></param>
        ///// <returns></returns>
        //static public AreaInfo GetAreaInfo(string areacode, string telno)
        //{
        //    AreaInfo areaInfo = new AreaInfo();
        //    if (string.IsNullOrEmpty(areacode))
        //    {
        //        if (!string.IsNullOrEmpty(telno))
        //        {
        //            string[] obj = CallTools.funSplitCallInTel(telno);
        //            if (!string.IsNullOrEmpty(obj[0]))
        //                areacode = obj[0];
        //        }
        //    }
        //    lock (lockobj)
        //    {
        //        try
        //        {
        //            //if (areainfoTable != null)
        //            //{
        //            areainfoTable = InitAreaInfoTable();
        //            DataRow[] rows = areainfoTable.Select("area_code='" + areacode + "'", "orgcode asc");
        //            if (rows.Length > 0)
        //            {
        //                DataBindHelper.BindDataRowToObj(rows[0], areaInfo);
        //            }
        //            foreach (DataRow row in rows)
        //            {
        //                if (row.IsNull("orgcode")) continue;
        //                string orgcode = row["orgcode"].ToString();
        //                if (string.IsNullOrEmpty(orgcode)) continue;
        //                if (orgcode.Length == 6 && string.IsNullOrEmpty(areaInfo.deptcode))
        //                {
        //                    areaInfo.deptcode = orgcode;
        //                    areaInfo.branchcode = orgcode.Substring(0, 4);
        //                }
        //                if (orgcode.Length == 4 && string.IsNullOrEmpty(areaInfo.branchcode)) areaInfo.branchcode = orgcode;

        //                if (!string.IsNullOrEmpty(areaInfo.branchcode) && !string.IsNullOrEmpty(areaInfo.deptcode)) break;
        //            }
        //            //}
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.Write(ex);
        //        }

        //    }
        //    //if (string.IsNullOrEmpty(areacode)) areacode = "010";


        //    return areaInfo;
        //}
        static private bool AddCallback(string funName, FunCallback callback)
        {
            lock (FunCallbacks)
            {
                try
                {
                    FunCallbacks.Remove(funName);
                    FunCallbacks.Add(funName, callback);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        static private void RemoveCallback(string funName)
        {
            lock (FunCallbacks)
            {
                try
                {
                    FunCallbacks.Remove(funName);
                }
                catch
                {

                }
            }

        }
        static public string doProcess(string funName, string[] allParams)
        {
            switch (funName)
            {
                //case "SaveSelectList":
                //    SaveSelectList(allParams);
                //    return "";
                case "SplitCallID":
                    {
                        string[] obj = funSplitCallInTel(allParams[0]);
                        return obj[0] + "," + obj[1];
                    }
                case "SplitTel":
                    {
                        string[] obj = funSplitCallOutTel(allParams[0]);
                        return obj[0] + "," + obj[1];
                    }
                //case "GetPhoneNo":
                //    if (allParams.Length == 2)
                //    {
                //        return funGetPhoneNo(allParams[0], allParams[1]);
                //    }
                //    else
                //    {
                //        return funGetPhoneNo(allParams[0]);
                //    }
                //case "GetPhoneNoForTransfer":
                //    return funGetPhoneNoForTransfer(allParams[0]);
                //case "GetGateWay":
                //    return funGetGateWayAreaCode(allParams[0]);
                case "UpdateAgentStatus":
                    {
                        if (allParams[1] == "1" || allParams[1] == "9") allParams[1] = "0";//若软电话退出则改为登录
                        UpdateUserStatus(allParams[0], allParams[1], allParams[2]);
                    }
                    return "";
                //               case "AgentIsActive":
                //                   return AgentInfo.UpdateUserActiveTime();
                //case "GetSysPara":
                //    return SysParam.GetSysParam(allParams[0]);
                //case "GetCustBizInfo":
                //    return Ncl.NclInfo.GetCurrentCustomerBizInfo(allParams[0]).ToString();
                //case "GetCustInfo":
                //    return PropHelper.GetMemberValue(allParams[0], NclInfo.CurrentCustomer).ToString();
                //case "PrepareIvrPwdData":
                //    return IvrPwdBLL.PrepareIvrPwdData().ToString();
                case "InsertCallInfo":
                    return InsertCallInfo(allParams[0], allParams[1], allParams[2], allParams[3], allParams[4], allParams[5], allParams[6], allParams[7], allParams[8]);
                case "BindCodesToListControl":
                    return BindCodesToListControl(allParams);
                case "BindNormalTableToListControl":
                    return BindNormalTableToListControl(allParams);
                case "GetIdelCard_Random":
                    return GetIdelCard_Random();
                case "GetTypeReard":
                    return GetTypeReard(allParams[0]);
                //case "SubmitClaimCondole":
                //    return Ncl.Tools.Tools.SubmitClaimCondole(allParams); GetTypeReard(string TypeID)
                default:
                    {
                        try
                        {
                            FunCallback callback = null;
                            lock (FunCallbacks)
                            {
                                if (!FunCallbacks.TryGetValue(funName, out callback)) return "";
                            }
                            if (callback == null) return "";
                            return callback(allParams);

                        }
                        catch
                        {
                            return "";
                        }
                    }
            }
        }
        static public string InsertCallInfo(string callid, string in_flag, string seconds, string wrapup_seconds, string start_time, string agent_id, string call_number, string cust_id, string area_code)
        {
            try
            {
                string sql = string.Format("insert into pub_callinfo(callid, in_flag, seconds, wrapup_seconds, start_time, agent_id,call_number,cust_id,area_code) values('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}','{8}')", callid, in_flag, seconds, wrapup_seconds, start_time, agent_id, call_number, cust_id, area_code);
                DataExecSqlHelper.ExecuteNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex);
            }
            return "1";
        }

        //分析CallID 分解电话和区号 用于呼入
        static public string[] funSplitCallInTel(string strPhoneNum)
        {
            string strAreaCode = "", strTel = "";

            string strSrc = strPhoneNum;
            if (string.IsNullOrEmpty(strSrc)) return new string[] { strAreaCode, strTel };
            if (strSrc.Length > 5 && strSrc.StartsWith("0"))
            {
                string tmpStr = strSrc.Substring(0, 2);
                if (tmpStr == "13" || tmpStr == "15" || tmpStr == "18")
                {
                    strAreaCode = "010";
                    strTel = strSrc;
                }
                else if (tmpStr == "01" || tmpStr == "02")
                {
                    if (strSrc.Substring(0, 3) == "013" || strSrc.Substring(0, 3) == "015" || strSrc.Substring(0, 3) == "018")
                    {
                        strAreaCode = "";
                        strTel = strSrc.Substring(1);
                    }
                    else
                    {
                        strAreaCode = strSrc.Substring(0, 3);
                        strTel = strSrc.Substring(3);
                    }
                }
                else
                {
                    strAreaCode = strSrc.Substring(0, 4);
                    strTel = strSrc.Substring(4);
                }
            }
            else
            {
                strAreaCode = "010";
                strTel = strSrc;
            }
            return new string[] { strAreaCode, strTel };

        }


        //拆分电话为区号和号码 用于呼出
        static public string[] funSplitCallOutTel(string strSrc)
        {
            string strPhone = "";
            string strAreaCode = "";
            if (string.IsNullOrEmpty(strSrc))
                return new string[] { strAreaCode, strPhone };
            if (strSrc.Length > 5 && strSrc.StartsWith("0"))
            {
                if (strSrc.StartsWith("01") || strSrc.StartsWith("02"))
                {
                    if (strSrc.StartsWith("013") || strSrc.StartsWith("015"))
                    {
                        strAreaCode = "010";
                        strPhone = strSrc;
                    }
                    else
                    {
                        strAreaCode = strSrc.Substring(0, 3);
                        strPhone = strSrc.Substring(3);
                    }
                }
                else
                {
                    strAreaCode = strSrc.Substring(0, 4);
                    strPhone = strSrc.Substring(4);
                }
            }
            else
            {
                strAreaCode = "010";
                strPhone = strSrc;
            }

            return new string[] { strAreaCode, strPhone };
        }

 
        //验证区号的合法性
        static public bool checkAreaCode(string areaCode)
        {
            string sql = "select area_code from pub_areacode where area_code = '" + areaCode + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public string BindCodesToListControl(string[] allParams)
        {
            string typecode = "", tablename = "", connString = "";
            if (allParams.Length > 0) typecode = allParams[0];
            if (allParams.Length > 1) tablename = allParams[1];
            if (allParams.Length > 2) connString = allParams[2];

            DataTable dataTable = AppCodeTableAccesser.QueryCodes(typecode, tablename, connString);
            string sht = DataBindHelper.DataTableToString(dataTable, "code", "name");
            return sht;
        }
        static public string BindNormalTableToListControl(string[] allParams)
        {
            string codefield = "", namefield = "", tablename = "", sortedby = "", filter = "", defaultValue = "", connString = "";
            if (allParams.Length > 0) codefield = allParams[0];
            if (allParams.Length > 1) namefield = allParams[1];
            if (allParams.Length > 2) tablename = allParams[2];
            if (allParams.Length > 3) sortedby = allParams[3];
            if (allParams.Length > 4) filter = allParams[4];
            if (allParams.Length > 5) defaultValue = allParams[5];
            if (allParams.Length > 6) connString = allParams[6];

            DataTable dataTable = NormalTableCodeAccesser.QueryNormalTableCodes(codefield, namefield, tablename, sortedby, filter, connString);
            string sht = DataBindHelper.DataTableToString(dataTable, "code", "name");
            return sht;
        }

        static public void UpdateUserStatus(string userid, string access_status, string access_callid)
        {
            try
            {
                IPrincipal user = UserHelper.GetCurrentPrincipal();
                if (user == null) return;
                string access_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //string sql = string.Format("update pub_agentinfo set access_status='{1}',access_time='{2}',access_callid='{3}',access_activetime='{2}' where id='{0}' and access_status <> '9'",
                //    userid, access_status, access_time, access_callid);
                string sql = string.Format("update pub_agentinfo set access_status='{1}',access_time='{2}',access_callid='{3}',access_activetime='{2}' where id='{0}'",
                    userid, access_status, access_time, access_callid);
                DataExecSqlHelper.ExecuteNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                LogWriter.Write(userid, ex);
            }
        }
        /// <summary>
        /// 随机获取空闲卡号
        /// </summary>
        /// <param name="allParams"></param>
        /// <returns></returns>
        static public string GetIdelCard_Random()
        {
            string StrSql = "select top 1 card from tb_card where activitystatus = 0 and status = 0 order by newid()";//空闲卡
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// 获取卡类型各属性
        /// </summary>
        /// <param name="allParams"></param>
        /// <returns></returns>
        static public string GetTypeReard(string TypeID)
        {
            string StrSql = "select ConDiscount,Proportion,Recharge from dbo.tb_CardType  where TypeID='"+TypeID+ "' ";//空闲卡
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            return dt.Rows[0][0].ToString() + ";" + dt.Rows[0][1].ToString() + ";" + dt.Rows[0][2].ToString();
        }
    }
}
