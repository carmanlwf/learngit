using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    /// <summary>
    /// ������ʵ��
    /// </summary>
    [DbObject("tb_CardType", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public  class tb_CardType
    {
        private string _TypeID;
        /// <summary>
        /// ���ͱ��
        /// </summary>
        [DataField(IsKey = true)]
        [InitListControl("", "TypeID", "TypeName", "tb_TypeName", "TypeID")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        private string _TypeName;
        /// <summary>
        /// ��������
        /// </summary>
        /// 
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        private string _numMonths;
        /// <summary>
        /// ��Ч��
        /// </summary>
        public string NumMonths
        {
            get { return _numMonths; }
            set { _numMonths = value; }
        }
        private string _numCost;

        public string NumCost
        {
            get { return _numCost; }
            set { _numCost = value; }
        }
        private decimal? _ConDiscount;
        /// <summary>
        /// �������ۿ�
        /// </summary>
        /// 
        public decimal? ConDiscount
        {
            get { return _ConDiscount; }
            set { _ConDiscount = value; }
        }
        private string _Proportion;
        /// <summary>
        /// ���ͽ������ֱ�(10Ԫһ����)
        /// </summary>
        /// 
        public string Proportion
        {
            get { return _Proportion; }
            set { _Proportion = value; }
        }
        private string _Additme;
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// 
        public string Additme
        {
            get { return _Additme; }
            set { _Additme = value; }
        }

        private int? _DeleStatus;
        /// <summary>
        /// ɾ��״̬
        /// </summary>
        /// 
        public int? DeleStatus
        {
            get { return _DeleStatus; }
            set { _DeleStatus = value; }
        }
        

        private string _Memo;
        /// <summary>
        /// ��ע
        /// </summary>
        /// 
        public string Memo
         {
            get { return _Memo; }
            set { _Memo = value; }
        }
        private string _Additme1;
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "Additme")]
        [BindControlParameter("Additme1", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string Additme1
        {
            get { return _Additme1; }
            set { _Additme1 = value; }
        }

        /// <summary>
        /// ������ֹʱ��
        /// </summary>

        private string _Additme2;
        [SqlField(QueryOperator = "<=", FieldFormatString = "Additme")]
        [BindControlParameter("Additme2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string Additme2
        {
            get { return _Additme2; }
            set { _Additme2 = value; }
        }
       
        private string _UpdateTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
       
        public string UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }
        private string _DeleTime;
        /// <summary>
        /// ɾ��
        /// </summary>
      

        public string DeleTime
        {
            get { return _DeleTime; }
            set { _DeleTime = value; }
        }

        private decimal? _Recharge;
        /// <summary>
        /// ��ֵ����
        /// </summary>
      
        public decimal? Recharge
        {
            get { return _Recharge; }
            set {_Recharge =value ;}
        }
        private bool? _IsMonthlyCard;
        /// <summary>
        /// �Ƿ����¿�
        /// </summary>
        public bool? IsMonthlyCard
        {
            get { return _IsMonthlyCard; }
            set { _IsMonthlyCard = value; }
        }

        /// <summary>
        /// �Ƿ����տ�
        /// </summary>
        private bool? _IsDayCard;

        public bool? IsDayCard
        {
            get { return _IsDayCard; }
            set { _IsDayCard = value; }
        }
        
        

        private int? _months;
        /// <summary>
        /// ����
        /// </summary>
        public int? months
        {
            get { return _months; }
            set { _months = value; }
        }
        private decimal? _price;
        /// <summary>
        /// �۸�
        /// </summary>
        public decimal? price
        {
            get { return _price; }
            set { _price = value; }
        }
        private bool? _cbMonthlyCard;
        /// <summary>
        /// �Ƿ�ͨ����״ֵ̬
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("IsMonthlyCard")]
        public bool? cbMonthlyCard
        {
            set { _cbMonthlyCard = value; }
            get { return _cbMonthlyCard; }
        }

        private bool? _cbDayCard;


        /// <summary>
        /// �Ƿ�ͨ����״ֵ̬
        /// </summary>
        /// 
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("IsDayCard")]
        public bool? CbDayCard
        {
                 get { return _cbDayCard; }
                 set { _cbDayCard = value; }
        }
    }
}
