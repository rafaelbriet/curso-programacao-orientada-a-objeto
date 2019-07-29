using System;
using System.Collections.Generic;

namespace ExercicioResolvido01.Entities
{
	class Worker
	{
		public string Name { get; set; }
		public WorkerLevel Level { get; set; }
		public double BaseSalary { get; set; }
		public Department Department { get; set; }

		private List<HourContract> contracts = new List<HourContract>();

		public Worker(string name, WorkerLevel level, double baseSalary, Department department)
		{
			Name = name;
			Level = level;
			BaseSalary = baseSalary;
			Department = department;
		}

		public void AddContract(HourContract contract)
		{
			contracts.Add(contract);
		}

		public void RemoveContract(HourContract contract)
		{
			int contractToRemove = contracts.FindIndex(x => x == contract);
			contracts.RemoveAt(contractToRemove);
		}

		public double Income(int year, int month)
		{
			return 0.0;
		}

		public override string ToString()
		{
			string message = $"Name: {Name}, Department: {Department.Name}, Income: $ {BaseSalary:0.00}";
			return message;
		}
	}
}
