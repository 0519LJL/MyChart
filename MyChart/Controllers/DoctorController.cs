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
         public ActionResult sayHello(string keyValue)
        {
            IDoctorService service = new DoctorService();

            var result = service.getUsers(keyValue);
            return new JsonResult() { Data = result };
        }
        
        public ActionResult DoctorPie()
        {
            return View();
        }
        public ActionResult DoctorBar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDoctorBar(string keyValue)
        {
            IDoctorService service = new DoctorService();

            var result = service.getUsers(keyValue);
            return new JsonResult() { Data = result };
        }

    }
}
