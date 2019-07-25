using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioClass01
{
	// DESCRIÇÃO: Fazer um programa para ler os dados de duas pessoas, depois mostrar o nome da pessoa mais velha
	class Program
	{
		static void Main(string[] args)
		{
			Pessoa pessoa1 = new Pessoa();
			Pessoa pessoa2 = new Pessoa();

			Console.WriteLine("Dados da primira pessoa");
			Console.Write("Nome: ");
			pessoa1.nome = Console.ReadLine();
			Console.Write("Idade: ");
			pessoa1.idade = int.Parse(Console.ReadLine());

			Console.WriteLine("Dados da segunda pessoa pessoa");
			Console.Write("Nome: ");
			pessoa2.nome = Console.ReadLine();
			Console.Write("Idade: ");
			pessoa2.idade = int.Parse(Console.ReadLine());

			if (pessoa1.idade > pessoa2.idade)
			{
				Console.WriteLine($"Pessoa mais velha: {pessoa1.nome}");
			}
			else
			{
				Console.WriteLine($"Pessoa mais velha: {pessoa2.nome}");
			}
		}
	}
}
