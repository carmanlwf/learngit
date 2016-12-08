using System;
using System.Collections.Generic;
using System.Text;
using Ims.Member.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Member.DAL;
using Ims.Card.Model;
using Ims.Log.Model;
using System.Data;
using System.Data.SqlClient;
namespace Ims.Member.BLL
{
    public class MemberHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_Member> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_Member o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "addeddate desc";
            List<tb_Member> objects = null;

            //if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//具有商户角色                
            //{
            //    //获取 areaid
            //    var agentInfoModel = ZsdDotNetLibrary.Data.DataExecSqlHelper.ExecuteQuerySql("select * from pub_agentinfo where id='" + Ims.Main.ImsInfo.CurrentUserId + "'");
            //    string areaid = agentInfoModel.Rows[0]["areaid"].ToString();
            //    //通过 areaid 获取siteids
            //    var siteids = ZsdDotNetLibrary.Data.DataExecSqlHelper.ExecuteQuerySql("select id from tb_Site  where areacode ='" + areaid + "'");
            //    List<string> siteidsList = new List<string>();
            //    for (var i = 0; i < siteids.Rows.Count; i++)
            //    {
            //        siteidsList.Add(siteids.Rows[i]["id"].ToString());
            //    }
            //    //取得areaid下的 siteids 下的对应的会员
            //    objects.FindAll(e => siteidsList.Contains(e.Regionid));
            //}
            //else
                objects = ObjectData.GetPagedObjects<tb_Member>(startIndex, pageSize, sortedBy, o, "v_member_MemberInfo");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_Member o)
        {
            return ObjectData.GetObjectsCount(o, "v_member_MemberInfo");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Member GetObject(string Userid)
        {
            tb_Member o = new tb_Member();
            o.Userid = Userid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_member_MemberInfo") as tb_Member;
        }

        /// <summary>
        /// 会员个人登录单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Member GetObject1(string Userid)
        {
            tb_Member o = new tb_Member();
            o.Userid = Userid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_UserCenter_MemberInfo") as tb_Member;
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
        public static int InsertObject(tb_Member o)
        {
            checkId(o, "会员编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_Member");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_Member o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_Member");
        }
        /// <summary>
        /// 更新会员主要资料
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(UserInfo o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_Member");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_Member o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_Member");
        }
        /// <summary>
        /// 用户发卡
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCard(tb_Card o1, tb_Member o2)
        {
            return MemberHelperDAL.SendCard(o1, o2);
        }
        /// <summary>
        /// 会员发卡（无会员，有卡）
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCardHaveCardNoMen(tb_Card c, tb_Member m, tb_CardActivityByShop v, tb_CardActive_Histroy h)
        {
            return MemberHelperDAL.SendCardHaveCardNoMen(c, m, v, h);
        }
        /// <summary>
        /// 会员发卡（有会员，无卡）
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCardToUser(tb_Card o1, UserCard o2)
        {
            return MemberHelperDAL.SendCardToUser(o1, o2);
        }
        /// <summary>
        /// 修改会员密码
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ChangeUserPass(UserCard u, tb_Log log)
        {
            return MemberHelperDAL.ChangeUserPass(u, log);
        }
        /// <summary>
        /// 激活卡操作(未进行临时激活的激活操作)新增会员信息
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ActiveCardForUser(UserInfo u, tb_card_active c, tb_Log log, tb_CardActivityByShop active, tb_CardActive_Histroy h)
        {
            return MemberHelperDAL.ActiveCardForUser(u, c, log, active, h);
        }
        /// <summary>
        /// 激活卡操作(进行过临时激活的激活操作)补充会员信息
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool ActiveCardForUser_Supplement(UserInfo u, tb_card_active c, tb_Log log, tb_CardActivityByShop active)
        {
            return MemberHelperDAL.ActiveCardForUser_Supplement(u, c, log, active);
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

            return MemberHelperDAL.MemberRank_Times(userRank);
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
            return MemberHelperDAL.MemberCard_Times(userid);
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
            return MemberHelperDAL.ChangeMemberCardPass(c, log);
        }
        //---------------------------------------2010-10-19----------------------------------------------
        /// <summary>
        /// 此方法用来判断Member的身份证号码是不是唯一性
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int MemberCardByIdNober(string idnum)
        {
            return MemberHelperDAL.MemberCardByIdNober(idnum);
        }
        public static DataTable MemberTable()
        {
            string sql = "select * from tb_Member  where RealName='无名单 '";
            StringBuilder sb = new StringBuilder();
            StringBuilder whe = new StringBuilder();
            sb.Append("select  from tb_Member ");
            return DataExecSqlHelper.ExecuteQuerySql(sql);
        }
        public static DataTable MemberInfo(string RealName, string UserId, string Card, string Telphone, string CellPhone, string sex, string UserRank, string addeddate1, string addeddate2, string siteid)
        {
            return MemberHelperDAL.MemberInfo(RealName, UserId, Card, Telphone, CellPhone, sex, UserRank, addeddate1, addeddate2, siteid);
        }
        /// <summary>
        /// 获取所有会员手机号
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPhonesAllNumbers()
        {
            return MemberHelperDAL.GetPhonesAllNumbers();
        }
        /// <summary>
        /// 此方法用来判断Member的手机号码是不是唯一性
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int CheckUserPhone(string phone)
        {
            return MemberHelperDAL.CheckUserPhone(phone);
        }
        /// <summary>
        /// 会员总数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int Usercount()
        {
            return DAL.MemberHelperDAL.Usercount();
        }

        /// <summary>
        /// 男会员总数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int NUsercount()
        {
            return DAL.MemberHelperDAL.NUsercount();
        }

        /// <summary>
        /// 女会员总数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int VUsercount()
        {
            return DAL.MemberHelperDAL.VUsercount();
        }
        /// <summary>
        /// 不记名卡
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int BUsercount()
        {
            return DAL.MemberHelperDAL.BUsercount();
        }

        /// <summary>
        /// 未激活卡
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int WUsercount()
        {
            return DAL.MemberHelperDAL.WUsercount();
        }
        /// <summary>
        /// 初始总金额
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static decimal moneyUsercount()
        {
            return DAL.MemberHelperDAL.moneyUsercount();
        }

        /// <summary>
        /// 统计交易
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int JYcount(int mode)
        {
            return DAL.MemberHelperDAL.JYcount(mode);
        }
    }
}
