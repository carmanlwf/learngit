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
    public class POS_TransactionBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_pos_transaction> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_pos_transaction o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "StartTime DESC"; }
            List<v_pos_transaction> objects = ObjectData.GetPagedObjects<v_pos_transaction>(startIndex, pageSize, sortedBy, o, "v_pos_transaction");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_pos_transaction o)
        {
            return ObjectData.GetObjectsCount(o, "v_pos_transaction");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static v_pos_transaction GetObject(string credsnr)
        {
            v_pos_transaction o = new v_pos_transaction();
            o.CredenceSnr = credsnr;
            return ObjectData.GetObject(o, "v_pos_transaction") as v_pos_transaction;
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
        public static int InsertObject(tb_POS_Transaction o)
        {
            checkId(o, "会员卡号 不能为空！");
            return ObjectData.InsertObject(o, "tb_POS_Transaction");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_POS_Transaction o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_POS_Transaction");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_POS_Transaction o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_POS_Transaction");
        }


        /// <summary>
        /// 当有时间 对交易表进行统计 
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static DataTable HavetimeCountPOS_Transaction(string CredenceSnr, string BatchSnr, string Magcard, string Mode, string areacode, string Regionid, string PosSnr, string time1, string time2)
        {
            return tb_POS_TransactionDAL.HavetimeCountPOS_Transaction(CredenceSnr, BatchSnr, Magcard, Mode, areacode, Regionid, PosSnr, time1, time2);
        }

        /// <summary>
        ///  删除 tb_POS_Transaction里面的数据
        /// </summary>
        /// <returns></returns>
        public static int Deletecdtb_POS_Transaction()
        {
            return tb_POS_TransactionDAL.Deletecdtb_POS_Transaction();
        }




        /// <summary>
        ///  删除 tb_POS_Transaction里面的数据 有时间h
        /// </summary>
        /// <returns></returns>
        public static int Deletecdtb_POS_TransactionByTime(string time1, string time2)
        {
            return tb_POS_TransactionDAL.Deletecdtb_POS_TransactionByTime(time1, time2);
        }

        /// <summary>
        /// 检查tb_POS_Transaction里面 时间 有数据
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countPosTransactionBytime(string time1, string time2)
        {
            string strSQL = "select COUNT(1)  from dbo.tb_POS_Transaction  where  Datetime>='" + time1 + " 00:00:00' and Datetime<='" + time2 + " 23:59:60' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 检查tb_POS_Transaction里面 时间 有数据
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countPosTransaction()
        {
            string strSQL = "select COUNT(1)  from dbo.tb_POS_Transaction";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        public static DataTable PosHistory(string CredenceSnr, string BatchSnr, string Magcard, string Mode, string areacode, string sitename, string PosSnr, string time1, string time2,string siteid)
        {
            return tb_POS_TransactionDAL.PosHistory(CredenceSnr, BatchSnr, Magcard, Mode, areacode, sitename, PosSnr, time1, time2,siteid);
        }
        public static DataTable PostTransStatics(string CredenceSnr, string BatchSnr, string Magcard,string Mode,string Possnr,string siteid,string begtime,string endtime,string areacode)
        {

            string StrSql = @"
                                  SELECT ISNULL(SUM(case Mode when 1 then 1 else 0 end),0) as XFTJ_Count,
		 ISNULL(SUM(case Mode when 11 then 1 else 0 end),0) as CZTJ_Count, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then 1 else 0 end),0) as CDTJ_Count, 
		 ISNULL(SUM(case Mode when 1 then [Money] else 0 end),0) as XFTJ_Amount,
		 ISNULL(SUM(case Mode when 11 then [Money] else 0 end),0) as CZTJ_Amount, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then [Money] else 0 end),0) as CDTJ_Amount
  FROM tb_POS_Transaction Where 1=1";
            if (!string.IsNullOrEmpty(CredenceSnr))
                StrSql += " And CredenceSnr='"+CredenceSnr+"'";
            if (!string.IsNullOrEmpty(BatchSnr))
                StrSql += " And BatchSnr=" + BatchSnr + "";
            if (!string.IsNullOrEmpty(Magcard))
                StrSql += " And Magcard ='" + Magcard + "'";
            if (!string.IsNullOrEmpty(Mode))
                StrSql += " And Mode =" + Mode + "";
            if (!string.IsNullOrEmpty(Possnr))
                StrSql += " And Possnr ='" + Possnr + "'";
            if (!string.IsNullOrEmpty(siteid))
                StrSql += " And Possnr in (Select machineid from tb_site where id ='" + siteid + "')";
            if (!string.IsNullOrEmpty(begtime) && !string.IsNullOrEmpty(endtime))
                StrSql += " And Datetime >= Replace('" + begtime + "','-','/') And Datetime <= Replace('" + endtime + "','-','/')";
            if (!string.IsNullOrEmpty(areacode))
                StrSql += " And PosSnr in (Select machineid from tb_Site where areacode = '" + areacode + "')";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            return dt;
        }
        /// <summary>
        /// 根据机号统计终端交易情况
        /// </summary>
        /// <param name="Possnr"></param>
        /// <param name="begtime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static DataTable PostTransStaticsByPossnr(string Possnr,string begtime, string endtime)
        {
            string StrSql = @"
                                  SELECT ISNULL(SUM(case Mode when 1 then 1 else 0 end),0) as XFTJ_Count,
		 ISNULL(SUM(case Mode when 11 then 1 else 0 end),0) as CZTJ_Count, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then 1 else 0 end),0) as CDTJ_Count, 
		 ISNULL(SUM(case Mode when 1 then [Money] else 0 end),0) as XFTJ_Amount,
		 ISNULL(SUM(case Mode when 11 then [Money] else 0 end),0) as CZTJ_Amount, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then [Money] else 0 end),0) as CDTJ_Amount
  FROM tb_POS_Transaction Where 1=1 ";

            if (!string.IsNullOrEmpty(Possnr))
                StrSql += "And Possnr ='" + Possnr + "'";
            if (!string.IsNullOrEmpty(begtime) && !string.IsNullOrEmpty(endtime))
                StrSql += "And Datetime >= Replace('" + begtime + "','-','/') And Datetime <= Replace('" + endtime + "','-','/')";
            StrSql += " Group By Possnr";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            return dt;
        }
        /// <summary>
        /// 根据交易凭证号获取交易记录的车牌图片
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static DataTable GetCardInfoByTransId(string tid)
        {
            string strSql = "Select CardSnr,carpicture From tb_POS_Transaction Where CredenceSnr = '" + tid + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
    }
}
