using System;
using System.Collections.Generic;

namespace sales_data_prediction_back.Models
{
    public partial class OrderValues
    {
        public int Orderid { get; set; }
        public int? Custid { get; set; }
        public int Empid { get; set; }
        public int Shipperid { get; set; }
        public DateTime Orderdate { get; set; }
        public decimal? Val { get; set; }
    }
}
