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
        
        public ActionResult DoctorPie()
        {
            return View();
        }

    }
}
