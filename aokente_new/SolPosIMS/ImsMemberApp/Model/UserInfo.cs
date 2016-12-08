using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Member.Model
{
    [DbObject("tb_member", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_member_MemberInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class UserInfo
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
        private string _RealName;
        /// <summary>
        /// //真实姓名
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        private string _Regionid;
        /// <summary>
        /// 分店编号
        /// </summary>
        public string Regionid
        {
            get { return _Regionid; }
            set { _Regionid = value; }
        }
        private string _CellPhone;
        /// <summary>
        /// CellPhone
        /// </summary>
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        private string _IdType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string IdType
        {
            get { return _IdType; }
            set { _IdType = value; }
        }
        private string _IdNo;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdNo
        {
            get { return _IdNo; }
            set { _IdNo = value; }
        }
        private string _Gender;
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        /// <summary>
        /// 可用
        /// </summary>
        private bool? _flag;
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }


        private string _UserRank;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string UserRank
        {
            get { return _UserRank; }
            set { _UserRank = value; }
        }
        private string _TelPhone;
        /// <summary>
        /// TelPhone
        /// </summary>
        public string TelPhone
        {
            get { return _TelPhone; }
            set { _TelPhone = value; }
        }
        private string _Address;
        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    }
}
