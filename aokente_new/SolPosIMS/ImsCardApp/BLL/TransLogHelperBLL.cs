using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Card.DAL;

namespace Ims.Card.BLL
{
    public class TransLogHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_TransLog> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_TransLog o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "OperateDate DESC"; }
            List<tb_TransLog> objects = ObjectData.GetPagedObjects<tb_TransLog>(startIndex, pageSize, sortedBy, o, "v_card_translog");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_TransLog o)
        {
            return ObjectData.GetObjectsCount(o, "v_card_translog");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_TransLog GetObject(string uid)
        {
            tb_TransLog o = new tb_TransLog();
            o.Userid = uid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_card_translog") as tb_TransLog;
        }
        /// <summary>
        /// 检查主键是否存在
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(object o, string errmessage)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception(errmessage);
            }

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(tb_TransLog o)
        {
            checkId(o, "交易号 不能为空！");
            return ObjectData.InsertObject(o, "tb_TransLog");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_TransLog o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_TransLog");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_TransLog o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_TransLog");
        }

        /// <summary>
        /// 充值表记录信息
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable DTTransLog(string cardID, string typename, string time1, string time2,string siteid)
        {
            return tb_TransLogDAL.DTTransLog(cardID,typename, time1, time2,siteid);
        }
              
        /// <summary>
        /// 对充值表进行统计 
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable HavetimeCountTransLog(string cardID, string time1, string time2, string transname)
        {
            return tb_TransLogDAL.HavetimeCountTransLog(cardID, time1, time2, transname); 
        }


            
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
            return tb_TransLogDAL.NotimeCountTransLog();
        }


           
        /// <summary>
        /// 当有时间 对充值表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeCountTransLog1(string time1, string time2)
        {
            return tb_TransLogDAL.HavetimeCountTransLog1(time1, time2);
        }


             
        /// <summary>
       /// 当没时间 对充值表进行删除
       /// </summary>
       /// <param name="o1"></param>
       /// <param name="o2"></param>
       /// <summary>
       /// </summary>
       /// <returns></returns>
        public static int NotimeDeleteTransLog()
        {
            return tb_TransLogDAL.NotimeDeleteTransLog();
        }


               
        /// <summary>
       /// 当有时间 对充值表进行删除
       /// </summary>
       /// <param name="o1"></param>
       /// <param name="o2"></param>
       /// <summary>
       /// </summary>
       /// <returns></returns>

        public static int HavetimeDeleteTransLog(string time1, string time2)
        {
            return tb_TransLogDAL.HavetimeDeleteTransLog(time1, time2);
        }

        /// <summary>
        /// 撤销充值
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static bool DeleteChongZhi(string idno, decimal money, string card)
        {
            bool b = true;
            string select = "select transType from tb_Translog where TransNo='" + idno + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(select);
            if (Convert.ToInt16(dt.Rows[0][0]) == 1)
            {
                string update = "update tb_TransLog set transType=4,finallyCost=finallyCost-" + money + " where TransNo='" + idno + "'";
                string updatecard = "update tb_Card set Balance=Balance-" + money + " where card='" + card + "'";
                List<string> list = new List<string>();
                list.Add(update);
                list.Add(updatecard);
                DataExecSqlHelper.ExecuteNonQuerySqls(list);
            }
            else
            {
                b = false;
            }
            return b;
        }
        /// <summary>
        /// 绑定类型
        /// </summary>
        /// <returns></returns>
        public static DataTable BrandNameTable()
        {
            string selectBrand = "select distinct  typename,transType from v_card_translog";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(selectBrand);
            return dt;
        }

    }
}
