using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
   public class Ims_Config
    {
       //SysName DomainName  SiteIp    IsHasSpot Banners
       private string _sysName;

       public string SysName
       {
           get { return _sysName; }
           set { _sysName = value; }
       }
       private string _domainName;

       public string DomainName
       {
           get { return _domainName; }
           set { _domainName = value; }
       }
       private string _siteIp;

       public string SiteIp
       {
           get { return _siteIp; }
           set { _siteIp = value; }
       }
       private bool _isHasSpot;

       public bool IsHasSpot
       {
           get { return _isHasSpot; }
           set { _isHasSpot = value; }
       }
       private string _banners;

       public string Banners
       {
           get { return _banners; }
           set { _banners = value; }
       }

    }
}
