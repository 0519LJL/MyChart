using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChart.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string LoginIp { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int IsUsed { get; set; }
        public string CreateUserId { get; set; }
        public DateTime Created { get; set; }
    }
}