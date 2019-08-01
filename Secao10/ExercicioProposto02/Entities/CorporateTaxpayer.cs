namespace ExercicioProposto02.Entities
{
	class CorporateTaxpayer : Taxpayer
	{
		public int EmployeeNumber { get; set; }

		public CorporateTaxpayer(string name, double annualIncome, int employeeNumber) : base(name, annualIncome)
		{
			EmployeeNumber = employeeNumber;
		}

		public override double TaxToPay()
		{
			if (EmployeeNumber <= 10)
			{
				return AnnualIncome * 0.16;
			} 
			else
			{
				return AnnualIncome * 0.14;
			}
		}
	}
}
