using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Member.Model
{
    [DbObject("tb_MemberRanks", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_MemberRanks", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_MemberRanks
    {
        private string _id;//id

        /// <summary>
        /// id
        /// </summary>
        [InitListControl("", "id", "id", "tb_MemberRanks", "id")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [DataField(FieldName = "id", IsKey = true, IsNullable = false)]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _Name;
        /// <summary>
        /// 等级名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _description;
        /// <summary>
        /// 等级描述
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        private int? _Point;
        /// <summary>
        /// 所需积分
        /// </summary>
        public int? Point
        {
            get { return _Point; }
            set { _Point = value; }
        }
        private string _isDefault;
        /// <summary>
        /// //是否默认
        /// </summary>
        public string isDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; }
        }
        private string _priceType;
        /// <summary>
        /// //价格类型
        /// </summary>
        public string priceType
        {
            get { return _priceType; }
            set { _priceType = value; }
        }
        private string _PriceOperations;
        /// <summary>
        /// 折扣方式
        /// </summary>
        public string PriceOperations
        {
            get { return _PriceOperations; }
            set { _PriceOperations = value; }
        }
        private double? _PriceValue;
        /// <summary>
        /// 折扣金额
        /// </summary>
        public double? PriceValue
        {
            get { return _PriceValue; }
            set { _PriceValue = value; }
        }
        //以下查询用
        private string _addeddate1;
        private string _addeddate2;

        [DataField("addeddate", OnlyQuery = true)]
        [SqlField("<=")]
        public string addeddate2
        {
            get { return _addeddate2; }
            set { _addeddate2 = value; }
        }

        [DataField("addeddate", OnlyQuery = true)]
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
        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }

        private bool? _chflag;
        /// <summary>
        /// 是否启用
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("flag")]
        public bool? chflag
        {
            set { _chflag = value; }
            get { return _chflag; }
        }
        private bool? _flag;
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        private string _State;
        /// <summary>
        /// 是否启用
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        private decimal? _scale;
        /// <summary>
        /// 充值比例
        /// </summary>
        public decimal? scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

    }
}
