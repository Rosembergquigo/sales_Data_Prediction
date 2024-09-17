using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sales_data_prediction_back.DAO;
using sales_data_prediction_back.Models;
using sales_data_prediction_back.Services;
using System.Collections.Generic;
using System.Linq;

namespace sales_data_prediction_back.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class CustomerController : Controller
	{
		private readonly customerService customerService;

		public CustomerController(customerService service)
		{
			this.customerService = service;
		}

		[HttpGet("order/{id}")]
		public IActionResult getCustomerOrders(int id) 
		{ 
			List<getCustomerOrder> result = customerService.getCustomerOrders(id);

			if (result == null && result.Count == 0)
				return NotFound();
			else return Ok(result);
		}

		
	}
}
