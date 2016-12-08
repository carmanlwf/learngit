using System;
using System.Collections.Generic;
using System.Text;

using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;


namespace Ims.Product.Model
{

    /// <summary>
    /// �ն˲���
    /// </summary>
    [DbObject("tb_PosOperator", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pos_PosOperator", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]

    public class tb_PosOperator
    {
        //���
        private string _oid;
        /// <summary>
        /// ����(����)
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
        private string _Siteid;//վ����
        /// <summary>
        /// վ����
        /// </summary>
        public string Siteid
        {
            get { return _Siteid; }
            set { _Siteid = value; }
        }
        /// <summary>
        /// ����Ա���
        /// </summary>
        private string operatorid;//����Ա���

        public string Operatorid
        {
            get { return operatorid; }
            set { operatorid = value; }
        }

        /// <summary>
        /// POS���ն�����
        /// </summary>
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// ����Ա��¼Ա����
        /// </summary>
        private string _pass;

        public string Pass
        {
            get { return _pass; }
            set { _pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5"); }
        }
        //private string _name;
        /// <summary>
        /// ����Ա��ϵ�绰����
        /// </summary>
        private string _cellphone;

        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }


        /// <summary>
        /// ��ע
        /// </summary>
        private string _memo;

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        private bool? _flag;

        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }

        /// <summary>
        /// վ������
        /// </summary>
        private string _sitename;

        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        string _adddate;

        public string adddate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }



        string _adddate_begin;
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "adddate")]
        [BindControlParameter("adddate_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string adddate_begin
        {
            get { return _adddate_begin; }
            set { _adddate_begin = value; }
        }

        /// <summary>
        /// ������ֹʱ��
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
