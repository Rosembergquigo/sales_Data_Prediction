using sales_data_prediction_back.DAO;
using sales_data_prediction_back.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sales_data_prediction_back.Services
{
	public class ProductService
	{
		private readonly AplicationDBContext context;

		public ProductService(AplicationDBContext context)
		{
			this.context = context;
		}

		public List<Products> GetProducts()
		{
			List<Products> response = new List<Products>();

			DBController db = new DBController(context);
			DataTable dt = new DataTable();
			dt = db.getProducts();

			if (dt != null && dt.Rows.Count > 0)
				foreach (DataRow dr in dt.Rows)
					response.Add(new Products()
					{
						Productid = Convert.ToInt32(dr["productid"]),
						Productname = dr["productname"].ToString(),
						Unitprice = Convert.ToDecimal(dr["unitprice"])
					});

			return response;
		}
	}
}
