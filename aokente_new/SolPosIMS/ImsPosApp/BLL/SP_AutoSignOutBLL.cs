using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.DAL;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.BLL
{
    public class SP_AutoSignOutBLL
    {
/// <summary>
/// 自动签退
/// </summary>
/// <returns></returns>
        public static bool Sys_AutoSignOut()
        {
            return SP_AutoSignOutDAL.Sys_AutoSignOut();
        }
    }
}
