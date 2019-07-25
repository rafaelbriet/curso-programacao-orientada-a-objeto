using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioClass02
{
	class Program
	{
		// DESCRIÇÃO: Fazer um programa para ler nome e salário de dois funcionários. Depois, mostrar o salário médio dos funcionários
		static void Main(string[] args)
		{
			Funcionario funcionario1 = new Funcionario();
			Funcionario funcionario2 = new Funcionario();

			Console.WriteLine("Dados do primeiro funcinário");
			Console.Write("Nome: ");
			funcionario1.nome = Console.ReadLine();
			Console.Write("Salário: ");
			funcionario1.salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			Console.WriteLine("Dados do segundo funcinário");
			Console.Write("Nome: ");
			funcionario2.nome = Console.ReadLine();
			Console.Write("Salário: ");
			funcionario2.salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			double mediaSalarial = (funcionario1.salario + funcionario2.salario) / 2;

			Console.WriteLine($"Salário médio: {mediaSalarial:F2}");
		}
	}
}
