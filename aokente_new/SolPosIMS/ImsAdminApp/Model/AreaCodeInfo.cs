using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// 地区代码信息
    /// </summary>
    [DbObject("pub_areacode", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_areacode", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class AreaCodeInfo
    {
        private string areacode;//区号

        /// <summary>
        /// 区号
        /// </summary>
        [BindControlParameter("area", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("areacode", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        [DataField(FieldName = "area_code", IsIdentity = false, IsKey = true, IsNullable = false)]
        public string area_code
        {
            get { return areacode; }
            set { areacode = value; }
        }
        private string city;

        /// <summary>
        /// 城市名称
        /// </summary>
        [DataField(FieldName = "area_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("city", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string area_name
        {
            get { return city; }
            set { city = value; }
        }
        private string province;

        /// <summary>
        /// 省份
        /// </summary>
        [BindControlParameter("ddlProvince", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "province_code", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("province", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string province_code
        {
            get { return province; }
            set { province = value; }
        }
        private string provincename;

        /// <summary>
        /// 省份名称
        /// </summary>
        [DataField(FieldName = "province_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string province_name
        {
            get { return provincename; }
            set { provincename = value; }
        }
        private bool? gatewayflag;

        /// <summary>
        /// 是否有网关
        /// </summary>
        [DataField(FieldName = "have_gateway", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("gatewayflag", "Checked", ParamUsage = BindParameterUsage.OpInsert)]
        public bool? have_gateway
        {
            get { return gatewayflag; }
            set { gatewayflag = value; }
        }
        private string gatewaycode;

        /// <summary>
        /// 网关号
        /// </summary>
        [DataField(FieldName = "gateway_code", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("gatewaycode", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string gateway_code
        {
            get { return gatewaycode; }
            set { gatewaycode = value; }
        }
        private string sm_agentinfo_id;

        /// <summary>
        /// 维护人
        /// </summary>
        [DataField(FieldName = "agent_id", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string agent_id
        {
            get { return sm_agentinfo_id; }
            set { sm_agentinfo_id = value; }
        }
        private string updatetime;

        /// <summary>
        /// 维护人
        /// </summary>
        [DataField(FieldName = "update_time", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string update_time
        {
            get { return updatetime; }
            set { updatetime = value; }
        }
    }
}
