using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyChart.Models;

namespace MyChart.Service
{
    public abstract class IUserService
    {
        public abstract User CheckExist(string name, string pwd);
    }
}