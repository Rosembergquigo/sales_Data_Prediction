using sales_data_prediction_back.DAO;
using sales_data_prediction_back.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sales_data_prediction_back.Services
{
	public class customerService
	{
		private readonly AplicationDBContext context;

		public customerService(AplicationDBContext context)
		{
			this.context = context;
		}

		public List<getCustomerOrder> getCustomerOrders(int id)
		{
			List<getCustomerOrder> response = new List<getCustomerOrder>();

			DBController db = new DBController(context);
			DataTable dt = new DataTable();
			dt = db.GetCustomerOrders(id);

			if(dt != null && dt.Rows.Count > 0)
				foreach (DataRow item in dt.Rows)
					response.Add(new getCustomerOrder()
					{
						OrderId = Convert.ToInt32(item["orderid"]),
						Requireddate = !string.IsNullOrEmpty(item["requireddate"].ToString()) ? Convert.ToDateTime(item["requireddate"]) : DateTime.Now,
						Shippeddate = !string.IsNullOrEmpty(item["shippeddate"].ToString()) ? Convert.ToDateTime(item["shippeddate"]) : DateTime.Now,
						ShipName = item["shipname"].ToString(),
						Shipcity = item["shippeddate"].ToString(),
						Shipaddress = item["shipaddress"].ToString()
					});
			
			return response;
		}
	}
}
