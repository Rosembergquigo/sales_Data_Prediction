using sales_data_prediction_back.DAO;
using sales_data_prediction_back.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sales_data_prediction_back.Services
{
	public class ShipperService
	{
		private readonly AplicationDBContext context;

		public ShipperService(AplicationDBContext context)
		{
			this.context = context;
		}

		public List<Shippers> GetShippers()
		{
			List<Shippers> response = new List<Shippers>();
			DBController db = new DBController(context);
			DataTable dt = new DataTable();
			dt = db.getShippers();

			if (dt != null && dt.Rows.Count > 0)
				foreach (DataRow dr in dt.Rows)
					response.Add(new Shippers()
					{
						Shipperid = Convert.ToInt32(dr["shipperid"]),
						Companyname = dr["companyname"].ToString(),
						Phone = dr["phone"].ToString(),

					});

			return response;
		}

	}
}
