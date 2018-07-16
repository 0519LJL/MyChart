using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using D3Download;
using MyChart.Models;

namespace MyChart.Service.Impl
{
    public class DoctorService  : IDoctorService
    {

        override
        public ChartData getUsers(string keyValue)
        {
            string sql = @"select  yp.药品名称 as MedName,yp.规格 AS Spec,ys.医生 as DocName,sum(cast(jg.数量 as float)) as Number
,sum(cast(jg.数量 as float)) * cast(jg.单价 as float) as SumPrice,cast(jg.单价 as float) AS Price
 from mzgl gl
left join mzjg jg on cast(jg.关联号 as nvarchar) = cast(gl.关联号 as nvarchar)
left join mzyp yp on cast(yp.药品编码 as nvarchar) = cast(jg.药品编码 as nvarchar) and cast( yp.单价 as decimal(10,3)) =cast( jg.单价 as decimal(10,3))
left join mzys ys on cast(ys.医生编码 as nvarchar) = cast (gl.医生编码 as nvarchar)
left join mzks ks on cast(ks.科室编码 as nvarchar) = cast(gl.科室编码 as nvarchar)
where {0}
group by jg.药品编码,yp.药品名称,yp.规格,ys.医生,jg.单价";
            if (!string.IsNullOrEmpty(keyValue))
            {
                string search = string.Format(" (yp.药品名称 LIKE '{0}%' OR ys.医生 LIKE '{0}%')", keyValue);
                sql = string.Format(sql, search);
            }
            else
            {
                sql = string.Format(sql, "1=1"); 
            }
            DataTable users = DataBaseHelper.ExecuterQuery(sql);
            return getDoctorChartData(users);
        }

        private ChartData getDoctorChartData(DataTable dataList)
        {
            List<GroupData> ls = ObjectHelper.DataTableToList<GroupData>(dataList); //存放你一整列所有的值 
            List<string> medNameList = ls.Select(l => (l.MedName ?? "-1") ).Distinct().ToList();

            ChartData my = new ChartData();
            my.Labels = medNameList;


            var groupData = (from l in ls
                             group l by new {l.MedName,l.DocName}
                                 into d
                                 select new
                                 {
                                     MedName = d.Key.MedName,
                                     DocName = d.Key.DocName,
                                     SumPrice = d.Sum(o => o.SumPrice)
                                 }
                ).ToList();

            List<DataDetail> dataDetailList = new List<DataDetail>();
            List<string> docNameList = ls.Select(l => l.DocName).Distinct().ToList();
            foreach (string data in docNameList)
            {
                DataDetail detail = new DataDetail();
                detail.Label = data;
                detail.Values = groupData.Where(g => g.DocName.Equals(data)).Select(g => g.SumPrice).ToList();
                dataDetailList.Add(detail);
            }

            my.datas = dataDetailList;
            return my;
        }
    }
}