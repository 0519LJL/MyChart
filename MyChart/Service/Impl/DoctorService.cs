using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using D3Download;
using MyChart.Models;

namespace MyChart.Service.Impl
{
    public class DoctorService  : IDoctorService
    {

        override
        public ChartData getUsers()
        {
            string sql = "select * from Person";
            DataTable users = DataBaseHelper.ExecuterQuery(sql);
            return getDoctorChartData(users);
        }

        private ChartData getDoctorChartData(DataTable dataList)
        {
            List<Person> ls = ObjectHelper.DataTableToList<Person>(dataList); //存放你一整列所有的值 
            List<string> nameList = ls.Select(l => l.Name).ToList();

            ChartData my = new ChartData();
            my.Labels = nameList;

            List<DataDetail> dataDetailList = new List<DataDetail>();
            DataDetail data1 = new DataDetail();
            data1.Label = "My First dataset";
            data1.Values = new List<decimal>() { 10, 12, 9, 6, 13, 5, 10 };
            dataDetailList.Add(data1);
            DataDetail data2 = new DataDetail();
            data2.Label = "My Second dataset";
            data2.Values = new List<decimal>() { 7, 8, 9, 11, 10, 12, 13 };
            dataDetailList.Add(data2);

            my.datas = dataDetailList;
            return my;
        }
    }
}