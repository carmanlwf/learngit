using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.User;
using ZsdDotNetLibrary.Project.Configuration;
using ZsdDotNetLibrary.Web;
using System.Web;
using System.Security.Principal;
using ZsdDotNetLibrary.Log;
using ZsdDotNetLibrary.Utility;
using Ims.Main.Model;
using Ims.Main.BLL;
namespace Ims.Main
{
    public class ImsInfo
    {
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>The current.</value>
        static public UserInfo CurrentUser
        {
            get
            {
                UserInfo userInfo = UserHelper.GetUser<UserInfo>();
                if (userInfo == null)
                {
                    IPrincipal user = UserHelper.GetCurrentPrincipal();
                    if (user == null) return null;
                    try
                    {
                        LogHelper.Write(PropHelper.ObjectToString(user));
                    }
                    catch (System.IO.FileLoadException e)
                    {
                    }
                    userInfo = UserHelper.LogIn<UserInfo>(user.Identity.Name, null, false);
                    AgentInfo.LoadUserInfo(userInfo.Id, userInfo);
                }
                return userInfo;
            }
        }
        static public string CurrentUserId
        {
            get
            {

                IPrincipal user = UserHelper.GetCurrentPrincipal();
                if (user == null) return "";
                if (CurrentUser == null)
                {
                    LogHelper.Write(PropHelper.ObjectToString(user));
                    UserInfo userInfo = UserHelper.LogIn<UserInfo>(user.Identity.Name, null, false);
                    AgentInfo.LoadUserInfo(userInfo.Id, userInfo);
                }
                return user.Identity.Name;
            }
        }

        static public List<string> CurrentRoles
        {
            get
            {
                return UserHelper.GetRolesForUser();
            }
        }

        /// <summary>
        /// Determines whether [is in role] [the specified role].
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>
        /// 	<c>true</c> if [is in role] [the specified role]; otherwise, <c>false</c>.
        /// </returns>
        static public bool UserIsInRole(string role)
        {
            return UserHelper.IsInRole(role);
        }

        static public NclSettings CurrentConfig
        {
            get
            {
                return NclSettings.GetSection();
            }
        }

        static public string UserIsInRoles(string roles)
        {
            if (string.IsNullOrEmpty(roles)) return "";
            string[] arrroles = roles.Split(',');
            foreach (string role in arrroles)
            {
                if (UserIsInRole(role)) return role;
            }
            return "";
        }

        static public string CheckUserRoles(string roles)
        {
            string role = UserIsInRoles(roles);
            if (!string.IsNullOrEmpty(role)) return role;
            HttpContext.Current.Response.Redirect("~/Unauthorized.aspx");
            //WebClientHelper.DoResultClientProcess(false, "你无此操作的权限！", 0, WebClientHelper.ToDo.CloseSelfWindow);
            //HttpContext.Current.Response.End();
            return "";
        }


        //static public CustomerInfo CurrentCustomer
        //{
        //    get
        //    {
        //        CustomerInfo customerInfo = QSession.Session["CustomerInfo"] as CustomerInfo;
        //        if (customerInfo == null && HttpContext.Current != null)
        //        {
        //            string cust_id = (string)HttpContext.Current.Session["CustomerId"];
        //            if (cust_id != null)
        //            {
        //                customerInfo = CustomerInfoBLL.GetCustInfoFromId(cust_id);
        //                QSession.Session["CustomerInfo"] = customerInfo;
        //            }
        //        }

        //        return customerInfo;
        //    }
        //    set
        //    {
        //        QSession.Session["CustomerInfo"] = value;
        //        if (HttpContext.Current != null)
        //        {
        //            if (value != null)
        //            {
        //                HttpContext.Current.Session["CustomerId"] = value.cust_id;
        //            }
        //            else
        //            {
        //                HttpContext.Current.Session.Remove("CustomerId");
        //            }
        //        }
        //    }
        //}

        //static public bool PutCurrentCustomerBizInfo(string name, object value)
        //{
        //    CustomerInfo customerInfo = CurrentCustomer;
        //    if (customerInfo == null) return false;
        //    customerInfo.CurrBizInfos[name] = value;
        //    return true;
        //}

        //static public object GetCurrentCustomerBizInfo(string name)
        //{
        //    CustomerInfo customerInfo = CurrentCustomer;
        //    if (customerInfo == null) return "";
        //    object value = "";
        //    customerInfo.CurrBizInfos.TryGetValue(name, out value);
        //    return value;
        //}


    }
}
