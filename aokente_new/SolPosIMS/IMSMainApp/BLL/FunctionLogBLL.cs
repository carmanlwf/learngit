using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Log;
using Ims.Main.Model;

namespace Ims.Main.BLL
{
    /// <summary>
    /// ������־ҵ���߼������
    /// </summary>
    public class FunctionLogBLL
    {
        #region ����
        /// <summary>
        /// �û�������Ϣ����
        /// </summary>
        public const string S_EditAgent = "pub_0001";
        /// <summary>
        /// ��Ȩ�û�
        /// </summary>
        public const string S_Authority = "pub_0002";
        /// <summary>
        /// ��������
        /// </summary>
        public const string S_AreaCode = "pub_0003";
        /// <summary>
        /// ����������
        /// </summary>
        public const string S_InsurBlack = "pub_0004";
        /// <summary>
        /// ҵ��Ա������
        /// </summary>
        public const string S_OperatorBlack = "pub_0005";
        /// <summary>
        /// �绰������
        /// </summary>
        public const string S_TelBlack = "pub_0006";
        /// <summary>
        /// ����Excel����
        /// </summary>
        public const string S_ExcelCreate = "pub_1001";
        #endregion

        #region
        /// <summary>
        /// ����ĳ���ֹ�˾�ĳ�ȡ�ͻ�
        /// </summary>
        public const string S_OB_CustDrop = "ob_0001";
        /// <summary>
        /// �ͻ���ȡͳ��
        /// </summary>
        public const string S_OB_CustNumQuery = "ob_0002";
        /// <summary>
        /// ��������
        /// </summary>
        public const string S_OB_CustCount = "ob_0003";
        /// <summary>
        /// �嵥��ѯ����
        /// </summary>
        public const string S_OB_CustListQuery = "ob_0004";
        /// <summary>
        /// ������ֲ����
        /// </summary>
        public const string S_OB_CustBackUp = "ob_0005";
        #endregion

        /// <summary>
        /// ��¼����������־
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
