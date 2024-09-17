using Microsoft.AspNetCore.Mvc;
using sales_data_prediction_back.Models;
using sales_data_prediction_back.Services;
using System.Collections.Generic;

namespace sales_data_prediction_back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : Controller
	{
		private readonly ProductService product;

		public ProductController(ProductService product)
		{
			this.product = product;
		}

		[HttpGet]
		public IActionResult getProducts() 
		{
			List<Products> result = product.GetProducts();

			if(result == null && result.Count == 0)
				return NotFound();
			else return Ok(result);
		}
	}
}
