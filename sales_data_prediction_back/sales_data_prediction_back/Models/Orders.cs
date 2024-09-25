using System;
using System.Collections.Generic;

namespace sales_data_prediction_back.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Orderid { get; set; }
        public int? Custid { get; set; }
        public int Empid { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public int Shipperid { get; set; }
        public decimal Freight { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public string Shipregion { get; set; }
        public string Shippostalcode { get; set; }
        public string Shipcountry { get; set; }

        public virtual Customers Cust { get; set; }
        public virtual Employees Emp { get; set; }
        public virtual Shippers Shipper { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public class getSalesPrediction
    {
        public int id { set; get; }
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerCity { set; get; }
        public string CustomerCountry { set; get; }
        public string CustomerZipCode { set; get; }
        public string CustomerRegion { set; get; }
        public DateTime LastOrderdate { get; set; }
        public DateTime NextPredictedOrder { get; set; }

    }

    public class createOrder
    {
        public getSalesPrediction customer { get; set; }
        public int idEmployee { get; set; }
        public int idProduct { set; get; }
        public int idShipper { set; get; }
        public DateTime OrderDate { set; get; }
        public DateTime RequireDate { set; get; }
        public DateTime ShippedDate { set; get; }
        public decimal Freight { set; get; }
        public decimal Unitprice { set; get; }
		public short Qty { get; set; }
		public decimal Discount { get; set; }
	}

    public class CreatedOrderResponseType
    {
        public string returnProccess { set; get; }
    }
}
