using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ZsdDotNetLibrary.Web;
using System.Web.UI;
using System.Web;
using ZsdDotNetLibrary.Project.BLL;
using Ims.PM.DAL;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.PM.BLL
{
    public class PmTtBLLHelper
    {
        public PmTtBLLHelper()
        { }

        /// <summary>
        /// ��ȡ���е��ֶ���Ϣ
        /// </summary>
        /// <param name="fieldname"></param>
        /// <param name="tablename"></param>
        /// <param name="resultfield"></param>
        /// <param name="fieldvalue"></param>
        /// <returns></returns>
        public static string GetFieldInfo(string fieldname, string tablename, string resultfield, string fieldvalue)
        {
            string wheresql = " where " + fieldname + " = '" + fieldvalue + "'";
            string codename = GetSingleString(wheresql, tablename, resultfield);
            return codename;
        }

        /// <summary>
        /// �趨ҳ�����пؼ�ΪReadOnlyģʽ
        /// </summary>
        public static void SetToReadOnly()
        {
            Page controls = HttpContext.Current.Handler as Page;
            foreach (Control ctr in controls.Controls[1].Controls)
            {
                HtmlControl htmlcontrol = ctr as HtmlControl;
                WebControl webcontrol = ctr as WebControl;
                if (htmlcontrol != null)
                {
                    htmlcontrol.Attributes.Add("readonly", "readonly");
                    htmlcontrol.Attributes["class"] = htmlcontrol.Attributes["class"] + " readonly";
                    HtmlSelect htmlselect = htmlcontrol as HtmlSelect;
                    if (htmlselect != null)
                    {
                        if (htmlselect.SelectedIndex == 0)
                        {
                            htmlselect.Items[0].Text = "N/A";
                            htmlselect.Items[0].Selected = true;
                        }
                        htmlselect.Disabled = true;
                        //controls.Controls.Add(new HtmlInputText(htmlselect.Items[htmlselect.SelectedIndex].Text));
                        //ctr.Controls.Add(new HtmlInputText(htmlselect.Items[htmlselect.SelectedIndex].Text));
                        continue;
                    }
                }
                if (webcontrol != null)
                {
                    webcontrol.Attributes.Add("disabled", "true");
                    webcontrol.Attributes["class"] = webcontrol.Attributes["class"] + " readonly";
                    Button webbouuton = webcontrol as Button;
                    if (webbouuton != null)
                    {
                        webbouuton.Visible = false;
                    }
                }
            }
        }


        /// <summary>
        /// ������code�����˵�
        /// </summary>
        /// <param name="codetype"></param>
        /// <param name="st"></param>
        public static void BinList(string codetype, Control st, string defaultword)
        {
            HtmlSelect htmlst = st as HtmlSelect;
            DropDownList ddlst = st as DropDownList;
            if (htmlst != null)
            {
                htmlst.Items.Clear();
                if (!string.IsNullOrEmpty(defaultword))
                {
                    string getword = "��ѡ��" + defaultword;
                    htmlst.Items.Add(new ListItem(getword, ""));
                }
                string wheresql = " typecode = '" + codetype + "'";
                InitListControlHelper.BindNormalTableToListControl(htmlst, "code", "name", "pm_codes", "showorder", wheresql, "");
            }
            if (ddlst != null)
            {
                ddlst.Items.Clear();
                if (!string.IsNullOrEmpty(defaultword))
                {
                    string getword = "��ѡ��" + defaultword;
                    ddlst.Items.Add(new ListItem(getword, ""));
                }
                string wheresql = " typecode = '" + codetype + "'";
                InitListControlHelper.BindNormalTableToListControl(ddlst, "code", "name", "pm_codes", "showorder", wheresql, "");
            }
        }

        /// <summary>
        /// �������ѡ��
        /// </summary>
        /// <param name="controlname"></param>
        /// <param name="defaultword"></param>
        public static void InitList(string controlname, string defaultword)
        {
            Page page = HttpContext.Current.Handler as Page;
            HtmlSelect hs = (page.FindControl(controlname)) as HtmlSelect;
            DropDownList ddl = (page.FindControl(controlname)) as DropDownList;
            string getword = "��ѡ��" + defaultword;
            if (hs != null)
            {
                hs.Items.Clear();
                hs.Items.Add(new ListItem(getword, ""));
            }
            if (ddl != null)
            {
                ddl.Items.Clear();
                ddl.Items.Add(new ListItem(getword, ""));
            }
        }

        /// <summary>
        /// ��ʼ�������˵�
        /// </summary>
        /// <param name="st"></param>
        /// <param name="defaultvalue"></param>
        public static void InitList(DropDownList st, string defaultvalue)
        {
            if (st.SelectedIndex != -1)
            {
                st.Items[st.SelectedIndex].Selected = false;
            }
            for (int i = 0; i < st.Items.Count; i++)
            {
                if (st.Items[i].Value == defaultvalue)
                    st.Items[i].Selected = true;
            }
        }

        /// <summary>
        /// ��ȡ�����ַ���
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public static string GetSingleString(string wheresql, string tablename, string fieldname)
        {
            DataTable DT = GetDataTable(wheresql, tablename, fieldname);
            string SingleString = "";
            if (DT.Rows.Count != 0)
            {
                SingleString = DT.Rows[0][0].ToString();
            }
            return SingleString;
        }

        public static DataTable GetDataTable(string wheresql, string tablename, string fieldname)
        {
            string sql = ZsdDotNetLibrary.Data.DataMakeSqlHelper.GetQuerySql(tablename, wheresql, fieldname);
            return DataExecSqlHelper.ExecuteQuerySql(sql);
        }

        /// <summary>
        /// ͨ��Ա����Ų�ѯԱ������
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public static string GetName(string employeeid)
        {
            string wheresql = " where code = '" + employeeid + "'";
            string name = GetSingleString(wheresql, "pm_employee", "pname");
            return name;
        }

        /// <summary>
        /// ��ȡԱ����Ϣ
        /// </summary>
        /// <param name="employeeid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetEmployeeInfo(string employeeid, string code)
        {
            string wheresql = " where code = '" + employeeid + "'";
            string employeeinfo = GetSingleString(wheresql, "pm_employee", code);
            return employeeinfo;
        }

        /// <summary>
        /// ��ȡԱ��codes��Ϣ
        /// </summary>
        /// <param name="employeeid"></param>
        /// <param name="code"></param>
        /// <param name="codetype"></param>
        /// <returns></returns>
        public static string GetEmployeeInfo(string employeeid, string code, string codetype)
        {
            string infocode = GetEmployeeInfo(employeeid, code);
            string infoname = fromCodeToName(infocode, codetype);
            return infoname;
        }

        /// <summary>
        /// ��ȡ����code��Ӧname
        /// </summary>
        /// <param name="code"></param>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public static string fromCodeToName(string code, string typecode, string tablename)
        {
            string codename = "";
            if (code != null && code != "")
            {
                string wheresql = " where code = '" + code + "' and typecode = '" + typecode + "'";
                codename = GetSingleString(wheresql, tablename, "name");
                return codename;
            }
            else
            {
                return codename;
            }
        }

        public static string fromCodeToName(string code, string typecode)
        {
            string tablename = "pm_codes";
            string codename = fromCodeToName(code, typecode, tablename);
            return codename;
        }

        /// <summary>
        /// ת��ʱ��
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string fromYearToDate(string year)
        {
            string str = null;
            double fYear;
            if (!double.TryParse(year, out fYear)) return str;
            DateTime dt = DateTime.Today;
            dt = dt.AddDays(-fYear * 365);
            str = dt.ToString("yyyy-MM-dd");
            return str;
        }

        /// <summary>
        /// ��������Ƿ����
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
        /// ���ص�ǰ�û��Ĵ�������
        /// </summary>
        /// <returns></returns>
        public static string GetAgentArea()
        {
            return PmDAL.GetAgentArea();
        }
        /// <summary>
        /// ���ص�ǰ�û��������ֵ�
        /// </summary>
        /// <returns></returns>
        public static string GetManagerSite()
        {
            return PmDAL.GetManagerSite();
        }
                
        /// <summary>
        /// ���ص�ǰ�û������ڵ�����
        /// </summary>
        /// <returns></returns>
        public static string GetManagerGroupID( string id)
        {
            return PmDAL.GetManagerGroupID(id );
        }
        #region �Զ����ɱ�����

        public static string AutoID(string spstr)
        {
            if (spstr.Trim().Length > 3)
                spstr = spstr.Trim().Remove(3);
            else
                spstr = spstr.Trim();
            return ObjectInfoHelper.GetID(spstr);
        }

        /// <summary>
        /// ��λ�춯���
        /// </summary>
        /// <returns></returns>
        public static string MoveId()
        {
            return AutoID("MOV");
        }

        /// <summary>
        /// ������Ϣ���
        /// </summary>
        /// <returns></returns>
        public static string PunishmentId()
        {
            return AutoID("PUN");
        }

        /// <summary>
        /// ��Ϊ�淶���˱��
        /// </summary>
        /// <returns></returns>
        public static string ChectkId()
        {
            return AutoID("CHK");
        }

        /// <summary>
        /// ��ѵ�������
        /// </summary>
        /// <returns></returns>
        public static string TrainId()
        {
            return AutoID("TRA");
        }

        /// <summary>
        /// �����ʸ���֤���
        /// </summary>
        /// <returns></returns>
        public static string EnableId()
        {
            return AutoID("ENA");
        }

        /// <summary>
        /// ���ܵȼ����
        /// </summary>
        /// <returns></returns>
        public static string SkillId()
        {
            return AutoID("SKI");
        }

        #endregion


        /// <summary>--------------2011-10-24---------------
        /// ���ص�ǰ�û��������ֵ�
        /// </summary>
        /// <returns></returns>
        public static string GetAreacodeByAgentID(string agentID)
        {
            return PmDAL.GetAreacodeByAgentID(agentID);
        }
        /// <summary>
        /// ���ص�ǰ�û��������ֵ���
        /// </summary>
        /// <returns></returns>
        public static string GetSiteByAgentID(string agentID)
        {
            return PmDAL.GetSiteByAgentID(agentID);
        }
        /// <summary>--------------2011-10-24---------------
        /// 
        public static pm_employee GetObject(pm_employee o)
        {
            return ObjectData.GetObject(o, "pm_employee") as pm_employee;
        }
    }
}
