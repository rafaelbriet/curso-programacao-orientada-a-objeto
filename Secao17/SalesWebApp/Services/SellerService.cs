using SalesWebApp.Models;
using System.Collections.Generic;
using System.Linq;

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
			context.Add(seller);
			context.SaveChanges();
		}
	}
}
