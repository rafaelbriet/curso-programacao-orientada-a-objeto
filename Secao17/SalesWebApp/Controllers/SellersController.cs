using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;
using SalesWebApp.Models.ViewModels;
using SalesWebApp.Services;
using SalesWebApp.Services.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

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
				return RedirectToAction(nameof(Error), new { message = "Id cannot be null"});
			}

			Seller seller = sellerService.FindById(id.Value);

			if (seller == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not found" });
			}

			return View(seller);
		}

		public IActionResult Update(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id cannot be null" });
			}

			Seller seller = sellerService.FindById(id.Value);

			if (seller == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not found" });
			}

			List<Department> departments = departmentService.FindAll();
			SellerFormViewModel formView = new SellerFormViewModel { Seller = seller, Departments = departments };

			return View(formView);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id cannot be null" });
			}

			Seller seller = sellerService.FindById(id.Value);

			if (seller == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id not found" });
			}

			return View(seller);
		}

		public IActionResult Error(string message)
		{
			ErrorViewModel viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Seller seller)
		{
			if (ModelState.IsValid == false)
			{
				List<Department> departments = departmentService.FindAll();
				SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
				return View(viewModel);
			}

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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(int id, Seller seller)
		{
			if (ModelState.IsValid == false)
			{
				List<Department> departments = departmentService.FindAll();
				SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
				return View(viewModel);
			}
				
			if (id != seller.Id)
			{
				return RedirectToAction(nameof(Error), new { message = "Ids doesn't match" });
			}

			try
			{
				sellerService.Update(seller);
				return RedirectToAction(nameof(Index));
			}
			catch(NotFoundException error)
			{
				return RedirectToAction(nameof(Error), new { message = error.Message });
			}
			catch(DbConcurrencyException error)
			{
				return RedirectToAction(nameof(Error), new { message = error.Message });
			}
		}
	}
}