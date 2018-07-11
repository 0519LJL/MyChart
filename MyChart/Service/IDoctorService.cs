using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyChart.Service
{
    public  abstract class IDoctorService
    {
        public abstract DataTable getUsers();
    }
}