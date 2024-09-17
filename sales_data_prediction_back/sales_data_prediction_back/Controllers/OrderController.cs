using Microsoft.AspNetCore.Mvc;
using sales_data_prediction_back.Models;
using sales_data_prediction_back.Services;
using System.Collections.Generic;

namespace sales_data_prediction_back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : Controller
	{
		private readonly OrderService orderService;

		public OrderController(OrderService orderService)
		{
			this.orderService = orderService;
		}

		[HttpGet]
		public IActionResult GetSaleDatePrediction()
		{
			List<getSalesPrediction> result = orderService.getSalesDatePrediction();

			if(result != null && result.Count > 0) 
				return Ok(result);	
			else return NotFound();

		}

		[HttpPost]
		public IActionResult CreateOrder(createOrder request)
		{
			CreatedOrderResponseType result = orderService.CreatedOrder(request);

			if(result.returnProccess.Equals("SUCCESS"))
				return Ok(result);
			else
				return BadRequest(result);
		}
	}
}
