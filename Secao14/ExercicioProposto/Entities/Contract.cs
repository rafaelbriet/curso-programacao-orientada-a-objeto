using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExercicioProposto.Entities
{
	class Contract
	{
		public int Number { get; set; }
		public DateTime Date { get; set; }
		public double TotalValue { get; set; }

		public List<Installment> Installments { get; set; }

		public Contract(int number, DateTime date, double totalValue)
		{
			Number = number;
			Date = date;
			TotalValue = totalValue;

			Installments = new List<Installment>();
		}

		public override string ToString()
		{
			return $"{Number}, {Date.ToString("dd/MM/yyyy")}, {TotalValue.ToString("F2", CultureInfo.InvariantCulture)}";
		}
	}
}
