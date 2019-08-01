namespace ExercicioProposto02.Entities
{
	class IndividualTaxpayer : Taxpayer
	{
		public double HealthExpenses { get; set; }

		public IndividualTaxpayer(string name, double annualIncome, double healthExpenses) : base(name, annualIncome)
		{
			HealthExpenses = healthExpenses;
		}

		public override double TaxToPay()
		{
			if (AnnualIncome <= 20000.0)
			{
				return AnnualIncome * 0.15 - HealthExpenses * 0.5;
			}
			else
			{
				return AnnualIncome * 0.25 - HealthExpenses * 0.5;
			}
		}
	}
}
