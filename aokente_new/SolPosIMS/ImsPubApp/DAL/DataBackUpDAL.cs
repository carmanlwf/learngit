using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using System.IO;

namespace Ims.Pub.DAL
{
    public class DataBackUpDAL
    {
        /// <summary>
        ///数据库备份查询
        /// </summary>
        /// <param name="OperID"></param>
        /// <param name="Sdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
        public static DataTable CouputerSaleDataByOperID(string name, string Sdate, string Edate)
        {
            DataTable ta1 = GetDataSorc(name, Sdate, Edate);//原传过来数据
            string whereStr = "";
            //--------------------------重新排序所得到的数据
            if (name != ""&&Sdate!="")
            {
                whereStr = "name='" + name + "' and date<='" + Edate + "' and date>='" + Sdate + "'";
            }
            else if (name != "" && Sdate == "")
            { whereStr = "name='" + name + "' and date<='" + Edate + "'"; }
            else if (name == "" && Sdate == "")
            { whereStr = "date<='" + Edate + "'"; }
            else
            { whereStr = "date>='" + Sdate + "' and date<='" + Edate + "'";}
            DataRow[] rows = ta1.Select(whereStr, "date desc");
            DataTable ta2 = ta1.Clone();
            ta2.Clear();
            foreach (DataRow row in rows)
            {
                ta2.ImportRow(row);
            }
            return ta2;
        }
        //获取文件列表数据
        public static DataTable GetDataSorc(string name, string begin, string enddate)
        {
            DataTable c = new DataTable();//创建临时表
            c.Columns.Add(new DataColumn("name", typeof(string)));
            c.Columns.Add(new DataColumn("size", typeof(string)));
            c.Columns.Add(new DataColumn("pathfile", typeof(string)));
            c.Columns.Add(new DataColumn("date", typeof(string)));
            System.Web.UI.Page pp = new System.Web.UI.Page();
            string pathtxt = pp.Server.MapPath("../Log/");
            string pathtxtandname = pathtxt + "ListData.txt";
            string txtcont = ReadTextFileDate(pathtxtandname);//读取文件

            if (txtcont == "")
            {
                c = null;
            }
            else
            {
                string txtcontremortlast = txtcont.Substring(0, txtcont.Length - 1);
                string[] sArray = txtcontremortlast.Split(';');//第一次分割
                foreach (string i in sArray)
                {
                    string[] sArray2 = i.ToString().Split(',');//第二次分割
                    DataRow dr = c.NewRow();
                    dr["name"] = sArray2[0].ToString();
                    dr["size"] = sArray2[1].ToString();
                    dr["pathfile"] = sArray2[2].ToString();
                    dr["date"] = sArray2[3].ToString();
                    c.Rows.Add(dr);
                }
            }
            return c;

        }
        #region 读取txt  修改txt
        /// <summary>
        /// 读取文件txt文件
        /// FileName 文件夹所在位置与文件夹名称
        /// </summary>
        /// <returns></returns>
        public static string ReadTextFileDate(string FileName)
        {
            string strInput = "";
            string GetStream = "";

            if (File.Exists(FileName))
            {
                StreamReader sr = new StreamReader(FileName, UnicodeEncoding.GetEncoding("gb2312"));
                strInput = sr.ReadLine();
                while (strInput != null)
                {
                    GetStream += strInput;
                    strInput = sr.ReadLine();
                }
                sr.Close();
            }
            else
            {
                GetStream = "";
            }
            return GetStream;
        }


        /// <summary>
        /// 修改txt中的内容
        /// FileName 文件夹所在位置与文件夹名称
        /// StrCount 更新内容
        /// </summary>
        public static string UpdateTextFile(string FileName, string StrCount)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(FileName);
            string s = sr.ReadToEnd();
            sr.Close();
            s = s.Replace(s, StrCount);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(FileName, false);
            sw.Write(s);
            sw.Close();
            return "ok";
        }
        #endregion
    }
}
