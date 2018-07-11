using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MyChart.Models;

namespace MyChart.Service
{
    public  abstract class IDoctorService
    {
        public abstract ChartData getUsers();
    }
}