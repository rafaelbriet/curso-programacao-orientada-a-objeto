using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;
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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Seller seller)
		{
			sellerService.Insert(seller);
			return RedirectToAction(nameof(Index));
		}
    }
}