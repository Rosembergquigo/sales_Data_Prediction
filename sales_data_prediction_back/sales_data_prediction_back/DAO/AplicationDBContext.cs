using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using sales_data_prediction_back.Models;
using System;
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

		public bool createOrderTSQL(createOrder order)
		{
			using (SqlConnection connection = new SqlConnection(this.connectionString)) 
			{
				connection.Open();
				SqlTransaction transaction = connection.BeginTransaction();

				try
				{
					//1. Inserción en tabla SALES.ORDERS obteniendo el Order ID
					string insertOrder = @"INSERT INTO [Sales].[Orders] (custid,empid,orderdate,requireddate,shippeddate,shipperid,freight,shipname,shipaddress,shipcity,shipregion,shippostalcode,shipcountry)
							VALUES(@custid, @empid, @orderdate, @requireddate, @shippeddate, @shipperid, @freight, @shipname, @shipaddress, @shipcity, @shipregion, @shippostalcode, @shipcountry)";
					
					SqlCommand sqlCommand = new SqlCommand(insertOrder, connection, transaction);

					sqlCommand.Parameters.AddWithValue("@custid", order.Customer.id);
					sqlCommand.Parameters.AddWithValue("@empid", order.Employee.Empid);
					sqlCommand.Parameters.AddWithValue("@orderdate", order.OrderDate);
					sqlCommand.Parameters.AddWithValue("@requireddate", order.RequireDate);
					sqlCommand.Parameters.AddWithValue("@shippeddate", order.ShippedDate);
					sqlCommand.Parameters.AddWithValue("@shipperid", order.Shipper.Shipperid);
					sqlCommand.Parameters.AddWithValue("@freight", order.Freight);
					sqlCommand.Parameters.AddWithValue("@shipname", order.Customer.CustomerName);
					sqlCommand.Parameters.AddWithValue("@shipaddress", order.Customer.CustomerAddress);
					sqlCommand.Parameters.AddWithValue("@shipcity", order.Customer.CustomerCity);
					sqlCommand.Parameters.AddWithValue("@shipregion", order.Customer.CustomerRegion);
					sqlCommand.Parameters.AddWithValue("@shippostalcode", order.Customer.CustomerZipCode);
					sqlCommand.Parameters.AddWithValue("@shipcountry", order.Customer.CustomerCountry);

					int orderId = Convert.ToInt32(sqlCommand.ExecuteScalar());

					string insertOrdDetail = @"INSERT INTO [Sales].[OrderDetails] (orderid,productid,unitprice,qty,discount)
							VALUES (@orderid, @productid, @unitprice, @qty, @discount)";

					SqlCommand sqlCommandDet = new SqlCommand(insertOrdDetail,connection,transaction);
					sqlCommandDet.Parameters.AddWithValue("@orderid", orderId);
					sqlCommandDet.Parameters.AddWithValue("@productid", order.Product.Productid);
					sqlCommandDet.Parameters.AddWithValue("@unitprice", order.Product.Unitprice);
					sqlCommandDet.Parameters.AddWithValue("@qty", order.Qty);
					sqlCommandDet.Parameters.AddWithValue("@discount", order.Discount);

					transaction.Commit();

					return true;
				}
				catch (Exception ex)
				{
					return false;
					transaction.Rollback();
				}
			}
		}
	}
}
