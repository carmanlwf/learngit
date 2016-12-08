using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Ims.Pos.DAL
{
    public class SP_AutoSignOutDAL
    {
        
        public static bool Sys_AutoSignOut()
        {
            try
            {
                SQLHelper.AsyncExcStored("SP_Sys_AutoSignOut");
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
