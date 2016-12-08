using System;
using System.Collections.Generic;
using System.Text;

using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;


namespace Ims.Product.Model
{

    /// <summary>
    /// 终端操作
    /// </summary>
    [DbObject("tb_PosOperator", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pos_PosOperator", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]

    public class tb_PosOperator
    {
        //编号
        private string _oid;
        /// <summary>
        /// 类别号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "oid", "oid", "tb_PosOperator", "oid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey | BindParameterUsage.OpUpdate | BindParameterUsage.OpQuery)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Oid
        {
            get { return _oid; }
            set { _oid = value; }
        }
        private string _Siteid;//站点编号
        /// <summary>
        /// 站点编号
        /// </summary>
        public string Siteid
        {
            get { return _Siteid; }
            set { _Siteid = value; }
        }
        /// <summary>
        /// 操作员编号
        /// </summary>
        private string operatorid;//操作员编号

        public string Operatorid
        {
            get { return operatorid; }
            set { operatorid = value; }
        }

        /// <summary>
        /// POS机终端名字
        /// </summary>
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 操作员登录员密码
        /// </summary>
        private string _pass;

        public string Pass
        {
            get { return _pass; }
            set { _pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5"); }
        }
        //private string _name;
        /// <summary>
        /// 操作员联系电话号码
        /// </summary>
        private string _cellphone;

        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }


        /// <summary>
        /// 备注
        /// </summary>
        private string _memo;

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        private bool? _flag;

        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }

        /// <summary>
        /// 站点名称
        /// </summary>
        private string _sitename;

        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        /// <summary>
        /// 登录日期
        /// </summary>
        string _adddate;

        public string adddate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }



        string _adddate_begin;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "adddate")]
        [BindControlParameter("adddate_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string adddate_begin
        {
            get { return _adddate_begin; }
            set { _adddate_begin = value; }
        }

        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "adddate")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        string _operate_date_end;
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }


    }
}
