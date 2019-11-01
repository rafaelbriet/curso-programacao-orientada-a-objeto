using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ExercicioProposto
{
	class Program
	{
		static void Main(string[] args)
		{
			string source = @"D:\Cursos\Curso Programação Orientada a Objeto\Secao16\Data\Employees.csv";

			List<Employee> employees = EmployeeServices.GetAllEmployees(source);

			ConsoleKey input;

			do
			{
				Console.WriteLine("[A] Show all [E] Search for salary [D] Search for departament [ESC] To exit");
				input = Console.ReadKey().Key;

				if ((input == ConsoleKey.A))
				{
					Pagination(employees.OrderBy(e => e.Name).ToList());
				}
				else if (input == ConsoleKey.E)
				{
					Console.Clear();

					Console.Write("Employees with salary higer than: ");
					double salaryQuery = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

					Pagination(employees.Where(e => e.Salary >= salaryQuery).OrderBy(e => e.Salary).ToList());

					Console.WriteLine();
				}
				else if (input == ConsoleKey.D)
				{
					Console.Clear();

					Console.Write("Department average salary: ");
					string departmentQuery = Console.ReadLine();

					var averageSalary = employees.Where(e => e.Department.ToLower() == departmentQuery.ToLower()).Select(e => e.Salary).DefaultIfEmpty(0.0).Average();

					Console.WriteLine($"The average salary of the {departmentQuery} department is {averageSalary}");

					Console.WriteLine();
				}
			} while (input != ConsoleKey.Escape);
		}

		private static void Pagination(List<Employee> employees)
		{
			Console.Clear();

			ConsoleKey input;

			int skip = 0;
			int take = 10;

			do
			{
				Console.Clear();

				var page = employees.Skip(skip).Take(take);

				foreach (var e in page)
				{
					Console.WriteLine(e);
				}

				Console.WriteLine();
				Console.WriteLine($"Page: {skip / 10 + 1}");

				Console.WriteLine();
				Console.WriteLine("[N] Next [P] Previous [G] Go to page [B] To go back");
				input = Console.ReadKey().Key;

				if (input == ConsoleKey.N)
				{
					if (skip < employees.Count)
					{
						skip += 10;
					}
					else
					{
						skip = 0;
					}

				}
				else if (input == ConsoleKey.P)
				{
					if (skip > 0)
					{
						skip -= 10;
					}
					else
					{
						skip = employees.Count - 10;
					}
				}
				else if (input == ConsoleKey.G)
				{
					int goToPage;

					do
					{
						Console.WriteLine();
						Console.Write("Go to page: ");
						goToPage = int.Parse(Console.ReadLine());

						skip = 10 * goToPage - 10;

					} while (goToPage < 0 || goToPage > employees.Count);
				}
			} while (input != ConsoleKey.B);

			Console.Clear();
		}
	}
}
