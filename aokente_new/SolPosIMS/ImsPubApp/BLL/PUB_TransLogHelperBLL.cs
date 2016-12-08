using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;

namespace Ims.Pub.BLL
{
    public class PUB_TransLogHelperBLL
    {
        /// <summary>
        /// 当没时间 对充值表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int NotimeCountTransLog()
        {
            return PUB_TransLogHelperBLL.NotimeCountTransLog();
        }



        /// <summary>
        /// 当有时间 对充值表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeCountTransLog1(string time7, string time8)
        {
            return PUB_TransLogHelperBLL.HavetimeCountTransLog1(time7, time8);
        }
    }
}
