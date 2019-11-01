using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExercicioProposto
{
	class EmployeeServices
	{
		public static List<Employee> GetAllEmployees(string source)
		{
			List<Employee> employees = new List<Employee>();

			using (StreamReader stream = File.OpenText(source))
			{
				string line;

				while((line = stream.ReadLine()) != null)
				{
					string[] fields = line.Split(',');

					employees.Add(new Employee(fields[0], fields[1], double.Parse(fields[2], CultureInfo.InvariantCulture), fields[3]));
				}
			}

			return employees;
		}
	}
}
