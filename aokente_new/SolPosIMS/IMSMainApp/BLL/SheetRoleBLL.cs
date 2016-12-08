using System;
using System.Collections.Generic;
using System.Text;
using Ims.Main.Model;
using ZsdDotNetLibrary.Project.DAL;
using System.Web.Security;
using ZsdDotNetLibrary.Data;
using Ims.Main.DAL;
namespace Ims.Main.BLL
{
    /// <summary>
    /// 处理岗信息维护业务逻辑层
    /// </summary>
    public class SheetRoleBLL
    {

        /// <summary>
        /// 根据查询条件,分页查询处理岗信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<SheetRoleInfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, SheetRoleInfo o)
        {
            List<SheetRoleInfo> objectBeans = ObjectData.GetPagedObjects<SheetRoleInfo>(startIndex, pageSize, sortedBy, o, "v_pub_sheetrole");
            return objectBeans;
        }

        /// <summary>
        /// 根据查询条件,获取处理岗or品质协调员信息总行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(SheetRoleInfo o)
        {
            return ObjectData.GetObjectsCount(o, "v_pub_sheetrole");
        }
        /// <summary>
        /// 根据处理岗信息实体,查询返回实体
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static SheetRoleInfo GetObject(SheetRoleInfo o)
        {
            return ObjectData.GetObject(o, "v_pub_sheetrole") as SheetRoleInfo;
        }
        ///// <summary>
        ///// 根据品质协调员信息实体,查询返回实体
        ///// </summary>
        ///// <param name="o"></param>
        ///// <returns></returns>
        //public static SheetRoleInfo GetObject(SheetRoleInfo o,string objName)
        //{
        //    return ObjectData.GetObject(o, objName) as SheetRoleInfo;
        //}
        /// <summary>
        /// 修改处理岗信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(SheetRoleInfo o)
        {
            checkId(o);
            SheetRoleInfo sheetRoleInfotmp = new SheetRoleInfo();
            sheetRoleInfotmp.id = o.id;
            sheetRoleInfotmp = GetObject(sheetRoleInfotmp);

            Membership.DeleteUser(o.id, true);
            Membership.CreateUser(o.id, o.pwd);
            //授权
            AuthoritySheetRole(o);

            return ObjectData.UpdateObject(o, "pub_sheetrole");
        }
        ///// <summary>
        ///// 四期
        ///// </summary>
        ///// <param name="o"></param>
        ///// <param name="roletype"></param>
        ///// <returns></returns>
        //public static int UpdateObject(SheetRoleInfo o, string roletype)
        //{
        //    checkId(o);
        //    SheetRoleInfo sheetRoleInfotmp = new SheetRoleInfo();
        //    sheetRoleInfotmp.id = o.id;
        //    sheetRoleInfotmp = GetObject(sheetRoleInfotmp);

        //    Membership.DeleteUser(o.id, true);
        //    Membership.CreateUser(o.id, o.pwd);
        //    //授权
        //    AuthoritySheetRole(o, roletype);

        //    return ObjectData.UpdateObject(o, "pub_sheetrole");
        //}
        /// <summary>
        /// 新增处理岗信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(SheetRoleInfo o)
        {
            checkId(o);

            MembershipUser user = Membership.GetUser(o.id);
            if (user != null)
            {
                Membership.DeleteUser(o.id, true);
            }

            Membership.CreateUser(o.id, o.pwd);
            //授权
            AuthoritySheetRole(o);

            return ObjectData.InsertObject(o, "pub_sheetrole");
        }
        ///// <summary>
        ///// 四期
        ///// </summary>
        ///// <param name="o"></param>
        ///// <param name="roletype"></param>
        ///// <returns></returns>
        //public static int InsertObject(SheetRoleInfo o, string roletype)
        //{
        //    checkId(o);

        //    MembershipUser user = Membership.GetUser(o.id);
        //    if (user != null)
        //    {
        //        Membership.DeleteUser(o.id, true);
        //    }

        //    Membership.CreateUser(o.id, o.pwd);
        //    //授权
        //    AuthoritySheetRole(o, roletype);

        //    return ObjectData.InsertObject(o, "pub_sheetrole");
        //}

