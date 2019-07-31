using System;
using System.Collections.Generic;
using ExercicioResolvido01.Entities;

namespace ExercicioResolvido01
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Employee> employees = new List<Employee>();
			string name;
			int hours;
			double valuePerHour;
			double additionalCharge;

			Console.Write("Enter the numbers of employees: ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("Employee #{0} data:", i + 1);

				Console.Write("Outsourced (y/n)? ");
				char q = char.Parse(Console.ReadLine());

				Console.Write("Name: ");
				name = Console.ReadLine();

				Console.Write("Hours: ");
				hours = int.Parse(Console.ReadLine());

				Console.Write("Value per hour: ");
				valuePerHour = double.Parse(Console.ReadLine());

				if (q == 'y' || q == 'Y')
				{
					Console.Write("Additional charge: ");
					additionalCharge = double.Parse(Console.ReadLine());

					employees.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge);
				}
				else if (q == 'n' || q == 'n')
				{
					employees.Add(new Employee(name, hours, valuePerHour));
				}
			}

			Console.WriteLine("");
			Console.WriteLine("PAYMENTS:");
			foreach (Employee e in employees)
			{
				Console.WriteLine("{0} - R$ {1}", e.Name, e.Payment().ToString("F2"));
			}
		}
	}
}
