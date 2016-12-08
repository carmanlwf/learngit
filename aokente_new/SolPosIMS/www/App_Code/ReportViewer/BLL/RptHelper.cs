using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using System.Collections;

/// <summary>
///RptHelper 的摘要说明
/// </summary>
public class RptHelper
{
    public RptHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 将泛型集合类转换成DataTable
    /// </summary>
    /// <typeparam name="T">集合项类型</typeparam>
    /// <param name="list">集合</param>
    /// <param name="propertyName">需要返回的列的列名</param>
    /// <returns>数据集(表)</returns>
    public static DataTable ToDataTable<T>(IList<T> list, Type type )
    {
        string paramsArray ="";
                        System.Reflection.PropertyInfo[] properties = type.GetProperties();
                        foreach (System.Reflection.PropertyInfo property in properties)
                        {
                            paramsArray += property.Name.ToLower();
                            paramsArray += ",";
                        }
                        string[] propertyName = paramsArray.TrimEnd(new char[] { ',' }).Split(',');
        List<string> propertyNameList = new List<string>();
        if (propertyName != null) propertyNameList.AddRange(propertyName);


        DataTable result = new DataTable();
        if (list.Count > 0)
        {
            PropertyInfo[] propertys = list[0].GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                if (propertyNameList.Count == 0)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                else
                {
                    if (String.Join(" ", propertyNameList.ToArray()).Contains(pi.Name.ToLower())) 
                        result.Columns.Add(pi.Name.ToLower());
                }
            }


            for (int i = 0; i < list.Count; i++)
            {
                ArrayList tempList = new ArrayList();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name.ToLower()))
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                    }
                }
                object[] array = tempList.ToArray();
                result.LoadDataRow(array, true);
            }
        }
        return result;
    }
}
