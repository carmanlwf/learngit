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
    [DbObject("card_integralexchangelist", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class card_integralexchangelist
    {
        private string _transid;
        /// <summary>
        /// 业务流水号(必填)
        /// </summary>
        [DataField(IsKey = true)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string transid
        {
            get { return _transid; }
            set { _transid = value; }
        }
        private string _card;
        /// <summary>
        /// 卡号
        /// </summary>
        public string card
        {
            get { return _card; }
            set { _card = value; }
        }
        private int? _old_point;
        /// <summary>
        /// //原有积分
        /// </summary>
        public int? old_point
        {
            get { return _old_point; }
            set { _old_point = value; }
        }
        private int? _new_point;
        /// <summary>
        /// //现有积分
        /// </summary>
        public int? new_point
        {
            get { return _new_point; }
            set { _new_point = value; }
        }
        private int? _point;
        /// <summary>
        /// //现有积分
        /// </summary>
        public int? point
        {
            get { return _point; }
            set { _point = value; }
        }
        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private string _operatorid;
        /// <summary>
        /// 操作员id
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        //以下查询用
        private string _addeddate1;
        private string _addeddate2;

        [DataField("operatetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string addeddate2
        {
            get { return _addeddate2; }
            set { _addeddate2 = value; }
        }

        [DataField("operatetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string addeddate1
        {
            get { return _addeddate1; }
            set { _addeddate1 = value; }
        }
        private string _addeddate;//注册时间
        /// <summary>
        /// 注册时间
        /// </summary>
        [DataField("operatetime")]
        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }
       
        private bool? _flag;
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
 
    }
}

