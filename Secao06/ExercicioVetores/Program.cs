using System;

namespace ExercicioVetores
{
	class Program
	{
		static void Main(string[] args)
		{
			Estudante[] estudantes = new Estudante[10];

			Console.Write("Quantos quartos serão alugados? ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine("Aluguel #{0}", i + 1);

				Console.Write("Nome: ");
				string nome = Console.ReadLine();

				Console.Write("Email: ");
				string email = Console.ReadLine();

				Console.Write("Quarto: ");
				int quarto = int.Parse(Console.ReadLine());

				estudantes[quarto] = new Estudante(nome, email);
			}

			Console.WriteLine("Quartos ocupados:");
			for (int i = 0; i < estudantes.Length; i++)
			{
				if (estudantes[i] != null)
				{
					Console.WriteLine("{0}: {1}", i, estudantes[i]);
				}
			}
		}
	}
}
