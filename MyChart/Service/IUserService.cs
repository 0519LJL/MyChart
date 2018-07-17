using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChart.Service
{
    public abstract class IUserService
    {
        public abstract bool CheckExist(string name, string pwd);
    }
}