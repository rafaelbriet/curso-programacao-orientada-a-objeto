using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebApp.Models.ViewModels
{
	public class SellerFormViewModel
	{
		public Seller Seller { get; set; }
		public List<Department> Departments{ get; set; }
	}
}
