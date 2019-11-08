using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Services;

namespace SalesWebApp.Controllers
{
    public class SellersController : Controller
    {
		private readonly SellerService sellerService;

		public SellersController(SellerService sellerService)
		{
			this.sellerService = sellerService;
		}

		public IActionResult Index()
        {
			var allSellers = sellerService.FindAll();

            return View(allSellers);
        }
    }
}