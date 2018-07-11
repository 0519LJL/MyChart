using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyChart
{
    public static class ObjectHelper
    {
        /// <summary>
        /// 将Datatable转换为List集合
        /// </summary>
        /// <typeparam name="T">类型参数</typeparam>
        /// <param name="dt">datatable表</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dt)
        {
            var list = new List<T>();
            Type t = typeof(T);
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());

            foreach (DataRow item in dt.Rows)
            {
                T s = System.Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name.ToUpper() == dt.Columns[i].ColumnName.ToUpper());
                    if (info != null)
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            info.SetValue(s, item[i], null);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }
    }
}