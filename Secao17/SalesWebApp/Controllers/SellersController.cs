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

		public IActionResult Remove(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Seller seller = sellerService.FindById(id.Value);

			if (seller == null)
			{
				return NotFound();
			}

			return View(seller);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Seller seller = sellerService.FindById(id.Value);

			if (seller == null)
			{
				return NotFound();
			}

			return View(seller);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Seller seller)
		{
			sellerService.Insert(seller);
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Remove(int id)
		{
			sellerService.Remove(id);
			return RedirectToAction(nameof(Index));
		}
    }
}