using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.Model;
using Ims.Log.Model;
using Ims.Member.Model;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Log;
using Ims.Log.BLL;
using System.Data;

namespace Ims.Card.DAL
{
    public class TransHelperDAL
    {
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Card_ChongZhi(tb_TransLog t, tb_Card  c, tb_Log log)
        {
            if (t == null || c == null || log == null)
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(t, DataExecCmdType.Insert);
            objects.Add(c , DataExecCmdType.Update);
            objects.Add(log, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                return true;
            }
            catch (Exception exp)
            {

                DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
                LogHelper.Write(exp);
                return false;
            }
        }

        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Card_ZhuanZhang(tb_TransCash o1, tb_TransCash o2,tb_Log log)
        {
            if (o1 == null || o2 == null||log ==null )
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(o1, DataExecCmdType.Update);
            objects.Add(o2, DataExecCmdType.Update);
            objects.Add(log, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                return true;
            }
            catch (Exception exp)
            {

                DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
                LogHelper.Write(exp);
                return false;
            }
        }
        //-------------------2011-9-30-----------------------
        /// <summary>
        /// 会员发卡
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCard(tb_Card c, tb_Log log,tb_CardActivityByShop aCtive)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c, DataExecCmdType.Update);
            objects.Add(log, DataExecCmdType.Insert);
            objects.Add(aCtive, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                return true;
            }
            catch (Exception exp)
            {
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
                LogHelper.Write(exp);
                return false;
            }
        }
        // ------------------------------------------------------
        /// <summary>
        /// -----------------10-9-----------------------
        /// 会员卡转账
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Online_transfer(tb_Card c1, tb_Card c2, tb_Member_Log log, tb_TransferRecord tranERe, tb_TransLog tranlog)
        {
            if (c1  == null || c2 == null || log == null||tranERe ==null ||tranlog ==null)
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c1, DataExecCmdType.Update);
            objects.Add(c2, DataExecCmdType.Update);
            objects.Add(log, DataExecCmdType.Insert);
            objects.Add(tranERe, DataExecCmdType.Insert);
            objects.Add(tranlog, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                return true;
            }
            catch (Exception exp)
            {

                DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
                LogHelper.Write(exp);
                return false;
            }
        }
        /// <summary>
        /// 会员补卡
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool MemberBuKa(tb_Card o1, tb_Card o2,Card_Record cardrecord, tb_CardActivityByShop c,tb_Log log)
        {
            if (o1 == null || cardrecord==null|| o2 == null||c ==null ||log ==null)
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(o1, DataExecCmdType.Update);
            objects.Add(o2, DataExecCmdType.Update);
            objects.Add(cardrecord, DataExecCmdType.Insert);
            objects.Add(c , DataExecCmdType.Insert);
            objects.Add(log, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                return true;
            }
            catch (Exception exp)
            {

                DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
                LogHelper.Write(exp);
                return false;
            }
        }
        // ------------------------------------------------------
        /// <summary>
        /// -----------------10-10----------------------
        /// 判断卡一天的转账次数
        /// Tran_Times
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        /// 
        public static int Tran_Times(string tradcard)
        {
            string strSQL = "select COUNT(1) from dbo.tb_TransferRecord where card1='" + tradcard + "' and datediff(d,operatedate,getdate())=0 ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        //--------------------------------2011-10-20---------------------
        /// 管理面在线帮会员转帐
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Online_transferOfManger(tb_Card c1, tb_Card c2, tb_Log log, tb_TransferRecord tranERe, tb_TransLog tranlog)
        {
            if (c1 == null || c2 == null || log == null || tranERe == null || tranlog == null)
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c1, DataExecCmdType.Update);
            objects.Add(c2, DataExecCmdType.Update);
            objects.Add(log, DataExecCmdType.Insert);
            objects.Add(tranERe, DataExecCmdType.Insert);
            objects.Add(tranlog, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                return true;
            }
            catch (Exception exp)
            {

                DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
                LogHelper.Write(exp);
                return false;
            }
        }
        //--------------------------------2011-10-20---------------------
        /// <summary>
        /// 按卡号查询最后一次的消费记录
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static string GetLastConsumeTime(string card)
        {
            string strSql = "select top 1 [DateTime] from tb_POS_Transaction where magcard='" + card + "' order by logtime desc";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (dt != null&&dt.Rows.Count>0)
            {
                return dt.Rows[0]["DateTime"].ToString();
            }
            else
            {
                return "无任何消费记录.";
            }
        }
    }
}
