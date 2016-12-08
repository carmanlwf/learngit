using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    /// <summary>
    /// 卡操作日志文件
    /// </summary>
    [DbObject("tb_Card_Log", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_web_consult_log", ObjType = DbObjectAttribute.ObjectType.View)]
    public class tb_Card_Log1
    {
        private long? _id;//id

        /// <summary>
        /// id
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = true)]
        public long? id
        {
            get { return _id; }
            set { _id = value; }
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
        /// 卡操作类型(0：未激活|注册卡 1：正常 -> 2：挂失 3：销卡 4:补卡)
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        string _typename;
        /// <summary>
        /// 操作业务类型
        /// </summary>
        public string typename
        {
            get { return _typename; }
            set { _typename = value; }
        }
        string _logmsg;
        /// <summary>
        /// 日志内容
        /// </summary>
        public string logmsg
        {
            get { return _logmsg; }
            set { _logmsg = value; }
        }
        string _operid;
        /// <summary>
        /// 操作员
        /// </summary>
        public string operid
        {
            get { return _operid; }
            set { _operid = value; }
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
