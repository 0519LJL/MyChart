using System;
using System.Collections.Generic;
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
             MyClass my = new MyClass();
             my.name = "张三";
             return new JsonResult() { Data = my };
        }
        private class MyClass
        {
            public string name { get; set; }
        }
        
        public ActionResult DoctorPie()
        {
            return View();
        }

    }
}
