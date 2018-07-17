using System.Web;
using System.Web.Mvc;
using MyChart.Filters;

namespace MyChart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new CheckLoginAttribute());
        }
    }
}