using System;
using System.Collections.Generic;
using ExercicioProposto02.Entities;

namespace ExercicioProposto02
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Taxpayer> taxpayers = new List<Taxpayer>();

			Console.Write("Enter the number of taxpayers: ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 1; i <= n; i++)
			{
				Console.WriteLine("Taxpayer #{0} data:", i);

				Console.Write("Idividual or company (i/c): ");
				char q = char.Parse(Console.ReadLine());

				Console.Write("Name: ");
				string name = Console.ReadLine();

				Console.Write("Annual income: ");
				double income = double.Parse(Console.ReadLine());

				switch (q)
				{
					case 'i':
						Console.Write("Health expenses: ");
						double healthExpense = double.Parse(Console.ReadLine());

						taxpayers.Add(new IndividualTaxpayer(name, income, healthExpense));

						break;
					case 'c':
						Console.Write("Number of employees: ");
						int employees = int.Parse(Console.ReadLine());

						taxpayers.Add(new CorporateTaxpayer(name, income, employees));

						break;
					default:
						break;
				}
			}

			Console.WriteLine();
			Console.WriteLine("TAXE PAID:");

			double totalTaxes = 0.0;

			foreach (Taxpayer tp in taxpayers)
			{
				totalTaxes += tp.TaxToPay();

				Console.WriteLine("{0}: R$ {1:0.00}", tp.Name, tp.TaxToPay());
			}

			Console.WriteLine();
			Console.WriteLine("TOTAL TAXES: R$ {0:0.00}", totalTaxes);

			Console.ReadLine();
		}
	}
}
