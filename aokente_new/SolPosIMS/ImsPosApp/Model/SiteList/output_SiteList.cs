using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.SiteList
{
    public class output_SiteList:BaseModel_output
    {
        private List<SiteInfo> _sitelist;
        /// <summary>
        /// 路段名称对照表
        /// </summary>
        public List<SiteInfo> sitelist
        {
            get { return _sitelist; }
            set { _sitelist = value; }
        }
    }
}
