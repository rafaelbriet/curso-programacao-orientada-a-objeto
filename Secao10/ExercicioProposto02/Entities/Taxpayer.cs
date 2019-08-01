using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioProposto02.Entities
{
	abstract class Taxpayer
	{
		public string Name { get; set; }
		public double AnnualIncome { get; set; }

		public Taxpayer(string name, double annualIncome)
		{
			Name = name;
			AnnualIncome = annualIncome;
		}

		public abstract double TaxToPay();
	}
}
