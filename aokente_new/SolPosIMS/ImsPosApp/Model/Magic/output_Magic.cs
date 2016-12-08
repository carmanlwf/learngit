using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class output_Magic : BaseModel_output
    {
        public output_Magic()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        private List<SiteStatusObject> _sitestatuslist;
        public List<SiteStatusObject> sitestatuslist
        {
            get { return _sitestatuslist; }
            set { _sitestatuslist = value; }
        }

    }
}
