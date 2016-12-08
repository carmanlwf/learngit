using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Log;
using Ims.Main.Model;

namespace Ims.Main.BLL
{
    /// <summary>
    /// 功能日志业务逻辑处理层
    /// </summary>
    public class FunctionLogBLL
    {
        #region 常量
        /// <summary>
        /// 用户基本信息管理
        /// </summary>
        public const string S_EditAgent = "pub_0001";
        /// <summary>
        /// 授权用户
        /// </summary>
        public const string S_Authority = "pub_0002";
        /// <summary>
        /// 地区代码
        /// </summary>
        public const string S_AreaCode = "pub_0003";
        /// <summary>
        /// 保单黑名单
        /// </summary>
        public const string S_InsurBlack = "pub_0004";
        /// <summary>
        /// 业务员黑名单
        /// </summary>
        public const string S_OperatorBlack = "pub_0005";
        /// <summary>
        /// 电话黑名单
        /// </summary>
        public const string S_TelBlack = "pub_0006";
        /// <summary>
        /// 生成Excel报表
        /// </summary>
        public const string S_ExcelCreate = "pub_1001";
        #endregion

        #region
        /// <summary>
        /// 撤销某个分公司的抽取客户
        /// </summary>
        public const string S_OB_CustDrop = "ob_0001";
        /// <summary>
        /// 客户抽取统计
        /// </summary>
        public const string S_OB_CustNumQuery = "ob_0002";
        /// <summary>
        /// 计数功能
        /// </summary>
        public const string S_OB_CustCount = "ob_0003";
        /// <summary>
        /// 清单查询功能
        /// </summary>
        public const string S_OB_CustListQuery = "ob_0004";
        /// <summary>
        /// 备份移植功能
        /// </summary>
        public const string S_OB_CustBackUp = "ob_0005";
        #endregion

        /// <summary>
        /// 记录操作功能日志
        /// </summary>
        /// <param name="functionid"></param>
        /// <param name="logmsg"></param>
        static public void WriteFunLog(string functionid, string logmsg)
        {
            if (string.IsNullOrEmpty(functionid)) functionid = "default";
            try
            {
                pub_funloginfo loginfo = new pub_funloginfo();
                loginfo.agentid = Ims.Main.ImsInfo.CurrentUserId;
                loginfo.functionid = functionid;
                loginfo.operdate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                loginfo.logmsg = logmsg + "\r\n";
                string msg = loginfo.agentid + "|" + loginfo.functionid + "|" + loginfo.operdate + "|" + loginfo.logmsg;
                LogWriter.WriteRaw("function", "Funlog\\", msg);
            }
            catch
            {
                
            }
        }
    }
}
