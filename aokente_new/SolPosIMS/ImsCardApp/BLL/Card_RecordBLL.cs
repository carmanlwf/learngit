using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Card.Model;
using Ims.Card.DAL;
using System.Data;

namespace Ims.Card.BLL
{
    public class Card_RecordBLL
    {
        public static List<Card_Record> GetPagedObjects(int startIndex, int pageSize, string sortedBy, Card_Record o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "CardTime DESC"; }
            List<Card_Record> objects = ObjectData.GetPagedObjects<Card_Record>(startIndex, pageSize, sortedBy, o, "Card_Record");
            return objects;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(Card_Record o)
        {
            return ObjectData.GetObjectsCount(o, "v_Card_Record");
        }


        public static void checkId(object o, string errmessage)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception(errmessage);
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(Card_Record o)
        {
            checkId(o, "删除失败!");
            return ObjectData.DeleteObject(o, "Card_Record");
        }

        /// <summary>
        /// 补卡记录
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable DTTransLog(string cardID, string time1, string time2)
        {
            return Card_RecordDAL.DTTransLog(cardID, time1, time2);
        }
        /// <summary>
        /// 删除补卡记录Card_Record
        /// </summary>
        /// <returns></returns>
        public static int del_ReplaceCardRecord(string time1, string time2, bool IsAll)
        {
            return Card_RecordDAL.del_ReplaceCardRecord(time1, time2, IsAll);
        }
    }
}
