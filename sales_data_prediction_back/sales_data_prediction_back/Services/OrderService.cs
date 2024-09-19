using sales_data_prediction_back.DAO;
using sales_data_prediction_back.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sales_data_prediction_back.Services
{
	public class OrderService
	{
		private readonly AplicationDBContext context;

		public OrderService(AplicationDBContext context)
		{
			this.context = context;
		}

		public List<getSalesPrediction> getSalesDatePrediction()
		{
			List<getSalesPrediction> response = new List<getSalesPrediction>();

			DBController db = new DBController(context);
			DataTable dt = new DataTable();
			dt = db.getSaleDatePrediction();

			if (dt != null && dt.Rows.Count > 0)
				foreach (DataRow dr in dt.Rows)
					response.Add(new getSalesPrediction()
					{
						id = Convert.ToInt32(dr["custid"]),
						CustomerName = dr["CustomerName"].ToString(),
						CustomerAddress = dr["address"].ToString(),
						CustomerCity = dr["city"].ToString(),
						CustomerCountry = dr["country"].ToString(),
						CustomerZipCode = dr["postalcode"].ToString(),
						CustomerRegion= !string.IsNullOrEmpty(dr["region"].ToString()) ? dr["region"].ToString() : string.Empty,
						LastOrderdate = !string.IsNullOrEmpty(dr["LastOrderDate"].ToString()) ? Convert.ToDateTime(dr["LastOrderDate"]) : DateTime.Now,
						NextPredictedOrder = !string.IsNullOrEmpty(dr["NextPredictedOrder"].ToString()) ? Convert.ToDateTime(dr["NextPredictedOrder"]) : DateTime.Now,
					});

			return response;
		}

		public CreatedOrderResponseType CreatedOrder(createOrder request)	
		{ 
			CreatedOrderResponseType response = new CreatedOrderResponseType();
			DBController db = new DBController(context);

			response.returnProccess = db.createOrder(request) ? "OK" : "FAILED";

			return response; 
		}
	}
}
