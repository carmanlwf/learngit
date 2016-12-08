using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Log;
using System.Data;
using System.Security.Cryptography;
using System.Globalization;
using System.Web.Security;
using Ims.Card.Model;
using Ims.Member.Model;
using Ims.Log.Model;
using Ims.Main;
using Ims.Log.BLL;
using Ims.Pos.DAL;
using System.Data.SqlClient;
namespace Ims.Card.DAL
{
    public class CardHelperDAL
    {
        #region 常量
        /// <summary>
        /// 未使用,0
        /// </summary>
        public const int I_NoActive = 0;
        /// <summary>
        /// 正常使用,1
        /// </summary>
        public const int I_InUse = 1;
        /// <summary>
        /// 挂失,2
        /// </summary>
        public const int I_Lost = 2;
        /// <summary>
        /// 销卡,3
        /// </summary>
        public const int I_LogOut = 3;
        /// <summary>
        /// 补卡,4
        /// </summary>
        public const int I_ReSend = 4;
        #endregion
        #region 函数
        /// <summary>
        /// 销卡 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static int Card_XiaoKa(string card)
        {
            if (string.IsNullOrEmpty(card)) return -1;
            try
            {
                tb_Log tlog = new tb_Log();
                tlog.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                tlog.type = "会员销卡";
                tlog.operater = ImsInfo.CurrentUserId;
                tlog.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tlog.logmsg = "对卡号为:" + card + "的会员卡执行【销卡】操作。";
                tlog.flag = true;
                LogHelperBLL.InsertObject(tlog);
                string strSQL = "update tb_Card set status = " + I_LogOut + " where card = '" + card + "' ";

                return DataExecSqlHelper.ExecuteNonQuerySql(strSQL); ;
            }
            catch (Exception exp)
            {
                LogHelper.Write(exp);
                return -1;
            }
        }
        /// <summary>
        /// 凭手机号号码挂失会员卡
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static int Card_GuaShi(string card, string cellPhone,string memo)
        {
            if (string.IsNullOrEmpty(card)) return -1;
            if (string.IsNullOrEmpty(cellPhone)) return -1;
            try
            {
                tb_Log tlog = new tb_Log();
                tlog.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                tlog.type = "卡片挂失";
                tlog.operater = ImsInfo.CurrentUserId;
                tlog.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tlog.logmsg = "对卡号为:" + card + "的会员卡执行【挂失】操作。备注:"+memo;
                tlog.flag = true;
                LogHelperBLL.InsertObject(tlog);
                //string strSQL = "IF EXISTS (Select idno from tb_member where idno ='"+idno+"') update tb_Card set status = " + I_Lost + " where card = '" + card + "' ";
                string strSQL = "IF EXISTS (Select CellPhone from tb_member where CellPhone ='" + cellPhone + "') update tb_Card set status = " + I_Lost + " where card = '" + card + "' ";
                return DataExecSqlHelper.ExecuteNonQuerySql(strSQL); ;
            }
            catch (Exception exp)
            {
                LogHelper.Write(exp);
                return -1;
            }
        }
        /// <summary>
        /// 凭身手机号号码恢复会员卡正常状态（解挂）
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static int Card_JieGua(string card, string cellPhone,string memo)
        {
            if (string.IsNullOrEmpty(card)) return -1;
            if (string.IsNullOrEmpty(cellPhone)) return -1;
            try
            {
                tb_Log tlog = new tb_Log();
                tlog.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                tlog.type = "卡片解挂";
                tlog.operater = ImsInfo.CurrentUserId;
                tlog.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tlog.logmsg = "对卡号为:" + card + "的会员卡执行【解挂】操作。备注:" + memo;
                tlog.flag = true;
                LogHelperBLL.InsertObject(tlog);
                //string strSQL = "IF EXISTS (Select idno from tb_member where idno ='" + idno + "') update tb_Card set status = " + I_InUse + " where card = '" + card + "' ";
                string strSQL = "IF EXISTS (Select CellPhone from tb_member where CellPhone ='" + cellPhone + "') update tb_Card set status = " + I_InUse + " where card = '" + card + "' ";
                return DataExecSqlHelper.ExecuteNonQuerySql(strSQL); ;
            }
            catch (Exception exp)
            {
                LogHelper.Write(exp);
                return -1;
            }
        }
        /// <summary>
        /// 补卡
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static bool Card_BuKa(tb_Card o, string newcard)
        {
            if (o == null) return false;
            if (string.IsNullOrEmpty(newcard)) return false;

            tb_Card c1 = new tb_Card();
            c1.Userid = o.Userid;
            c1.card = o.card;
            c1.physicalno = o.physicalno;
            //c1.addeddate = o.addeddate;
            c1.activitytime = o.activitytime;
            c1.logouttime = o.logouttime;
            c1.validDate = o.validDate;
            c1.Status = I_ReSend;//<-该值变化
            c1.memo = DateTime.Now.ToString() + " " + c1.card + "号卡被执行补卡操作!";
            c1.chflag = o.chflag;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c1, DataExecCmdType.Update);
            tb_Card c2 = new tb_Card();
            c2.Userid = o.Userid;
            c2.card = newcard;
            c2.physicalno = newcard;
            //c2.addeddate = DateTime.Now.ToString();
            c2.activitytime = DateTime.Now.ToString();
            c2.activitystatus = 1;//彻底激活状态;
            c2.logouttime = o.logouttime;
            c2.validDate = "2030-12-31";
            c2.Status = I_InUse;
            c2.memo = DateTime.Now.ToString() + "执行补卡操作,用卡[" + newcard + "]替换卡[" + o.card + "]";
            c2.Status = I_InUse;
            c2.chflag = true;
            c2.isSysAuto = false;
            objects.Add(c2, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                tb_Log tlog = new tb_Log();
                tlog.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                tlog.type = "补卡";
                tlog.operater = ImsInfo.CurrentUserId;
                tlog.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                tlog.logmsg = "执行【补卡】操作。新卡：" + newcard + "旧卡：" + o.card;
                //tlog.flag = false;
                LogHelperBLL.InsertObject(tlog);
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
        /// 根据卡号返回用户id
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static string Card_GetUseridByCard(string card)
        {
            string strSQL = "select userid from tb_card where card ='" + card + "' ";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        //-------------------2011-9-29-----------------------
        /// <summary>
        /// 修改会员卡密码
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ChangeUserCardPass(tb_Card c, tb_Log log)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c, DataExecCmdType.Update);
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
        #endregion
        /// <summary>
        /// 判断用户是否已经有会员卡
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int CheckUserCard(string uid)
        {
            string strSQL = "select count(1) from tb_card where userid ='" + uid + "' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// 查看卡的状态，如是此卡处于未激活状态下，可以对其进行删除操作
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// 
        public static int IsCardstatus(string cardid)
        {
            string strSQL = "select status from dbo.tb_Card  where card='" + cardid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// 根据卡号与密码查询！此方法用去会员前台页面登录所用
        /// UserLogByCardidanPass
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// 
        public static int UserLogByCardidanPass(string cardid, string pass)
        {
            //string strSQL = "select COUNT(1) from dbo.tb_Card where card='" + cardid + "' and  pass='" + pass + "'";
            string strSQL = "select COUNT(1) from dbo.tb_Card where card='" + cardid + "' and  pass='" + pass + "'and activitystatus=1 or status=1";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        ///会员积分与余额统计
        /// </summary>
        /// <returns></returns>
        public static DataTable MemberCountOrder(string cardID, string userName, string siteid, string areacode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select SUM(balance),SUM(Points) from v_card_MemberCardInfo  where Status = 1");
            if (cardID != "")
            {
                sb.Append(" and card='" + cardID + "'");
            }
            if (userName != "")
            {
                sb.Append("  and RealName='" + userName + "'");
            }
            if (siteid != "")
            {
                sb.Append("  and  regionid='" + siteid + "' ");
            }
            if (areacode != "")
            {
                sb.Append("  and areacode ='" + areacode + "'");
            }
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 会员信息统计表
        /// </summary>
        /// <param name="card"></param>
        /// <param name="name"></param>
        /// <param name="area"></param>
        /// <param name="site"></param>
        /// <returns>DataTable</returns>
        public static DataTable MemberInfoTongJi(string card, string name, string area, string site,string siteid)
        {
            StringBuilder sb = new StringBuilder("select v.card  '会员卡号',v.RealName '会员姓名'," +
                     "v.balance '帐户余额', v.Points '积分' ,v.sitename  '所属门店'," +
                     "v.areaname'所在区域',v.addeddate '注册时间' from (select v_card_MemberCardInfo.card," +
                     "v_card_MemberCardInfo.RealName,v_card_MemberCardInfo.balance,v_card_MemberCardInfo.Points," +
                     "v_card_MemberCardInfo.areaname,v_card_MemberCardInfo.regionid,v_card_MemberCardInfo.areacode,v_card_MemberCardInfo.sitename,v_card_MemberCardInfo.addeddate " +
                     "from v_card_MemberCardInfo)  as v where 1=1  ");
            if (card != "")
            {
                sb.Append(" and v.card='" + card + "'");
            }
            if (name != "")
            {
                sb.Append(" and v.RealName='" + name + "'");
            }
            if (area != "")
            {
                sb.Append(" and v.areacode='" + area + "'");
            }
            if (site != "")
            {
                sb.Append(" and v.regionid='" + site + "'");
            }
            if (siteid != "")
            {
                sb.Append(" and v.regionid='" + siteid + "'");
            }
            return DataExecSqlHelper.ExecuteQuerySql(sb.ToString());
        }

        /// <summary>
        /// 分店统计表
        /// </summary>
        /// <param name="card"></param>
        /// <param name="name"></param>
        /// <param name="area"></param>
        /// <param name="site"></param>
        /// <returns>DataTable</returns>
        public static DataTable siteInfoTongJi(string siteid, string name, string area, string Category)
        {
            StringBuilder sb = new StringBuilder("select v.id  '分店编号',v.sitename '分店名称', v.areaname '所属区域', v.Category '所属行业' ," + "v.NUMconsume '消费交易笔数',v.Moneyconsume '消费交易总额',v.NUMrecharge '充值交易笔数',v.Moneyrecharge '充值交易总额',v.NUMRemove '撤单交易笔数',v.MoneyRemove '撤单交易总额' from (select a.id,a.sitename,a.balance,a.Category," + "a.areaname,a.NUMconsume,a.areacode,a.NUMrecharge ,a.NUMRemove,a.Moneyconsume,a.Moneyrecharge,a.MoneyRemove" + "  from v_site_SiteInfo as a)  as v where 1=1");
            if (siteid != "")
            {
                sb.Append(" and v.id='" + siteid + "'");
            }
            if (name != "")
            {
                sb.Append(" and v.sitename='" + name + "'");
            }
            if (Category != "")
            {
                sb.Append(" and v.Category='" + Category + "'");
            }
            if (area != "")
            {
                sb.Append(" and areacode='" + area + "'");
            }
            return DataExecSqlHelper.ExecuteQuerySql(sb.ToString());
        }


        /// <summary>
        /// 分店统计汇总
        /// </summary>
        /// <param name="card"></param>
        /// <param name="name"></param>
        /// <param name="area"></param>
        /// <param name="site"></param>
        /// <returns>DataTable</returns>
        public static DataTable siteInfoCount(string siteid, string name, string area, string Category)
        {
            StringBuilder sb = new StringBuilder("select sum(NUMconsume) as NC,sum(NUMrecharge) as NRc ,sum(NUMRemove) as NR,sum(Moneyconsume) as MC,sum(Moneyrecharge) AS MRc,sum(MoneyRemove) AS MR   from  v_site_SiteInfo  as  a  where 1=1");
            if (siteid != "")
            {
                sb.Append(" and v.id='" + siteid + "'");
            }
            if (name != "")
            {
                sb.Append(" and v.sitename='" + name + "'");
            }
            if (Category != "")
            {
                sb.Append(" and v.Category='" + Category + "'");
            }
            if (area != "")
            {
                sb.Append(" and areacode='" + area + "'");
            }
            return DataExecSqlHelper.ExecuteQuerySql(sb.ToString());
        }

        /// <summary>
        /// 会员卡期限统计表
        /// </summary>
        /// <param name="card"></param>
        /// <param name="name"></param>
        /// <param name="validate"></param>
        /// <returns>DataTable</returns>
        public static DataTable MemberCardDateTongji(string card, string name, string validate,string siteid)
        {
            StringBuilder sql = new StringBuilder(" select v.card  '会员卡号',v.RealName '会员姓名',v.sitename  '所属门店'," +
                "v.areaname '所在区域', v.activitytime '激活卡时间' ,v.validDate '有效时间按' ,v.activityway '激活方式' ," +
                "v.validDatetuse '有效状态' from (select v_card_MemberCardInfo.card,v_card_MemberCardInfo.RealName," +
                "v_card_MemberCardInfo.sitename,v_card_MemberCardInfo.areaname,v_card_MemberCardInfo.activitytime,v_card_MemberCardInfo.regionid," +
                "v_card_MemberCardInfo.validDate,v_card_MemberCardInfo.activityway ,v_card_MemberCardInfo.validDatetuse " +
                "from v_card_MemberCardInfo)as v where 1=1 ");
            if (card != "")
            {
                sql.Append(" and card='" + card + "'");
            }
            if (name != "")
            {
                sql.Append(" and RealName='" + name + "'");
            }
            if (validate != "")
            {
                sql.Append(" and validDatetuse='" + validate + "'");
            }
            if (siteid != "")
            {
                sql.Append(" and regionid='" + siteid + "'");
            }
            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }

        /// <summary>
        /// 发卡并激活
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SentCardAndActive(tb_Card c, tb_Member m, tb_CardActivityByShop s, tb_CardActive_Histroy h)
        {
            if (c == null || m == null || s == null || h == null)
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c, DataExecCmdType.Insert);
            objects.Add(m, DataExecCmdType.Insert);
            objects.Add(s, DataExecCmdType.Insert);
            objects.Add(h, DataExecCmdType.Insert);
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
        /// 删除卡并删除会员
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool DeleteCardAndMemBer(string cardID)
        {
            if (string.IsNullOrEmpty(cardID))
            {
                return false;
            }
            List<string> strList = new List<string>();


            //删除tb_Member
            string delsql2 = "delete  from  dbo.tb_Member where UserId=(select userid  from dbo.tb_Card where card='" + cardID + "')";
            strList.Add(delsql2);

            //删除tb_CardActivityByShop
            string delsql3 = "delete  from tb_CardActivityByShop where card='" + cardID + "'";
            strList.Add(delsql3);

            //删除tb_CardActivityByShop
            string delsql4 = "delete  from tb_CardActive_Histroy where card='" + cardID + "'";
            strList.Add(delsql4);

            //删除tb_Card
            string delsql11 = "delete  from dbo.tb_Card where card='" + cardID + "'";
            strList.Add(delsql11);


            List<int> reault = DataExecSqlHelper.ExecuteNonQuerySqls(strList);
            if (reault == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        //--------------------------

        /// <summary>
        /// 当没时间 对tb_Card表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int NotimeCountNoactiveCard()
        {
            string strSQL = " select COUNT(1) from dbo.tb_Card  where status=0  ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        /// 当有时间 对充值表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeCountNoactiveCard(string time1, string time2)
        {
            string strSQL = "select COUNT(1) from dbo.tb_Card  where  status=0  and  addeddate>='" + time1 + " 00:00:00' and  addeddate<= '" + time2 + " 23:59:60' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        /// 当没时间 对充值表进行删除
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int NotimeDeleteNoactiveCard()
        {
            string strSQL = " delete from dbo.tb_Card   where   status=0   ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        /// 当有时间 对充值表进行删除
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeDeleteNoactiveCard(string time1, string time2)
        {
            string strSQL = " delete from dbo.tb_Card   where  status=0  and  addeddate>='" + time1 + " 00:00:00' and  addeddate<= '" + time2 + " 23:59:60' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }



        //-------------------------------------------------------------------------------


        /// <summary>
        /// 当没时间 对tb_Card表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int NotimeCountYESactiveCard()
        {
            string strSQL = " select COUNT(1) from dbo.tb_Card  where status=1  ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        /// 当有时间 对充值表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeCountYESactiveCard(string time1, string time2)
        {
            string strSQL = "select COUNT(1) from dbo.tb_Card  where  status=1  and  addeddate>='" + time1 + " 00:00:00' and  addeddate<='" + time2 + " 23:59:60' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        /// 当没时间 取得所有的卡号
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static DataTable NotimeGetYESactiveCardID()
        {
            string strSQL = " select card from dbo.tb_Card where status =1  ";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
            return dt;
        }
        /// <summary>
        /// 当有时间 对充值表进行删除
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static DataTable HavetimeGetYESactiveCardID(string time1, string time2)
        {
            string strSQL = " select card from dbo.tb_Card   where  status=1  and  addeddate>='" + time1.Trim() + " 00:00:00' and  addeddate<='" + time2.Trim() + " 23:59:60'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
            return dt;
        }


        /// <summary>
        ///卡片延长
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool AddCardTime(tb_Card c, tb_Log log)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c, DataExecCmdType.Update);
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
        /// 当有时间 对充值表查看有没有数据
        /// </summary>
 
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HaveThatCard(string card)
        {
            string strSQL = "select COUNT(1) from dbo.tb_Card  where  card='" + card + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        ///根据会员编号获取卡号
        /// </summary>
        /// <returns></returns>
        public static string GetCardIDByUserID(string userid)
        {
            string strSQL = " SELECT card  FROM tb_Card WHERE userid ='"+userid+ "'";
            return DataExecSqlHelper.ExecuteScalarSql(strSQL).ToString();
   
        }

        /// <summary>
        ///更新会员，并更新卡所在组
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool UpdateCardAndMember(tb_Card c, tb_Member m)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c, DataExecCmdType.Update);
            objects.Add(m, DataExecCmdType.Update);
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
        /// 注销卡
        /// </summary>
        /// <param name="c"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool UpdateCard(tb_Card c)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c, DataExecCmdType.Update);
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

        public static int UpdateCard_ChargeList(card_chargelist list)
        {
            string strSQL = string.Format("update card_chargelist set chargetype='{0}' where transId='{1}'", list.Chargetype, list.transId);
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        /// <summary>
        /// 转换单张卡的卡类型
        /// </summary>
        /// <param name="cardno"></param>
        /// <param name="s_typ"></param>
        /// <param name="d_type"></param>
        /// <returns></returns>
        public static int updateCardTypeByCardNumAndTypeid(string cardno, string s_type,string d_type)
        {
            string strSql = "update tb_card set typeid = '"+d_type+"' Where card = '"+cardno+"' And typeID = '"+s_type+"'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }

        /// <summary>
        /// 执行会员续费
        /// </summary>
        /// <param name="oInput"></param>
        /// <returns></returns>
        public static string pr_Recharge(SqlParameter[] Pr)
        {
            string retstr = "";
            try
            {
                DataSet ds = SQLHelper.QueryStored("pr_Recharge", CommandType.StoredProcedure, Pr);
            }
            catch (Exception ex)
            {
                retstr = ex.ToString();
            }

            return retstr;
        }
        /// <summary>
        /// 执行会员开卡
        /// </summary>
        /// <param name="oInput"></param>
        /// <returns></returns>
        public static string pr_InCard(SqlParameter[] Pr)
        {
            string retstr = "";
            try
            {
                DataSet ds = SQLHelper.QueryStored("pr_InCard", CommandType.StoredProcedure, Pr);
            }
            catch (Exception ex)
            {
                retstr = ex.ToString();
            }

            return retstr;
        }
    }
}
