using System;
using System.Collections.Generic;
using System.Text;
using Ims.Member.Model;
using Ims.Card.Model;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Log;
using Ims.Log.Model;
using System.Data;
using Ims.PM.BLL;

namespace Ims.Member.DAL
{
    public class MemberHelperDAL
    {
        /// <summary>
        /// 会员发卡（无会员，无卡）
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCard(tb_Card o1, tb_Member o2)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(o1, DataExecCmdType.Insert);
            objects.Add(o2, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务f
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
        /// 会员发卡（无会员，有卡）
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCardHaveCardNoMen(tb_Card c, tb_Member m, tb_CardActivityByShop v, tb_CardActive_Histroy h)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(c, DataExecCmdType.Insert);
            objects.Add(m, DataExecCmdType.Insert);
            objects.Add(v, DataExecCmdType.Insert);
            objects.Add(h, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务f
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
        /// 会员发卡（有会员，无卡）
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCardToUser(tb_Card o1, UserCard o2)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(o1, DataExecCmdType.Update);
            objects.Add(o2, DataExecCmdType.Update);
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
        /// 修改会员密码
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ChangeUserPass(UserCard u, tb_Log log)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(u, DataExecCmdType.Update);
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
        /// 激活卡操作(未进行临时激活的激活操作)新增会员信息
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ActiveCardForUser(UserInfo u, tb_card_active c, tb_Log log, tb_CardActivityByShop active, tb_CardActive_Histroy h)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(u, DataExecCmdType.Insert);
            objects.Add(c, DataExecCmdType.Update);
            objects.Add(log, DataExecCmdType.Insert);
            objects.Add(active, DataExecCmdType.Insert);
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
        /// 激活卡操作(进行过临时激活的激活操作)补充会员信息
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ActiveCardForUser_Supplement(UserInfo u, tb_card_active c, tb_Log log, tb_CardActivityByShop active)
        {
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(u, DataExecCmdType.Update);
            objects.Add(c, DataExecCmdType.Update);
            objects.Add(log, DataExecCmdType.Insert);
            objects.Add(active, DataExecCmdType.Update);
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
        /// ---------------------------------------
        /// 判断会员等级是否在会员中使用，如果在在使用状态，则不能删除
        /// <summary>
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int MemberRank_Times(string userRank)
        {
            string strSQL = "select COUNT(1) from dbo.tb_Member where UserRank = '" + userRank + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// ---------------------------------------
        /// 判断会员是否在会员中使用，如果在在使用状态，则不能删除
        /// <summary>
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int MemberCard_Times(string userid)
        {
            string strSQL = "select COUNT(1) from dbo.tb_Card where userid='" + userid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        //---------------------------------------2010-10-19----------------------------------------------
        /// <summary>
        /// 会员修改密码(网上)
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ChangeMemberCardPass(tb_Card c, tb_Member_Log log)
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
        //---------------------------------------2010-10-19----------------------------------------------
        /// <summary>
        /// 此方法用来判断Member的身份证号码是不是唯一性
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int MemberCardByIdNober(string idnum)
        {
            string strSQL = "select  COUNT(1) from tb_Member where idno='" + idnum + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 会员总数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int Usercount()
        {
            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select count(1) from tb_Member a INNER JOIN tb_Site b ON  a.RegionId = b.id where a.RealName!='无名单' and b.areacode ='" + areacode + "'";
            }
            else
                strSQL = "select  COUNT(1) from tb_Member where RealName!='无名单'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 不记名卡
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int BUsercount()
        {
            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select count(1) from tb_Member a INNER JOIN tb_Site b ON  a.RegionId = b.id where a.RealName='无名单' and b.areacode ='" + areacode + "'";
            }
            else
                strSQL = "select  COUNT(1) from tb_Member where RealName='无名单'";

            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 未激活卡
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int WUsercount()
        {
            

            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select  COUNT(1) from v_CardNoActive  where statusname='未激活' and areacode ='" + areacode + "'";
            }
            else
                strSQL = "select  COUNT(1) from v_CardNoActive  where statusname='未激活'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 统计交易
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int JYcount(int mode)
        {
            
            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select  COUNT(1) from v_pos_transaction where Mode='" + mode + "' and areacode ='" + areacode + "'";
            }
            else
                strSQL = "select  COUNT(1) from v_pos_transaction where Mode='" + mode + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        /// 初始总金额
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static decimal moneyUsercount()
        {
            string strSQL = "select  SUM(initvalue) from tb_Card where status !=0";
            string strSQL1 = "select  SUM(balance) from v_CardNoActive  where statusname='未激活'";
            string money1 = DataExecSqlHelper.ExecuteScalarSql(strSQL).ToString();

            string money2 = DataExecSqlHelper.ExecuteScalarSql(strSQL1).ToString();
            return decimal.Parse(string.IsNullOrEmpty(money1) ? "0" : money1) + decimal.Parse(string.IsNullOrEmpty(money2) ? "0" : money2);
        }

        /// <summary>
        /// 男会员总数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int NUsercount()
        {
            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select count(1) from tb_Member a INNER JOIN tb_Site b ON  a.RegionId = b.id where a.RealName!='无名单'and Gender='1' and b.areacode ='" + areacode + "'";
            }
            else
                strSQL = "select  COUNT(1) from tb_Member where RealName!='无名单'and Gender='1'";
            
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 女会员总数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int VUsercount()
        {
            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select count(1) from tb_Member a INNER JOIN tb_Site b ON  a.RegionId = b.id where a.RealName!='无名单'and Gender='0' and b.areacode ='" + areacode + "'";
            }
            else
                strSQL = "select  COUNT(1) from tb_Member where RealName!='无名单'and Gender='0'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 导出数据表v_member_MemberInfo
        /// </summary>
        /// <param name="RealName"></param>
        /// <param name="UserId"></param>
        /// <param name="Card"></param>
        /// <param name="Telphone"></param>
        /// <param name="CellPhone"></param>
        /// <param name="sex"></param>
        /// <param name="UserRank"></param>
        /// <param name="addeddate1"></param>
        /// <param name="addeddate2"></param>
        /// <returns>DataTable</returns>
        public static DataTable MemberInfo(string RealName, string UserId, string Card, string Telphone, string CellPhone, string sex, string UserRank, string addeddate1, string addeddate2, string siteid)
        {
            StringBuilder sqlQueryVmemberMemberInfo = new StringBuilder();
            sqlQueryVmemberMemberInfo.Append(" select  v.card as '卡号',v.RealName '姓名',v.sex '性别',v .BirthDate as '生日',v .idno as '身份证号' ,v .CellPhone as '手机号码',v .TelPhone as '固话' ,v .email as '邮件',QQ as 'Q号',v .name as '销售人员',GroupName as '所在组',v.addeddate '注册时间' from v_member_MemberInfo as v  where v.flag=1");
            if (RealName != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.RealName='" + RealName + "'");
            }
            if (UserId != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.UserId='" + UserId + "'");
            }
            if (Card != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.card='" + Card + "'");
            }
            if (Telphone != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.TelPhone='" + Telphone + "'");
            }
            if (CellPhone != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.CellPhone='" + CellPhone + "'");
            }
            if (sex != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.sex='" + sex + "'");
            }
            if (UserRank != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.UserRank='" + UserRank + "'");
            }
            if (addeddate1 != "" && addeddate2 != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.addeddate>='" + addeddate1 + "' and v.addeddate<='" + addeddate2 + "'");
            }
            if (addeddate1 != "" && addeddate2 == "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.addeddate>='" + addeddate1 + "'");
            }
            if (addeddate1 == "" && addeddate2 != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.addeddate<='" + addeddate2 + "'");
            }
            if (siteid != "")
            {
                sqlQueryVmemberMemberInfo.Append(" and v.id='" + siteid + "'");
            }
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sqlQueryVmemberMemberInfo.ToString());
            return dt;
        }
        /// <summary>
        /// 获取所有会员手机号
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPhonesAllNumbers()
        {
            string strSql = "select cellphone from tb_member where IsSms ='1'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// 此方法用来判断Member的手机号码是不是唯一性
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int CheckUserPhone(string phone)
        {
            string strSQL = "select  COUNT(1) from tb_Member where cellphone='" + phone + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
    }
}
