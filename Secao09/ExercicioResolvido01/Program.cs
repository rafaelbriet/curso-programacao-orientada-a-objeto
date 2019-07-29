using System;
using System.Globalization;
using ExercicioResolvido01.Entities;

namespace ExercicioResolvido01
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter department's name: ");
			string department = Console.ReadLine();
			Console.WriteLine("Enter worker data:");
			Console.Write("Name: ");
			string name = Console.ReadLine();
			Console.Write("Level (Junior / MidLevel / Senior): ");
			string level = Console.ReadLine();
			Console.Write("Base salary: ");
			double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			//Console.Write("How many contracts to this worker? ");
			//int n = int.Parse(Console.ReadLine());

			WorkerLevel wl = (WorkerLevel) Enum.Parse(typeof(WorkerLevel), level);
			Department dep = new Department(department);

			Worker worker = new Worker(name, wl, salary, dep);

			//for (int i = 0; i < n; i++)
			//{
			//	Console.WriteLine("Enter #{0} contract data:", i + 1);
			//	Console.Write("Value per hour: ");
			//	double value = double.Parse(Console.ReadLine());
			//	Console.Write("Duration (hours): ");
			//	int hours = int.Parse(Console.ReadLine());
			//}

			//Console.Write("Enter month and year to calculate income (MM/YYYY): ");
			//string search = Console.ReadLine();

			Console.WriteLine(worker);
		}
	}
}
