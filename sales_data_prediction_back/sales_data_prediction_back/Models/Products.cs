﻿using System;
using System.Collections.Generic;

namespace sales_data_prediction_back.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Productid { get; set; }
        public string Productname { get; set; }
        public int Supplierid { get; set; }
        public int Categoryid { get; set; }
        public decimal Unitprice { get; set; }
        public bool Discontinued { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
