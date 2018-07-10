using MyChart.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
             ChartData my = new ChartData();
             my.Labels = new List<string>(){"January", "February", "March", "April", "May", "June", "July", "Aguest", "September"};

            List<DataDetail> dataList = new List<DataDetail>();
            DataDetail data1 = new DataDetail();
            data1.Label = "My First dataset";
            data1.Values = new List<decimal>() {10,12,9,6,13,5,10,7,13};
            dataList.Add(data1);
            DataDetail data2 = new DataDetail();
            data2.Label = "My Second dataset";
            data2.Values = new List<decimal>() { 7,8,9,11,10,12,13,14,12};
            dataList.Add(data2);

            my.datas = dataList;
             //my.dataBase = ;
             return new JsonResult() { Data = my };
        }
        
        public ActionResult DoctorPie()
        {
            return View();
        }

    }
}
