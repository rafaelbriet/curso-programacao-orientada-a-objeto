using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
	public class DepartmentService
	{
		public readonly SalesWebAppContext context;

		public DepartmentService(SalesWebAppContext context)
		{
			this.context = context;
		}

		public List<Department> FindAll()
		{
			return context.Department.OrderBy(d => d.Name).ToList();
		}
	}
}
