using System;
using System.Collections.Generic;

namespace sales_data_prediction_back.Models
{
    public partial class CustOrders
    {
        public int? Custid { get; set; }
        public DateTime? Ordermonth { get; set; }
        public int? Qty { get; set; }
    }
}
