using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    [DbObject("tb_CardActive_Histroy", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_CardActive_Histroy
    {
        /// <summary>
        ///    ��ˮ��
        /// </summary>            
        private string _contno;
        /// <summary>
        /// ����(����)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "Contno", "Contno", "tb_CardActive_Histroy", "Contno")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey | BindParameterUsage.OpUpdate | BindParameterUsage.OpQuery)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Contno
        {
            get { return _contno; }
            set { _contno = value; }
        }
        /// <summary>
        ///    ����
        /// </summary>
        private string _card;
        public string Card
        {
            get { return _card; }
            set { _card = value; }
        }

        /// <summary>
        ///   ����/�ն�
        /// </summary>
        private string _activeway;
        public string Activeway
        {
            get { return _activeway; }
            set { _activeway = value; }
        }
        /// <summary>
        ///    ����Ա
        /// </summary>
        private string _activeoperator;
        public string Activeoperator
        {
            get { return _activeoperator; }
            set { _activeoperator = value; }
        }
        /// <summary>
        ///    ��ע
        /// </summary>
        private string _memo;
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
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

        string _activetime1;
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
        [SqlField(QueryOperator = "<=", FieldFormatString = "activetime")]
        [BindControlParameter("activetime2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        string _activetime2;
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
    }
}
