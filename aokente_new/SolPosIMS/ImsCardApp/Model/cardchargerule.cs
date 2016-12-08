using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    /// <summary>
    /// 终端操作
    /// </summary>
    [DbObject("cardchargerule", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]

    public class cardchargerule
    {
        //编号
        private string _bounsid;
        /// <summary>
        /// 类别号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey | BindParameterUsage.OpUpdate | BindParameterUsage.OpQuery)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string bounsid
        {
            get { return _bounsid; }
            set { _bounsid = value; }
        }
        private string _bounsname;//名称
        /// <summary>
        /// 名称
        /// </summary>
        public string bounsname
        {
            get { return _bounsname; }
            set { _bounsname = value; }
        }

        private decimal? _beginAmount;//操作员编号
        /// <summary>
        /// 起始赠送区间
        /// </summary>
        public decimal? beginAmount
        {
            get { return _beginAmount; }
            set { _beginAmount = value; }
        }

        /// <summary>
        /// 结束赠送区间
        /// </summary>
        private decimal? _endAmount;

        public decimal? endAmount
        {
            get { return _endAmount; }
            set { _endAmount = value; }
        }
        /// <summary>
        /// 充值起赠金额
        /// </summary>
        private decimal? _actualMoney;

        public decimal? actualMoney
        {
            get { return _actualMoney; }
            set { _actualMoney = value; }
        }
        /// <summary>
        /// 赠送金额
        /// </summary>
        private decimal? _giftMoney;
        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal? giftMoney
        {
            get { return _giftMoney; }
            set { _giftMoney = value; }
        }


        /// <summary>
        /// 添加时间
        /// </summary>
        private string _addeddate;

        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private string _operatorid;
        /// <summary>
        /// 添加人
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
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


    }
}
