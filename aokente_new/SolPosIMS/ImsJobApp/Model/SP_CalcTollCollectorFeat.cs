using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Job.Model
{
    [DbObject("SP_CalcTollCollectorFeat", ObjType = DbObjectAttribute.ObjectType.StoredProcedure)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class SP_CalcTollCollectorFeat
    {
        private int _type;
        /// <summary>
        /// 类型
        /// </summary>
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _startTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public string startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        private string _endTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        private string _persons;
        /// <summary>
        /// 收费员编号
        /// </summary>
        public string persons
        {
            get { return _persons; }
            set { _persons = value; }
        }
    }
}
