using System;
using System.Collections.Generic;
using System.Text;
using Ims.Main.Model;
using ZsdDotNetLibrary.Data;

namespace Ims.Main.DAL
{
    /// <summary>
    /// 处理岗数据处理层
    /// </summary>
    public class SheetRoleDAL
    {
        /// <summary>
        /// 恢复登录状态
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int BackUpLoginStatus(SheetRoleInfo o)
        {
            string strSQL = "update pub_sheetrole set access_status='9' where id='" + o.id + "'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        /// <summary>
        /// 
        /// </summary>
        public const string TM_ROLE_TYPE = "tm";
        /// <summary>
        /// 
        /// </summary>
        public const string OBTM_ROLE_TYPE = "ob";

        /// <summary>
        /// 知识库角色类型
        /// </summary>
        public const string KM_ROLE_TYPE = "km";

        /// <summary>
        /// 转办知识库角色类型
        /// </summary>
        public const string KMANDTM_ROLE_TYPE = "tmkm";
    }
}
