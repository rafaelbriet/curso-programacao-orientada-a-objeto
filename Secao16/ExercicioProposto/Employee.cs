using System.Globalization;

namespace ExercicioProposto
{
	class Employee
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public double Salary { get; set; }
		public string Department { get; set; }

		public Employee(string name, string email, double salary, string department)
		{
			Name = name;
			Email = email;
			Salary = salary;
			Department = department;
		}

		public override string ToString()
		{
			return $"{Name}, {Email}, {Salary.ToString("f2", CultureInfo.InvariantCulture)}, {Department}";
		}
	}
}
