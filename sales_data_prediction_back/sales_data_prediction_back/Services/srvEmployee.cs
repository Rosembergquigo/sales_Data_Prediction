using sales_data_prediction_back.DAO;
using sales_data_prediction_back.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sales_data_prediction_back.Services
{
	public class srvEmployee
	{
		private readonly AplicationDBContext context;

		public srvEmployee(AplicationDBContext context)
		{
			this.context = context;
		}

		public List<getEmployees> getEmployees()
		{
			List<getEmployees> response = new List<getEmployees>();
			DBController db = new DBController(context);
			DataTable dt = new DataTable();
			dt = db.GetEmployees();

			if (dt != null && dt.Rows.Count > 0)
				foreach (DataRow dr in dt.Rows)
					response.Add(new getEmployees()
					{
						Empid = Convert.ToInt32(dr["empid"]),
						FullName = dr["fullname"].ToString()
					});
			

			return response;
		}
	}
}
