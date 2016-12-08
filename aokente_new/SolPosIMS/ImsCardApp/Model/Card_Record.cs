using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{

    [Serializable]
    [DbObject("Card_Record", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_Card_Record", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class Card_Record
    {
        // --Oldcardid 旧卡 NewCardId 新卡 balance 余额  username 姓名  password 验证密码 CardTime补卡时间

       /// <summary>
       /// 新卡卡号
       /// </summary>
        public string _NewCardId;
        [DataField(IsKey = true)]
        [InitListControl("", "NewCardId", "NewCardId", "v_Card_Record", "NewCardId")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string NewCardId {
            get { return _NewCardId; }
            set { _NewCardId = value; }
        }

        /// <summary>
        /// 旧卡卡号
        /// </summary>
        public string _Oldcardid;
        public string Oldcardid {
            get { return _Oldcardid; }
            set { _Oldcardid = value; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        public string _Balance;
        public string Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// 补卡时间
        /// </summary>
        public string _CardTime;

        public string cardTime
        {
            get { return _CardTime; }
            set { _CardTime = value; }
        }

        //以下查询用
        public string _OperateDate1;
        public string _OperateDate2;

        [DataField("CardTime", OnlyQuery = true)]
        [SqlField("<=")]
        public string OperateDate2
        {
            get { return _OperateDate2; }
            set { _OperateDate2 = value; }
        }

        [DataField("CardTime", OnlyQuery = true)]
        [SqlField(">=")]
        public string OperateDate1
        {
            get { return _OperateDate1; }
            set { _OperateDate1 = value; }
        }

        private bool? _flag;
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
    }
}
