using System.Data;
using MyChart.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyChart.Service;
using MyChart.Service.Impl;
using System.Reflection;

namespace MyChart.Controllers
{
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/

        public ActionResult DoctorLine()
        {
            return View();
        }

        [HttpPost]
         public ActionResult sayHello()
        {
            IDoctorService service = new DoctorService();
            DataTable users = service.getUsers();

            List<Person> ls = DataTableToList<Person>(users); //存放你一整列所有的值 
            List<string> nameList = ls.Select(l => l.Name).ToList();

             ChartData my = new ChartData();
             //my.Labels = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "Aguest", "September" }; ;
             my.Labels = nameList ;

            List<DataDetail> dataList = new List<DataDetail>();
            DataDetail data1 = new DataDetail();
            data1.Label = "My First dataset";
            data1.Values = new List<decimal>() {10,12,9,6,13,5,10};
            dataList.Add(data1);
            DataDetail data2 = new DataDetail();
            data2.Label = "My Second dataset";
            data2.Values = new List<decimal>() { 7,8,9,11,10,12,13};
            dataList.Add(data2);

            my.datas = dataList;
             //my.dataBase = ;
             return new JsonResult() { Data = my };
        }

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
        
        public ActionResult DoctorPie()
        {
            return View();
        }

    }
}
