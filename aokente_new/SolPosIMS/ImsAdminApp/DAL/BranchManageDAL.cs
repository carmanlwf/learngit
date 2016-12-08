using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Utility;
using Ims.Admin.Model;

namespace Ims.Admin.DAL
{
    /// <summary>
    /// �ֹ�˾�������ݷ��ʲ�
    /// </summary>
    public class BranchManageDAL
    {
        /// <summary>
        /// ��ѯ���Ӧ�ֹ�˾
        /// </summary>
        /// <param name="strGroupCode"></param>
        /// <returns></returns>
        public static DataTable GetBranchInGroup(string strGroupCode)
        {
            string sql = "select org.orgcode as code,org.shortname as name from pub_orgshortinfo org right join pub_groupbranch gb on gb.branchcode = org.orgcode where gb.pub_groupinfo_id = '" + strGroupCode + "'";
            DataTable dtBranch = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dtBranch;
        }
        /// <summary>
        /// ��ѯ���ѡ�ֹ�˾
        /// </summary>
        /// <param name="strGroupCode"></param>
        /// <returns></returns>
        public static DataTable GetBranchOutGroup(string strGroupCode)
        {
            string sql = "select org.orgcode as code,org.shortname as name  from pub_orgshortinfo org where len(org.orgcode)=4 and org.orgcode not in ( select gb.branchcode from pub_groupbranch gb where gb.pub_groupinfo_id = '" + strGroupCode + "')";
            DataTable dtBranch = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dtBranch;
        }



        /// <summary>
        /// ���ķֹ�˾�뼼������չ�ϵ
        /// </summary>
        /// <param name="branchcodes"></param>
        /// <param name="groupid"></param>
        /// <param name="strOper">1��������2��ɾ��</param>
        /// <returns></returns>
        public static int UpdateBranchGroupId(string branchcodes, string groupid,string strOper)
        {
            string strSQL = "";
            if (strOper=="1")
            {
                strSQL = "insert into pub_groupbranch(pub_groupinfo_id,branchcode) (select '" + groupid + "' ,orgcode from pub_orgshortinfo where orgcode in ( "+branchcodes+" ))";
            }
            else if (strOper=="2")
            {
                strSQL = "delete from pub_groupbranch where pub_groupinfo_id='" + groupid + "' and branchcode in ( "+branchcodes+" )";
            }
            if (string.IsNullOrEmpty(strSQL))
            {
                return 0;
            }
            else
            {
                return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
            }
        }

    }
}
