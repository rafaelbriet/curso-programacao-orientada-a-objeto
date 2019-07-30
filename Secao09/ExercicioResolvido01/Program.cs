using System;
using System.Globalization;
using ExercicioResolvido01.Entities;

namespace ExercicioResolvido01
{
	class Program
	{
		static void Main(string[] args)
		{
			// Worker
			Console.Write("Enter department's name: ");
			string department = Console.ReadLine();
			Console.WriteLine("Enter worker data:");
			Console.Write("Name: ");
			string name = Console.ReadLine();
			Console.Write("Level (Junior / Mid / Senior): ");
			string level = Console.ReadLine();
			Console.Write("Base salary: ");
			double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			WorkerLevel wl = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), level);
			Department dep = new Department(department);

			Worker worker = new Worker(name, (WorkerLevel)Enum.Parse(typeof(WorkerLevel), level), salary, new Department(department));

			// Contracts
			Console.Write("How many contracts to this worker? ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("Enter #{0} contract data:", i + 1);
				Console.Write("Date: ");
				DateTime contractDate = DateTime.Parse(Console.ReadLine());
				Console.Write("Value per hour: ");
				double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
				Console.Write("Duration (hours): ");
				int hours = int.Parse(Console.ReadLine());

				worker.AddContract(new HourContract(contractDate, value, hours));
			}

			// Total income
			Console.Write("Enter month and year to calculate income (MM/YYYY): ");
			string[] search = Console.ReadLine().Split('/');

			int searchMonth = int.Parse(search[0]);
			int searchYear = int.Parse(search[1]);

			Console.WriteLine("searchYear: {0}", searchYear);
			Console.WriteLine("searchMonth: {0}", searchMonth);

			Console.WriteLine("Name: {0}", worker.Name);
			Console.WriteLine("Department: {0}", worker.Department.Name);
			Console.WriteLine("Income for {0}/{1}: {2}", searchMonth, searchYear, worker.Income(searchYear, searchMonth).ToString("F2", CultureInfo.InvariantCulture));

			Console.ReadLine();
		}
	}
}
