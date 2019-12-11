using SalesWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

		public Seller FindById(int id)
		{
			return context.Seller.Include(seller => seller.Department).FirstOrDefault(seller => seller.Id == id);
		}

		public void Insert(Seller seller)
		{
			context.Add(seller);
			context.SaveChanges();
		}

		public void Remove(int id)
		{
			Seller seller = context.Seller.Find(id);
			context.Seller.Remove(seller);
			context.SaveChanges();
		}
	}
}
