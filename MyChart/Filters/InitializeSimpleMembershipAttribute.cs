using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using MyChart.Models;
using System.Web.Mvc;

namespace MyChart.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 确保每次启动应用程序时只初始化一次 ASP.NET Simple Membership
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // 创建不包含 Entity Framework 迁移架构的 SimpleMembership 数据库
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("无法初始化 ASP.NET Simple Membership 数据库。有关详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }


    public sealed partial class CheckLoginAttribute : ActionFilterAttribute
    {
        //重写ActionFilterAttribute中的OnActionExecuted方法，表示在执行Action之前执行此方法
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //判断Action方法的Control是否跳过登录验证
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipCheckLoginAttribute), false))
            {
                return;
            }
            //判断Action方法是否跳过登录验证
            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipCheckLoginAttribute), false))
            {
                return;
            }
            if (filterContext.HttpContext.Session["User"] == null)
            {
                //跳转方法1：
                filterContext.HttpContext.Response.Redirect("/Login/Login");
                //跳转方法2：
                ViewResult view = new ViewResult();
                //指定要返回的完整视图名称
                view.ViewName = "~/View/Login/Login.cshtml";
            }
        }
    }
}
