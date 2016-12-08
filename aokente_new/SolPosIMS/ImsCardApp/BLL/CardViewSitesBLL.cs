using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Card.Model;
using ZsdDotNetLibrary.Data;
using Ims.Card.DAL;
using System.Data;

namespace Ims.Card.BLL
{
    public class CardViewSitesBll
    {
        public static DataTable getSites(int startIndex, int pageSize, string sortedBy, string carnum)
        {
            DataTable dt = null;
            dt = CardViewSitesDAL.getSites(carnum);
            return dt;
        }
    }
}