using MyChart.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyChart.Models;
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
            if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(passWord))
            {
                return new JsonResult() { Data = "请输入账号和密码" };
            }

            User currentUser = new UserService().CheckExist(name, passWord);

            if (currentUser != null)
            {
                Session["CurrentUser"] = currentUser;
            }

            return RedirectToAction("DoctorBar","Doctor");
        }

    }
}
