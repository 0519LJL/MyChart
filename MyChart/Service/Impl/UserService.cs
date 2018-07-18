using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using D3Download;
using MyChart.Models;

namespace MyChart.Service.Impl
{
    public class UserService : IUserService
    {
        override
        public User CheckExist(string name, string pwd)
        {
            string sql = string.Format("SELECT * FROM dbo.[User] WHERE UserName ='{0}' AND PassWord ='{1}' AND IsUsed =1",name,pwd);
                    
            DataTable userTable =  DataBaseHelper.ExecuterQuery(sql);
            List<User> userList = new List<User>();
            if (userTable != null)
            {
                userList = ObjectHelper.DataTableToList<User>(userTable);
            }
            if (userList.Count > 0)
            {
                return userList.First();
            }

            return null;
        }
    }
}