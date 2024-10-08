﻿using System;
using System.Collections.Generic;

namespace sales_data_prediction_back.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Custid { get; set; }
        public string Companyname { get; set; }
        public string Contactname { get; set; }
        public string Contacttitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }

    public class getCustomerOrder
    {
        public int OrderId { set; get; }
        public DateTime Requireddate { set; get; }
        public DateTime Shippeddate { set; get; }
        public string ShipName { get; set; }
        public string Shipaddress { set; get; }
        public string Shipcity { set; get; }
    }
}
