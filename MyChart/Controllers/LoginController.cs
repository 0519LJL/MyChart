using MyChart.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyChart.Service.Impl;

namespace MyChart.Controllers
{
    [SkipCheckLoginAttribute]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string passWord)
        {
            if(name=="Admin" && passWord == "123456")
            {
                Session["User"] = name;
            }

            bool dd = new UserService().CheckExist(name, passWord);

            return RedirectToAction("DoctorBar","Doctor");
        }

    }
}
