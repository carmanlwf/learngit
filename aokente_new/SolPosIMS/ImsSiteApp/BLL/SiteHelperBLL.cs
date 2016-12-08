using System;
using System.Collections.Generic;
using System.Text;
using Ims.Site.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Site.DAL;
using System.Data;

namespace Ims.Site.BLL
{
    public class SiteHelperBLL
    {

        /// <summary>
        /// 查看路段信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetPagedObjects_sitefeelist(price_temp_sitefeelist o)
        {
            string str = @"select pid from price_temp_sitefeelist where Siteid ='" + o.Siteid + "'";
            DataTable objects = DataExecSqlHelper.ExecuteQuerySql(str);

            return objects;
        }
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_site> GetPagedObjects_id(tb_site o)
        {
            string str = @"select id,sitename from tb_site where 1=1";
            if (!string.IsNullOrEmpty(o.areacode))
                str += " and areacode = '" + o.areacode + "'";
          
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(str);

            List<tb_site> objects = new List<tb_site>();
            foreach (DataRow r in dt.Rows)
            {
                tb_site site = new tb_site();
                site.id = r["id"].ToString();
                site.sitename = r["sitename"].ToString();
                objects.Add(site);
            }
            return objects;
        }

        /// <summary>
        /// 分店统计
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable SiteGetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_site o)
        {
            string where = "";
            string str = "";

            string sqlselect = "select s.*,c.areaname, (select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") as CountMoney, (select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") as NumMoney,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=3 " + where + ") as CountPoint,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=3 " + where + ") as NumPoint,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") as CountCZ,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") as NumCZ,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ")  as CountCDM,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ") as NumCDM,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=4 " + where + ") as CountCDP,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=4 " + where + ") as NumCDP from tb_Site as s ,tb_Area as c where s.areacode=c.areacode and 1=1 " + str + "";

            DataTable dt = DataExecSqlHelper.ExecutePagingSql(sqlselect, startIndex, pageSize, "id", sortedBy, true);
            return dt;
        }

        public static DataTable SiteGetPagedObject(int startIndex, int pageSize, string sortedBy, tb_site o)
        {
            string StrSql = @"
                                  SELECT Possnr, ISNULL(SUM(case Mode when 1 then 1 else 0 end),0) as XFTJ_Count,
		 ISNULL(SUM(case Mode when 11 then 1 else 0 end),0) as CZTJ_Count, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then 1 else 0 end),0) as CDTJ_Count, 
		 ISNULL(SUM(case Mode when 1 then [Money] else 0 end),0) as XFTJ_Amount,
		 ISNULL(SUM(case Mode when 11 then [Money] else 0 end),0) as CZTJ_Amount, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then [Money] else 0 end),0) as CDTJ_Amount
  FROM tb_POS_Transaction Where 1=1 ";

            StrSql += " Group By Possnr";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            return dt;
        }

        /// <summary>
        /// 分店统计导出
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable SiteCountOut(string where, string str)
        {
            return DAL.SiteandAreaHelperDAL.SiteCountOut(where, str);
        }

        public static DataTable SiteCountOutMachine(string where, string str)
        {
            return DAL.SiteandAreaHelperDAL.SiteCountOutMachine(where, str);
        }
        /// <summary>
        /// 统计总次数
        /// </summary>
        /// <returns></returns>
        /// 
        public static int NumPosTransaction(int num, string str)
        {
            return DAL.SiteandAreaHelperDAL.NumPosTransaction(num,str);
        }
        /// <summary>
        /// 统计总金额
        /// </summary>
        /// <returns></returns>
        /// 
        public static decimal CountMoneyPosTransaction(int num, string str)
        {
            return DAL.SiteandAreaHelperDAL.CountMoneyPosTransaction(num, str);
        }

        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_site> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_site o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "sitename desc";

            List<tb_site> objects = ObjectData.GetPagedObjects<tb_site>(startIndex, pageSize, sortedBy, o, "v_site_SiteInfo");
            return objects;
        }



        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjects_Count(tb_site o)
        {
            return ObjectData.GetObjectsCount(o, "v_site_SiteInfo");
        }

        /// <summary>
        /// ---------------------------------------
        /// 清除门店统计
        /// </summary>
        /// <returns></returns>
        /// 
        public static int UpateCountSite()
        {
            return DAL.SiteandAreaHelperDAL.UpateCountSite();
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_site o)
        {
            string StrSql = @"
                                  SELECT ISNULL(SUM(case Mode when 1 then 1 else 0 end),0) as XFTJ_Count,
		 ISNULL(SUM(case Mode when 11 then 1 else 0 end),0) as CZTJ_Count, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then 1 else 0 end),0) as CDTJ_Count, 
		 ISNULL(SUM(case Mode when 1 then [Money] else 0 end),0) as XFTJ_Amount,
		 ISNULL(SUM(case Mode when 11 then [Money] else 0 end),0) as CZTJ_Amount, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then [Money] else 0 end),0) as CDTJ_Amount
  FROM tb_POS_Transaction Where 1=1 ";

            //if (!string.IsNullOrEmpty(o.machineid))
            //    StrSql += "And Possnr ='" + o.machineid + "'";
            //if (!string.IsNullOrEmpty(o.regtime1) && !string.IsNullOrEmpty(o.regtime2))
            //    StrSql += "And Datetime >= Replace('" + o.regtime1 + "','-','/') And Datetime <= Replace('" + o.regtime2 + "','-','/')";
            //StrSql += " Group By Possnr";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows.Count;
            else
                return 0;
            //string where = "";
            //string str = "";
            //if (!string.IsNullOrEmpty(o.regtime3))
            //{
            //    where += " and Datetime>='" + o.regtime3.ToString() + " 00:00:00' ";
            //}

            //if (!string.IsNullOrEmpty(o.regtime4))
            //{
            //    where += " and Datetime<='" + o.regtime4.ToString() + " 23:59:60' ";
            //}

            //string sqlselect = "select s.*,c.areaname, (select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") as CountMoney, (select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") as NumMoney,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=3 " + where + ") as CountPoint,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=3 " + where + ") as NumPoint,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") as CountCZ,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") as NumCZ,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ")  as CountCDM,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ") as NumCDM,(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=4 " + where + ") as CountCDP,(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=4 " + where + ") as NumCDP from tb_Site as s ,tb_Area as c where s.areacode=c.areacode and 1=1 " + str + "";

            //DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sqlselect);
            //return dt.Rows.Count;
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_site GetObject(string id)
        {
            tb_site o = new tb_site();
            o.id= id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_site_SiteInfo") as tb_site;
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
        public static int InsertObject(tb_site o)
        {
            checkId(o, "路段编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_site");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_site o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_site");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_site o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_site");
        }
        /// <summary>
        /// ---------------------------------------
        /// 判断门店是否是否在卡片中在使用，如果在在使用状态，则不能删除
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Site_Times(string siteid)
        {
            return SiteandAreaHelperDAL.Site_Times(siteid);
        }
                /// <summary>
        /// ---------------------------------------
        /// 根据区域号码得到所有的分店号与名字
        /// GetAllSiteByAreacodeID
        /// </summary>
        /// <returns></returns>
        /// 
        public static string GetAreacodeIDSiteBysiteID(string siteid)
        {
            return SiteandAreaHelperDAL.GetAreacodeIDSiteBysiteID(siteid);
        }
        /// <summary>
        /// ---------------------------------------
        /// 判断tb_site中是否已存在相同的机器码  
        /// Site_Machineid
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Site_Machineid(string machineid)
        {
            return SiteandAreaHelperDAL.Site_Machineid(machineid);
        }

        /// <summary>
        /// ---------------------------------------
        /// 统计门店数
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countSite()
        {
            return DAL.SiteandAreaHelperDAL.countSite();
        }


        /// <summary>
        /// ---------------------------------------
        /// 允许充值的终端
        /// </summary>
        /// <returns></returns>
        /// 
        public static int KcountSite()
        {
            return DAL.SiteandAreaHelperDAL.KcountSite();
        }     
        /// <summary>
        ///判断tb_Pos_Operator 是否有相同数据
        /// </summary>
        /// <returns></returns>
        public static int tb_Pos_Operatorid(string operatorid)
        {
            return SiteandAreaHelperDAL.tb_Pos_Operatorid(operatorid);
        }
        public static DataTable RptSiteCountGetPagedObject(int startIndex, int pageSize, string sortedBy, tb_site o)
        {
            string StrSql = @"
                                  SELECT x.PosSnr,x.XFTJ_Count,x.CZTJ_Count,x.CDTJ_Count,x.XFTJ_Amount,x.CZTJ_Amount,x.CDTJ_Amount,y.id,y.sitename FROM (SELECT Possnr, ISNULL(SUM(case Mode when 1 then 1 else 0 end),0) as XFTJ_Count,
		 ISNULL(SUM(case Mode when 11 then 1 else 0 end),0) as CZTJ_Count, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then 1 else 0 end),0) as CDTJ_Count, 
		 ISNULL(SUM(case Mode when 1 then [Money] else 0 end),0) as XFTJ_Amount,
		 ISNULL(SUM(case Mode when 11 then [Money] else 0 end),0) as CZTJ_Amount, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then [Money] else 0 end),0) as CDTJ_Amount
  FROM tb_POS_Transaction Where 1=1 ";

            //if (!string.IsNullOrEmpty(o.machineid))
            //    StrSql += "And Possnr ='" + o.machineid + "'";
            //if (!string.IsNullOrEmpty(o.regtime1) && !string.IsNullOrEmpty(o.regtime2))
            //    StrSql += "And Datetime >= Replace('" + o.regtime1 + "','-','/') And Datetime <= Replace('" + o.regtime2 + "','-','/')";
            if (!string.IsNullOrEmpty(o.sitename))
                StrSql += "And sitename = '" + o.sitename + "'";
            StrSql += " Group By Possnr) as x ";
            StrSql += "LEFT JOIN pos_poslist as z ON z.posnum = x.PosSnr ";
            StrSql += "LEFT JOIN tb_Site as y ON z.posnum = y.posnum";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            return dt;
        }
        public static int RptSiteCountDataCount(tb_site o)
        {
            string StrSql = @"
                                  SELECT x.PosSnr,x.XFTJ_Count,x.CZTJ_Count,x.CDTJ_Count,x.XFTJ_Amount,x.CZTJ_Amount,x.CDTJ_Amount,y.id,y.sitename FROM (SELECT Possnr, ISNULL(SUM(case Mode when 1 then 1 else 0 end),0) as XFTJ_Count,
		 ISNULL(SUM(case Mode when 11 then 1 else 0 end),0) as CZTJ_Count, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then 1 else 0 end),0) as CDTJ_Count, 
		 ISNULL(SUM(case Mode when 1 then [Money] else 0 end),0) as XFTJ_Amount,
		 ISNULL(SUM(case Mode when 11 then [Money] else 0 end),0) as CZTJ_Amount, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then [Money] else 0 end),0) as CDTJ_Amount
  FROM tb_POS_Transaction Where 1=1 ";

            //if (!string.IsNullOrEmpty(o.machineid))
            //    StrSql += "And Possnr ='" + o.machineid + "'";
            //if (!string.IsNullOrEmpty(o.regtime1) && !string.IsNullOrEmpty(o.regtime2))
            //    StrSql += "And Datetime >= Replace('" + o.regtime1 + "','-','/') And Datetime <= Replace('" + o.regtime2 + "','-','/')";
            if (!string.IsNullOrEmpty(o.sitename))
                StrSql += "And sitename = '"+o.sitename+"'";
            StrSql += " Group By Possnr) as x ";
            StrSql += "LEFT JOIN pos_poslist as z ON z.posnum = x.PosSnr ";
            StrSql += "LEFT JOIN tb_Site as y ON z.posnum = y.posnum";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows.Count;
            else
                return 0;
        }
        /// <summary>
        ///判断tb_site是否存在下属的车位,在删除路段的时候要判断
        /// </summary>
        /// <returns></returns>
        public static int IsHasSpotBySiteid(string siteid)
        {
            return SiteandAreaHelperDAL.IsHasSpotBySiteid(siteid);
        }
    }
}
