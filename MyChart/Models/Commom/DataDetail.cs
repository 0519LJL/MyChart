using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChart.Models
{
    public class DataDetail
    {
        public string Label { get; set; }

        public List<decimal> Values { get; set; }
    }
}