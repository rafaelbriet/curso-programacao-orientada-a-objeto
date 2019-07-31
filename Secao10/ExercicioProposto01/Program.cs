using System;
using System.Collections.Generic;
using ExercicioProposto01.Entities;

namespace ExercicioProposto01
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Product> products = new List<Product>();

			Console.Write("Enter the number of products: ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 1; i <= n; i++)
			{
				Console.WriteLine("Product #" + i + " data:");

				Console.Write("Common, used or imported (c/u/i)? ");
				char type = char.Parse(Console.ReadLine());

				Console.Write("Name: ");
				string name = Console.ReadLine();

				Console.Write("Price: ");
				double price = double.Parse(Console.ReadLine());

				switch (type)
				{
					case 'c':
						products.Add(new Product(name, price));

						break;
					case 'u':
						Console.Write("Manufacture date (DD/MM/YYYY): ");
						DateTime date = DateTime.Parse(Console.ReadLine());

						products.Add(new UsedProduct(name, price, date));

						break;
					case 'i':
						Console.Write("Customs fee: ");
						double customsFee = double.Parse(Console.ReadLine());

						products.Add(new ImportedProduct(name, price, customsFee));

						break;
					default:
						break;
				}
			}

			Console.WriteLine();
			Console.WriteLine("PRICE TAGS:");
			foreach (Product p in products)
			{
				Console.WriteLine(p.PriceTag());
			}
		}
	}
}
