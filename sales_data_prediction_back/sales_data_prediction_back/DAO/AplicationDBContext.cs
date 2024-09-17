using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using sales_data_prediction_back.Models;
using System.Data;

namespace sales_data_prediction_back.DAO
{
    public class AplicationDBContext
    {
        public readonly string connectionString;

        public AplicationDBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

		public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					if (parameters != null)
					{
						command.Parameters.AddRange(parameters);
					}

					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						DataTable resultTable = new DataTable();
						adapter.Fill(resultTable);
						return resultTable;
					}
				}
			}
		}

		public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					if (parameters != null)
					{
						command.Parameters.AddRange(parameters);
					}

					connection.Open();
					return command.ExecuteNonQuery();
				}
			}
		}
	}
}
