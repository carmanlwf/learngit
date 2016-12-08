using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;
namespace Ims.Pub.Model
{
    /// <summary>
    /// 黑名单
    /// </summary>
    [DbObject("PUB_BlackBook", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class PUB_BlackBook
    {
        private string _IPid;//id
        /// <summary>
        /// 区域代码(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "IPid", "IPid", "PUB_BlackBook", "IPid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string IPid
        {
            get { return _IPid; }
            set { _IPid = value; }
        }

        private string _IP;
        /// <summary>
        /// 黑名单IP地址
        /// </summary>
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
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

        //---------------以下查询用

        private string _Adddate1;

        private string _Adddate2;

        [DataField("Adddate", OnlyQuery = true)]
        [SqlField("<=")]
        /// <summary>
        /// 终止时间
        /// </summary>
        public string Adddate2
        {
            get { return _Adddate2; }
            set { _Adddate2 = value; }
        }

        [DataField("Adddate", OnlyQuery = true)]
        [SqlField(">=")]
        /// <summary>
        /// 起始时间
        /// </summary>
        public string Adddate1
        {
            get { return _Adddate1; }
            set { _Adddate1 = value; }
        }
        //--------------------------

        private string _Adddate;//注册时间
        /// <summary>
        /// 注册时间
        /// </summary>
        public string Adddate
        {
            get { return _Adddate; }
            set { _Adddate = value; }
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

    }
}
