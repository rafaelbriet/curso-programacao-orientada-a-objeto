using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
	public class SellerService
	{
		private readonly SalesWebAppContext context;
		
		public SellerService(SalesWebAppContext context)
		{
			this.context = context;
		}

		public List<Seller> FindAll()
		{
			return context.Seller.ToList();
		}

		public void Insert(Seller seller)
		{
			seller.Department = context.Department.First();
			context.Add(seller);
			context.SaveChanges();
		}
	}
}
