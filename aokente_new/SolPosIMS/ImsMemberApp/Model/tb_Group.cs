using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Member.Model
{
    /// <summary>
    /// 销售组实体
    /// </summary>
    [DbObject("tb_Group", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
   public  class tb_Group
    {
       private string _GroupID;
        /// <summary>
        /// 组编号
        /// </summary>
        [DataField(IsKey = true)]
        [InitListControl("", "GroupID", "GroupName", "tb_Group", "GroupID")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        private string _GroupName;
        /// <summary>
        ///组名
        /// </summary>
        /// 
       [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        private int? _DeleStatus;
        /// <summary>
        /// 删除状态 0 正常，1删除（隐藏不显示）
        /// </summary>
        /// 

       public int? DeleStatus
        {
            get { return _DeleStatus; }
            set { _DeleStatus = value; }
        }
        private string _AddTime;
        /// <summary>
        /// 添加时间
        /// </summary>
        /// 

        public string AddTime
        {
            get { return _AddTime; }
            set { _AddTime = value; }
        }
    }
}
