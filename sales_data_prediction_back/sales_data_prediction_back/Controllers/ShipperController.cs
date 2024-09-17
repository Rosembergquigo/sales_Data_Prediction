using Microsoft.AspNetCore.Mvc;
using sales_data_prediction_back.Models;
using sales_data_prediction_back.Services;
using System.Collections.Generic;

namespace sales_data_prediction_back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ShipperController : Controller
	{
		private readonly ShipperService shipperService;

		public ShipperController(ShipperService shipperService)
		{
			this.shipperService = shipperService;
		}

		[HttpGet]
		public ActionResult getShippers() 
		{
			List<Shippers> result = shipperService.GetShippers();

			if (result != null && result.Count > 0)
				return Ok(result);
			else return NotFound();
		}
	}
}
