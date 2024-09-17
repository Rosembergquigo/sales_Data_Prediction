using Microsoft.AspNetCore.Mvc;
using sales_data_prediction_back.Models;
using sales_data_prediction_back.Services;
using System.Collections.Generic;
using System.Data;

namespace sales_data_prediction_back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : Controller
	{
		private readonly srvEmployee employeeService;

		public EmployeeController(srvEmployee employeeService)
		{
			this.employeeService = employeeService;
		}

		[HttpGet]
		public IActionResult getEmployees()
		{
			List<getEmployees> result = employeeService.getEmployees();

			if (result == null && result.Count == 0)
				return NotFound();
			else
				return Ok(result);
			
		}
	}
}
