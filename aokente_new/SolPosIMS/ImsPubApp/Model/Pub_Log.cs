using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    /// <summary>
    /// 卡操作日志文件
    /// </summary>
    [DbObject("Pub_Log", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_Log", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class Pub_Log
    {
        private string _logid;//id
        /// <summary>
        /// logid
        /// </summary>
        [DataField(FieldName = "logid", IsKey = true)]
        public string logid
        {
            get { return _logid; }
            set { _logid = value; }
        }
        string _operater;
        /// <summary>
        /// 操作员id
        /// </summary>
        public string operater
        {
            get { return _operater; }
            set { _operater = value; }
        }
        string _operate_date;
        /// <summary>
        /// 操作时间
        /// </summary>
        public string operate_date
        {
            get { return _operate_date; }
            set { _operate_date = value; }
        }
        string _typeid;
        /// <summary>
        /// 操作类型( )
        /// </summary>
        public string typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }

        string _typeName;
        /// <summary>
        /// 操作类型( )
        /// </summary>
        public string typeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        //string _typeidname;
        ///// <summary>
        ///// 操作业务名称
        ///// </summary>
        //public string typeidname
        //{
        //    get { return _typeidname; }
        //    set { _typeidname = value; }
        //}
        string _logmsg;
        /// <summary>
        /// 日志内容
        /// </summary>
        public string logmsg
        {
            get { return _logmsg; }
            set { _logmsg = value; }
        }
        bool? _flag;
        /// <summary>
        /// 有效状态
        /// </summary>
        public bool? flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        string _operate_date_begin;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "operate_date")]
        [BindControlParameter("operate_date_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_begin
        {
            get { return _operate_date_begin; }
            set { _operate_date_begin = value; }
        }

        string _operate_date_end;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "operate_date")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }
        string _siteid;
        /// <summary>
        /// 分店编号
        /// </summary>
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }

        string _sitename;
        /// <summary>
        ///分店名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        string _areaid;
        /// <summary>
        /// 分店编号
        /// </summary>
        public string areaid
        {
            get { return _areaid; }
            set { _areaid = value; }
        }

        string _areaname;
        /// <summary>
        ///区域名称
        /// </summary>
        public string areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }
    }
}
