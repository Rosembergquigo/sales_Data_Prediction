﻿using System;
using System.Collections.Generic;

namespace sales_data_prediction_back.Models
{
    public partial class OrderDetails
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
