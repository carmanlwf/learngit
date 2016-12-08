using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Card.Model;
using ZsdDotNetLibrary.Data;
using Ims.Card.DAL;
using System.Web.Security;
using Ims.Member.Model;
using Ims.Log.Model;
using System.Data;
using System.Data.SqlClient;
namespace Ims.Card.BLL
{
    public class CardHelperBLL
    {
        /// <summary>
        /// -------多个对象---------  
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_Card> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_Card o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "card,activitytime DESC"; }
            List<tb_Card> objects = ObjectData.GetPagedObjects<tb_Card>(startIndex, pageSize, sortedBy, o, "v_card_MemberCardInfo");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_Card o)
        {
            return ObjectData.GetObjectsCount(o, "v_card_MemberCardInfo");
        }
        /// <summary>
        /// 多个对象_noactive 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_Card> GetPagedObjects_NoActive(int startIndex, int pageSize, string sortedBy, tb_Card o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "addeddate DESC"; }
            List<tb_Card> objects = ObjectData.GetPagedObjects<tb_Card>(startIndex, pageSize, sortedBy, o, "v_card_MemberCardInfoNoActive");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_NoActive(tb_Card o)
        {
            return ObjectData.GetObjectsCount(o, "v_card_MemberCardInfoNoActive");
        }
        /// <summary>
        /// 多个对象_noactive 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_Card> GetPagedObjects_Register(int startIndex, int pageSize, string sortedBy, tb_Card o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "addeddate DESC"; }
            List<tb_Card> objects = ObjectData.GetPagedObjects<tb_Card>(startIndex, pageSize, sortedBy, o, "v_card_BatchRegister");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_Register(tb_Card o)
        {
            return ObjectData.GetObjectsCount(o, "v_card_BatchRegister");
        }
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_CardActivityByShop> GetPagedOActivityCardObjs(int startIndex, int pageSize, string sortedBy, tb_CardActivityByShop o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "logtime desc,activitydate DESC"; }
            List<tb_CardActivityByShop> objects = ObjectData.GetPagedObjects<tb_CardActivityByShop>(startIndex, pageSize, sortedBy, o, "v_card_CardActivityByShop");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>GetPagedOActivityCardObjsCount
        public static int GetPagedOActivityCardObjsCount(tb_CardActivityByShop o)
        {
            return ObjectData.GetObjectsCount(o, "v_card_CardActivityByShop");
        }

        /// <summary>
        /// 多个对象 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_card_CardActivityHistroy> GetPagedObjects_Select(int startIndex, int pageSize, string sortedBy, v_card_CardActivityHistroy o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "activetime DESC"; }
            List<v_card_CardActivityHistroy> objects = ObjectData.GetPagedObjects<v_card_CardActivityHistroy>(startIndex, pageSize, sortedBy, o, "v_card_CardActivityHistroy");
            return objects;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_Select(v_card_CardActivityHistroy o)
        {
            return ObjectData.GetObjectsCount(o, "v_card_CardActivityHistroy");
        }
        /// <summary>
        /// 选择激活的单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_CardActivityByShop GetActiveObject(string Card)
        {
            tb_CardActivityByShop o = new tb_CardActivityByShop();
            o.card = Card;
            //checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_CardActivityByShop") as tb_CardActivityByShop;
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetObject(string Card)
        {
            tb_Card o = new tb_Card();
            o.card = Card;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_card_MemberCardInfo") as tb_Card;
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetBalanceObject(string Card)
        {
            tb_Card o = new tb_Card();
            o.card = Card;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_Card") as tb_Card;
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetObject(string Card, string siteid)
        {
            tb_Card o = new tb_Card();
            o.card = Card;
            o.regionid = siteid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_card_MemberCardInfo") as tb_Card;
        }
        /// <summary>
        /// 单个可用的空闲卡对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetObject_GetSingleNoActiveCard(string Card)
        {
            tb_Card o = new tb_Card();
            o.card = Card;
            o.Status = 0;//未激活状态
            o.activitystatus = 0;//未激活的卡
            checkId(o, "选择的空闲卡对象不存在！");
            return ObjectData.GetObject(o, "tb_Card") as tb_Card;
        }
        /// <summary>
        /// 单个卡对象(不分激活/未激活)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetObject_AllCard(string card,string typeid)
        {
            tb_Card o = new tb_Card();
            o.card = card;
            o.TypeID = typeid;
            checkId(o, "选择的空闲卡对象不存在！");
            return ObjectData.GetObject(o, "tb_Card") as tb_Card;
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetObject_BatchCardRegistion(string Card)
        {
            tb_Card o = new tb_Card();
            o.card = Card;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_card") as tb_Card;
        }
        /// <summary>
        /// 单个对象(对表)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetObject_objec(string Card)
        {
            tb_Card o = new tb_Card();
            o.card = Card;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_Card") as tb_Card;
        }
        /// <summary>
        /// 卡与会员对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Card GetObject_CardAndMember(string Card)
        {
            tb_Card o = new tb_Card();
            o.card = Card;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_Card") as tb_Card;
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
                //throw new Exception(errmessage);
                return;
            }

        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_card(tb_Card o)
        {
            return ObjectData.GetObjectsCount(o, "tb_Card");
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(tb_Card o)
        {
            checkId(o, "会员卡号 不能为空！");
            return ObjectData.InsertObject(o, "tb_Card");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_Card o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_Card");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_Card o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_Card");
        }

        /// <summary>
        /// 凭身份证号挂失会员卡
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static int Card_GuaShi(string card, string cellPhone,string memo)
        {
            return CardHelperDAL.Card_GuaShi(card, cellPhone, memo);
        }
        /// <summary>
        /// 凭身份证号恢复会员卡正常状态（解挂）
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static int Card_JieGua(string card, string idno, string memo)
        {
            return CardHelperDAL.Card_JieGua(card, idno,memo);
        }
        /// <summary>
        /// 凭交易密码补卡
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static bool Card_BuKa(tb_Card o, string newcard)
        {
            return CardHelperDAL.Card_BuKa(o, newcard);
        }
        /// <summary>
        /// 凭身份证号挂失会员卡
        /// </summary>
        /// <param name="card"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public static int Card_XiaoKa(string card)
        {
            return CardHelperDAL.Card_XiaoKa(card);
        }

        /// <summary>
        /// 根据卡号返回用户id
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static string Card_GetUseridByCard(string card)
        {
            return CardHelperDAL.Card_GetUseridByCard(card);
        }
        /// <summary>
        /// 判断用户是否已经有会员卡
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static int CheckUserCard(string uid)
        {
            return CardHelperDAL.CheckUserCard(uid);
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
            return CardHelperDAL.ChangeUserCardPass(c, log);
        }
        // ----------------------//-------------------------
        /// <summary>
        /// 查看卡的状态，如是此卡处于未激活状态下，可以对其进行 0状态
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// 
        public static int IsCardstatus(string cardid)
        {
            return CardHelperDAL.IsCardstatus(cardid);
        }
        /// <summary>
        /// 根据卡号与密码查询！此方法用去会员前台页面登录所用
        /// UserLogByCardidanPass
        /// </summary>
        /// <param name="cardid"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        /// 
        public static int UserLogByCardidanPass(string cardid, string pass)
        {
            return CardHelperDAL.UserLogByCardidanPass(cardid, pass);
        }





        /// <summary>
        ///会员积分与余额统计
        /// </summary>
        /// <returns></returns>
        public static DataTable MemberCountOrder(string cardID, string userName, string siteid, string areacode)
        {
            return CardHelperDAL.MemberCountOrder(cardID, userName, siteid, areacode);
        }



        /// <summary>
        /// 发卡并激活
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SentCardAndActive(tb_Card c, tb_Member m, tb_CardActivityByShop s, tb_CardActive_Histroy h)
        {
            return CardHelperDAL.SentCardAndActive(c, m, s, h);
        }




        /// <summary>
        /// 删除卡并删除会员
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool DeleteCardAndMemBer(string cardID)
        {
            return CardHelperDAL.DeleteCardAndMemBer(cardID);
        }


        /// <summary>
        /// 转换单张卡的卡类型
        /// </summary>
        /// <param name="cardno"></param>
        /// <param name="s_typ"></param>
        /// <param name="d_type"></param>
        /// <returns></returns>
        public static int updateCardTypeByCardNumAndTypeid(string cardno, string s_type, string d_type)
        {
            return CardHelperDAL.updateCardTypeByCardNumAndTypeid(cardno, s_type, d_type);
        }




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
            return CardHelperDAL.NotimeCountNoactiveCard();
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
            return CardHelperDAL.HavetimeCountNoactiveCard(time1, time2);
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
            return CardHelperDAL.NotimeDeleteNoactiveCard();
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
            return CardHelperDAL.HavetimeDeleteNoactiveCard(time1, time2);
        }






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
            return CardHelperDAL.NotimeCountYESactiveCard();
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
            return CardHelperDAL.HavetimeCountYESactiveCard(time1, time2);
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
            return CardHelperDAL.NotimeGetYESactiveCardID();
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
            return CardHelperDAL.HavetimeGetYESactiveCardID(time1, time2);
        }

        /// <summary>
        /// 会员信息统计表
        /// </summary>
        /// <param name="card"></param>
        /// <param name="name"></param>
        /// <param name="area"></param>
        /// <param name="site"></param>
        /// <returns>DataTable</returns>
        public static DataTable MemberInfoTongJi(string card, string name, string area, string site, string siteid)
        {
            return CardHelperDAL.MemberInfoTongJi(card, name, area, site, siteid);
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
            return CardHelperDAL.siteInfoTongJi(siteid, name, area, Category);
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
            return CardHelperDAL.siteInfoCount(siteid, name, area, Category);
        }

        /// <summary>
        /// 会员卡期限统计表
        /// </summary>
        /// <param name="card"></param>
        /// <param name="name"></param>
        /// <param name="validate"></param>
        /// <returns>DataTable</returns>
        public static DataTable MemberCardDateTongji(string card, string name, string validate, string siteid)
        {
            return CardHelperDAL.MemberCardDateTongji(card, name, validate, siteid);
        }


        /// <summary>
        ///卡片延长
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool AddCardTime(tb_Card c, tb_Log log)
        {
            return CardHelperDAL.AddCardTime(c, log);
        }



        /// <summary>
        /// 当有时间 对充值表查看有没有数据
        /// </summary>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HaveThatCard(string card)
        {
            return CardHelperDAL.HaveThatCard(card);
        }

        /// <summary>
        ///根据会员编号获取卡号
        /// </summary>
        /// <returns></returns>
        public static string GetCardIDByUserID(string userid)
        {
            return CardHelperDAL.GetCardIDByUserID(userid);
        }

        /// <summary>
        ///更新会员，并更新卡所在组
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool UpdateCardAndMember(tb_Card c, tb_Member m)
        {
            return CardHelperDAL.UpdateCardAndMember(c, m);
        }

        public static bool UpdateCard(tb_Card c)
        {
            return CardHelperDAL.UpdateCard(c);
        }

        /// <summary>
        /// 删除充值表
        /// </summary>
        /// <param name="cardid"></param>
        /// <returns></returns>
        public static int UpdateCard_ChargeList(card_chargelist list)
        {
            return CardHelperDAL.UpdateCard_ChargeList(list);
        }

       
    }
}
