using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExercicioLista
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Funcionario> funcionarios = new List<Funcionario>();

			int id;
			string nome;
			double salario;
			double porcentagem;

			Console.Write("Quantos funcionários serão adicionados? ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("Funcionário #{0}:", i + 1);

				Console.Write("ID: ");
				id = int.Parse(Console.ReadLine());

				Console.Write("Nome: ");
				nome = Console.ReadLine();

				Console.Write("Salario: ");
				salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

				funcionarios.Add(new Funcionario(id, nome, salario));

				Console.WriteLine();
			}

			Console.Write("Entre o ID do funcionário que terá aumento salarial: ");
			id = int.Parse(Console.ReadLine());

			Funcionario pesquisa = funcionarios.Find(x => x.Id == id);

			if (pesquisa != null)
			{
				Console.Write("Entre a porcentagem do aumento: ");
				porcentagem = int.Parse(Console.ReadLine());

				pesquisa.AumentoSalario(porcentagem);
			}
			else
			{
				Console.WriteLine("Esse ID não existe!");
			}

			Console.WriteLine();

			Console.WriteLine("Lista de funcionários atualizada:");
			foreach (Funcionario f in funcionarios)
			{
				Console.WriteLine(f);
			}
		}
	}
}
