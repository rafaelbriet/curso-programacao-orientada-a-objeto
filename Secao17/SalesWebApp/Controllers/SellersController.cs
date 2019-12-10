using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;
using SalesWebApp.Models.ViewModels;
using SalesWebApp.Services;
using System.Collections.Generic;

namespace SalesWebApp.Controllers
{
    public class SellersController : Controller
    {
		private readonly SellerService sellerService;
		private readonly DepartmentService departmentService;

		public SellersController(SellerService sellerService, DepartmentService departmentService)
		{
			this.sellerService = sellerService;
			this.departmentService = departmentService;
		}

		public IActionResult Index()
        {
			var allSellers = sellerService.FindAll();

            return View(allSellers);
        }

		public IActionResult Create()
		{
			List<Department> departments = departmentService.FindAll();
			SellerFormViewModel viewModel = new SellerFormViewModel { Departments = departments };

			return View(viewModel);
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