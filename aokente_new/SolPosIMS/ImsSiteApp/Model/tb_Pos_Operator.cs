using System;
using System.Collections.Generic;
using System.Text;

using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;
using System.Web.Security;


namespace Ims.Site.Model
{
    /// <summary>
    /// �ն˲���
    /// </summary>
    [DbObject("tb_Pos_Operator", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_pos_PosOperator", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_Pos_Operator
    {
        /// <summary>
        /// ����Ա���
        /// </summary>
        private string _operatorid;//����Ա���
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        private string _machineid;//վ����
        /// <summary>
        /// ������
        /// </summary>
        public string machineid
        {
            get { return _machineid; }
            set { _machineid = value; }
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
            set { _pass = FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5"); }
        }
      
        private string _cellphone;
        /// <summary>
        /// ����Ա��ϵ�绰����
        /// </summary>
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
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("flag")]
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
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
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

        string _operate_date_end;
        /// <summary>
        /// ������ֹʱ��
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "adddate")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }
        /// <summary>
        ///   ǩ��״̬
        /// </summary>
        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// ����Ծʱ��
        /// </summary>
        private string _lastsigntime;
        public string lastsigntime
        {
            get { return _lastsigntime; }
            set { _lastsigntime = value; }
        }
        private string _last_siteid;
        /// <summary>
        /// ���ִ��·�εı��
        /// </summary>
        public string last_siteid
        {
            get { return _last_siteid; }
            set { _last_siteid = value; }
        }

        private string _last_sitename;
        /// <summary>
        /// ���ִ��·�ε�����
        /// </summary>
        public string last_sitename
        {
            get { return _last_sitename; }
            set { _last_sitename = value; }
        }
        private string _last_possnr;
        /// <summary>
        /// ���ִ�����õ��ֳ��ն�
        /// </summary>
        public string last_possnr
        {
            get { return _last_possnr; }
            set { _last_possnr = value; }
        }
        /// <summary>
        ///   �Ƿ��¼
        /// </summary>
        private int? _islogin;
        public int? islogin
        {
            get { return _islogin; }
            set { _islogin = value; }
        }
        /// <summary>
        /// �Ƿ��Ѹ�
        /// </summary>
        private int? _isOutBounds;
        public int? isOutBounds
        {
            get { return _isOutBounds; }
            set { _isOutBounds = value; }
        }
        private bool? _IsCharge;
        /// <summary>
        /// �Ƿ�ͨ��ֵ
        /// </summary>
        public bool? IsCharge
        {
            set { _IsCharge = value; }
            get { return _IsCharge; }
        }
        private bool? _cbIsCharge;
        /// <summary>
        /// �Ƿ�ͨ����״ֵ̬
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("IsCharge")]
        public bool? cbIsCharge
        {
            set { _cbIsCharge = value; }
            get { return _cbIsCharge; }
        }
    }
}
