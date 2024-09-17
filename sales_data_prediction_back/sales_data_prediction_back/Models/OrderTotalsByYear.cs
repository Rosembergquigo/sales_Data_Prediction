using System;
using System.Collections.Generic;

namespace sales_data_prediction_back.Models
{
    public partial class OrderTotalsByYear
    {
        public int? Orderyear { get; set; }
        public int? Qty { get; set; }
    }
}
