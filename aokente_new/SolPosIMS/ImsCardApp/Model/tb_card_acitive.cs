using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    [DbObject("tb_card", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_card_MemberCardInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_card_active
    {
        private string _card;//卡号
        /// <summary>
        /// 会员号(必填)
        /// </summary>
        [DataField(IsKey = true)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string card
        {
            get { return _card; }
            set { _card = value; }
        }
        private string _Userid;
        /// <summary>
        /// //用户编号
        /// </summary>
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
        }

        private int? _Status;
        /// <summary>
        /// 卡状态（0：未激活 1：正常 2：挂失 3：销卡 4:补卡）
        /// </summary>
        public int? Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private int? _activitystatus;
        /// <summary>
        /// 卡激活状态:0待激活 1已永久激活 2临时激活
        /// </summary>
        public int? activitystatus
        {
            get { return _activitystatus; }
            set { _activitystatus = value; }
        }
        private string _regionid;
        /// <summary>
        /// 分店编号
        /// </summary>
        public string regionid
        {
            get { return _regionid; }
            set { _regionid = value; }
        }
    }
}
