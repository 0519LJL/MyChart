using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChart.Models
{
    public class ChartData
    {
        public List<string> Labels { get; set; }
        public List<DataDetail> datas { get; set; }
    }
}