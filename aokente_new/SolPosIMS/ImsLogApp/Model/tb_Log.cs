using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Log.Model
{
    /// <summary>
    /// 卡操作日志文件
    /// </summary>
    [DbObject("tb_Log", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_web_consult_log", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_Log
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
        string _type;
        /// <summary>
        /// 操作类型( )
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        //string _typename;
        ///// <summary>
        ///// 操作业务名称
        ///// </summary>
        //public string typename
        //{
        //    get { return _typename; }
        //    set { _typename = value; }
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
    }
}
