using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Member.Model
{
    /// <summary>
    /// 会员实体
    /// </summary>
    [DbObject("tb_member", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class UserCard
    {
        private string _Userid;//会员号
        /// <summary>
        /// 会员号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        //[InitListControl( "ProductId", "tb_Products", "tb_Products", "")]
        [InitListControl("", "Userid", "Userid", "tb_Member", "Userid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
        }

        private string _TradePassword;
        /// <summary>
        /// 交易密码
        /// </summary>
        public string TradePassword
        {
            get { return _TradePassword; }
            set { _TradePassword = value; }
        }
        private string _UserRank;
        /// <summary>
        /// UserRank
        /// </summary>
        public string UserRank
        {
            get { return _UserRank; }
            set { _UserRank = value; }
        }
    }
}