        /// <summary>
        /// 删除处理岗信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(SheetRoleInfo o)
        {
            checkId(o);
            MembershipUser user = Membership.GetUser(o.id);
            if (user != null)
            {
                Membership.DeleteUser(o.id, true);
            }
            return ObjectData.DeleteObject(o);

        }
        /// <summary>
        /// 检查主健是否为空
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(SheetRoleInfo o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id 不能为空！");
            }

        }
        /// <summary>
        /// 检查是否存在处理岗信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool CheckData(SheetRoleInfo o)
        {
            SheetRoleInfo roleInfo = ObjectData.GetObject(o) as SheetRoleInfo;
            if (roleInfo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 四期数据
        /// </summary>
        /// <param name="o"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static bool CheckData(SheetRoleInfo o, string tablename)
        {
            SheetRoleInfo roleInfo = ObjectData.GetObject(o, tablename) as SheetRoleInfo;
            if (roleInfo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 授权，固定权限
        /// </summary>
        /// <param name="o"></param>
        private static void AuthoritySheetRole(SheetRoleInfo o)
        {
            //授权
            if (o.role_type == SheetRoleDAL.TM_ROLE_TYPE || o.role_type == SheetRoleDAL.KMANDTM_ROLE_TYPE)
            {
                if (o.type.Trim() == "00")//协调员
                {
                    Roles.AddUserToRole(o.id, "tm");
                    Roles.AddUserToRole(o.id, "tm_coordinator");//协调员

                    Roles.AddUserToRole(o.id, "tm_branchticket");//查询本公司转办处理情况

                    Roles.AddUserToRole(o.id, "tm_report");//报表员
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketbranch");//转办业务本公司报表
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketefficiencybranch");//转办时效本公司报表
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketlistbranch");//转办本公司清单表
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketchannelbranch");//转办渠道本公司报表
                }
                else if (o.type.Trim() == "11")//处理岗
                {
                    Roles.AddUserToRole(o.id, "tm");
                    Roles.AddUserToRole(o.id, "tm_disposal");//处理岗
                    Roles.AddUserToRole(o.id, "tm_disposalmanage");//处理岗转办管理
                    Roles.AddUserToRole(o.id, "tm_selfticket");//查询本人转办处理情况
                    Roles.AddUserToRole(o.id, "tm_report");//报表员
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketself");//转办业务本人报表
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketefficiencyself");//转办时效个人报表
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketlistself");//转办个人清单表
                    Roles.AddUserToRole(o.id, "tm_rpt_ticketchannelself");//转办渠道本人报表
                }
            }
            else if (o.role_type == SheetRoleDAL.OBTM_ROLE_TYPE)
            {
                if (o.type.Trim() == "00")
                {
                    Roles.AddUserToRole(o.id, "obtm_deal");
                    Roles.AddUserToRole(o.id, "obtm_dealsheet");
                    Roles.AddUserToRole(o.id, "obtm_report");
                    Roles.AddUserToRole(o.id, "obtm_rpt_ticketefficiencybranch");
                }
            }
            if (o.role_type == SheetRoleDAL.KMANDTM_ROLE_TYPE || o.role_type == SheetRoleDAL.KM_ROLE_TYPE)
            {
                Roles.AddUserToRole(o.id, "km_orgupnewmode");//上传新模板
            }
        }
        ///// <summary>
        ///// 四期
        ///// </summary>
        ///// <param name="o"></param>
        ///// <param name="roletype"></param>
        //private static void AuthoritySheetRole(SheetRoleInfo o, string roletype)
        //{
        //    //授权
        //    if (o.role_type == SheetRoleDAL.TM_ROLE_TYPE || o.role_type == SheetRoleDAL.KMANDTM_ROLE_TYPE)
        //    {
        //        if (o.type.Trim() == "00")//协调员
        //        {
        //            Roles.AddUserToRole(o.id, "tm");
        //            Roles.AddUserToRole(o.id, "tm_coordinator");//协调员

        //            Roles.AddUserToRole(o.id, "tm_branchticket");//查询本公司转办处理情况

        //            Roles.AddUserToRole(o.id, "tm_report");//报表员
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketbranch");//转办业务本公司报表
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketefficiencybranch");//转办时效本公司报表
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketlistbranch");//转办本公司清单表
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketchannelbranch");//转办渠道本公司报表
        //        }
        //        else if (o.type.Trim() == "11")//处理岗
        //        {
        //            Roles.AddUserToRole(o.id, "tm");
        //            Roles.AddUserToRole(o.id, "tm_disposal");//处理岗
        //            Roles.AddUserToRole(o.id, "tm_disposalmanage");//处理岗转办管理
        //            Roles.AddUserToRole(o.id, "tm_selfticket");//查询本人转办处理情况
        //            Roles.AddUserToRole(o.id, "tm_report");//报表员
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketself");//转办业务本人报表
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketefficiencyself");//转办时效个人报表
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketlistself");//转办个人清单表
        //            Roles.AddUserToRole(o.id, "tm_rpt_ticketchannelself");//转办渠道本人报表
        //        }
        //    }
        //    else if (o.role_type == SheetRoleDAL.OBTM_ROLE_TYPE)
        //    {
        //        if (o.type.Trim() == "00")
        //        {
        //            Roles.AddUserToRole(o.id, "obtm_deal");
        //            Roles.AddUserToRole(o.id, "obtm_dealsheet");
        //            Roles.AddUserToRole(o.id, "obtm_report");
        //            Roles.AddUserToRole(o.id, "obtm_rpt_ticketefficiencybranch");
        //        }
        //    }
        //    if (o.role_type == SheetRoleDAL.KMANDTM_ROLE_TYPE || o.role_type == SheetRoleDAL.KM_ROLE_TYPE)
        //    {
        //        Roles.AddUserToRole(o.id, "km_orgupnewmode");//上传新模板
        //    }
        //}

        /// <summary>
        /// 更改用户登录密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool ChangePWD(string userid, string pwd)
        {
            MembershipUser user = Membership.GetUser(userid);
            if (user == null)
            {
                Membership.CreateUser(userid, pwd);
            }
            SheetRoleInfo sheettemp = new SheetRoleInfo();
            sheettemp.id = userid;
            sheettemp = GetObject(sheettemp);
            if (sheettemp == null) return false;
            bool ismodify = user.ChangePassword(sheettemp.pwd, pwd);
            if (ismodify)
            {
                SheetRoleInfo o = new SheetRoleInfo();
                o.id = userid;
                o.pwd = pwd;
                ObjectData.UpdateObject(o);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 恢复登录状态
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int BackUpLoginStatus(SheetRoleInfo o)
        {
            if (o != null && !string.IsNullOrEmpty(o.id))
            {
                return SheetRoleDAL.BackUpLoginStatus(o);
            }
            else
            {
                return 0;
            }
        }
    }
}
