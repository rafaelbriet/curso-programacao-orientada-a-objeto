using System;
using System.Collections.Generic;

namespace ExercicioConjunto
{
	class Program
	{
		static void Main(string[] args)
		{
			HashSet<int> a = new HashSet<int>();
			HashSet<int> b = new HashSet<int>();
			HashSet<int> c = new HashSet<int>();

			int n;

			// Preenche o primeiro curso
			Console.Write("O curso A possui quantos alunos: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite os códigos dos alunos do curso A:");

			for (int i = 0; i < n; i++)
			{
				a.Add(int.Parse(Console.ReadLine()));
			}

			// Preenche o segundo curso
			Console.Write("O curso B possui quantos alunos: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite os códigos dos alunos do curso B:");

			for (int i = 0; i < n; i++)
			{
				b.Add(int.Parse(Console.ReadLine()));
			}

			// Preenche o terceiro curso
			Console.Write("O curso B possui quantos alunos: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("Digite os códigos dos alunos do curso C:");

			for (int i = 0; i < n; i++)
			{
				c.Add(int.Parse(Console.ReadLine()));
			}

			HashSet<int> alunos = new HashSet<int>();
			alunos.UnionWith(a);
			alunos.UnionWith(b);
			alunos.UnionWith(c);

			int totalAlunos = 0;
			foreach (int x in alunos)
			{
				totalAlunos++;
			}

			Console.WriteLine("Total de alunos: {0}", totalAlunos);
		}
	}
}
