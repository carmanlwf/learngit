using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;
namespace Ims.Card.Model
{
    /// <summary>
    /// 转账实体
    /// </summary>
    [DbObject("tb_member", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_TransCash
    {
        private string _Userid;//卡号
        /// <summary>
        ///用户编号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        //[InitListControl( "ProductId", "tb_Products", "tb_Products", "")]
        //[InitListControl("", "card", "card", "tb_member", "card")]
        //[BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
        }
        private double? _Balance;
        /// <summary>
        /// 账户余额
        /// </summary>
        public double? Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        private double? _DeductMoney;
        /// <summary>
        /// 扣减金额
        /// </summary>
        public double? DeductMoney
        {
            get { return _DeductMoney; }
            set { _DeductMoney = value; }
        }
    }
}
