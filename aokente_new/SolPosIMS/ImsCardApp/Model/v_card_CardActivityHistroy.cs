using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{

    [DbObject("tb_CardActive_Histroy", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_card_CardActivityHistroy", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_card_CardActivityHistroy
    {
        /// <summary>
        ///    ��ˮ��
        /// </summary>            
        private string _contno;
        [InitListControl("", "Contno", "Contno", "tb_CardActive_Histroy", "Contno")]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string contno
        {
            get { return _contno; }
            set { _contno = value; }
        }
        /// <summary>
        ///    ����
        /// </summary>
        private string _card;
        public string card
        {
            get { return _card; }
            set { _card = value; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        private string _realname;
        public string realname
        {
            get { return _realname; }
            set { _realname = value; }
        }
        /// <summary>
        ///   ����/�ն�
        /// </summary>
        private string _activeway;
        public string activeway
        {
            get { return _activeway; }
            set { _activeway = value; }
        }
        /// <summary>
        ///    ����Ա
        /// </summary>
        private string _activeoperator;
        public string activeoperator
        {
            get { return _activeoperator; }
            set { _activeoperator = value; }
        }
        /// <summary>
        ///    ��ע
        /// </summary>
        private string _memo;
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        /// <summary>
        /// ��Чʱ��
        /// </summary>
        private string _validDate;
        public string validDate
        {
            get { return _validDate; }
            set { _validDate = value; }
        }

        /// <summary>
        ///  ����ʱ��
        /// </summary>
        private string _activetime;
        public string activetime
        {
            get { return _activetime; }
            set { _activetime = value; }
        }

        private string _activetime1;
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "activetime")]
        [BindControlParameter("activetime1", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string activetime1
        {
            get { return _activetime1; }
            set { _activetime1 = value; }
        }

        /// <summary>
        /// ������ֹʱ��
        /// </summary>

        private string _activetime2;
        [SqlField(QueryOperator = "<=", FieldFormatString = "activetime")]
        [BindControlParameter("activetime2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string activetime2
        {
            get { return _activetime2; }
            set { _activetime2 = value; }
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
        /// ���Ͻ��
        /// </summary>
        private string _balance;
        public string balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        /// <summary>
        /// ��ʼ���
        /// </summary>
        private string _initvalue;
        public string initvalue
        {
            set { _initvalue = value; }
            get { return _initvalue; }
        }
        private string _regionid;
        /// <summary>
        /// �ֵ���
        /// </summary>
        public string regionid
        {
            get { return _regionid; }
            set { _regionid = value; }
        }
    }
}

