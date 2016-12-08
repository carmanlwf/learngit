using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Site.Model
{
    [DbObject("tb_operator_schedule", ObjType = DbObjectAttribute.ObjectType.Table)]
    public class tb_operator_schedule
    {
        private string _operatorid;
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }

        private string _name;
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _addtime;
        [SqlField("like", AfterLike = "%")]
        public string addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private string _posnum;

        public string posnum
        {
            get { return _posnum; }
            set { _posnum = value; }
        }

        private string _sitename;

        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        private int? _flag;

        public int? flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
