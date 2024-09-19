using Microsoft.Data.SqlClient;
using sales_data_prediction_back.Models;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;

namespace sales_data_prediction_back.DAO
{
	public class DBController
	{
		private readonly AplicationDBContext context;

		public DBController(AplicationDBContext context)
		{
			this.context = context;
		}

		public DataTable GetEmployees()
		{
			string query = "SELECT empid, CONCAT(firstname,' ',lastname) AS fullname FROM [HR].[Employees]";
			return context.ExecuteQuery(query);
		}

		public DataTable GetCustomerOrders(int id)
		{
			string query = "SELECT orderid,requireddate,shippeddate,shipname,shipaddress,shipcity FROM [Sales].[Orders] WHERE custid = @cusId";

			SqlParameter[] parameters =
			{
				new SqlParameter("@cusId", SqlDbType.Int) { Value = id },
			};

			return context.ExecuteQuery(query, parameters);
		}

		public DataTable getShippers() 
		{
			string query = "SELECT shipperid, companyname, phone FROM [Sales].[Shippers]";
			return context.ExecuteQuery(query);
		}

		public DataTable getProducts()
		{
			string query = "SELECT productid, productname, unitprice FROM [Production].[Products]";
			return context.ExecuteQuery(query);
		}

		public DataTable getSaleDatePrediction()
		{
			string query = @"with fechamaxima as(
				select a.custid,b.companyname, b.address, b.city, b.country, b.postalcode, b.region,max(orderdate) ultimaOrden
				from  [Sales].[Orders] a 
				inner join [Sales].[Customers] b
				on a.custid=b.custid
				group by a.custid,b.companyname, b.address, b.city, b.country, b.postalcode, b.region
				)
				,
				dias as(
				select 
				orderid, custid,companyname,orderdate,fecha2,
				DATEDIFF(day,orderdate,fecha2)num_dia
				from (select A.orderid, a.custid,b.companyname,orderdate,
					  lag(orderdate) OVER(PARTITION BY a.custid ORDER BY orderdate desc ) Fecha2
					  from  [Sales].[Orders] a 
					  left join [Sales].[Customers] b
					  on a.custid=b.custid
					  ) Fechas 
				where fecha2 is not null )
				,
				sumadia as(
				select custid,companyname, AVG(num_dia) prom
				from dias
				group by  custid,companyname)
				select a.custid, a.companyname as CustomerName, b.address,  b.city, b.country, b.postalcode, b.region,b.ultimaOrden LastOrderDate,dateAdd(day, prom ,b.ultimaOrden ) NextPredictedOrder
				from sumadia a
				inner join fechamaxima b
				on a.custid=b.custid";
			return context.ExecuteQuery(query);
		}

		public bool createOrder(createOrder request)
		{
			return context.createOrderTSQL(request);
		}

	}
}
