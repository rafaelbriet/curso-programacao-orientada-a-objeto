using System.Globalization;
using System.Collections.Generic;

namespace ExercicioResolvido01.Entities
{
	class Worker
	{
		public string Name { get; set; }
		public WorkerLevel Level { get; set; }
		public double BaseSalary { get; set; }
		public Department Department { get; set; }

		public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

		public Worker(string name, WorkerLevel level, double baseSalary, Department department)
		{
			Name = name;
			Level = level;
			BaseSalary = baseSalary;
			Department = department;
		}

		public void AddContract(HourContract contract)
		{
			Contracts.Add(contract);
		}

		public void RemoveContract(HourContract contract)
		{
			int contractToRemove = Contracts.FindIndex(x => x == contract);
			Contracts.RemoveAt(contractToRemove);
		}

		public double Income(int year, int month)
		{
			List<HourContract> search = Contracts.FindAll(x => x.Date.Year == year && x.Date.Month == month);

			double totalIncome = BaseSalary;

			foreach (HourContract s in search)
			{
				totalIncome += s.TotalValue();
			}

			return totalIncome;
		}
	}
}
