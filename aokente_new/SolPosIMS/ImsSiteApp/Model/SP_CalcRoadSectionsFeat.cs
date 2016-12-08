using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Site.Model
{

    [DbObject("SP_CalcRoadSectionsFeat", ObjType = DbObjectAttribute.ObjectType.StoredProcedure)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class SP_CalcRoadSectionsFeat
    {
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
        private string _siteids;
        /// <summary>
        /// 路段编号
        /// </summary>
        public string siteids
        {
            get { return _siteids; }
            set { _siteids = value; }
        }
    }
}
