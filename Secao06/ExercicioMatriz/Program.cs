using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMatriz
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Digite o número de linhas: ");
			int m = int.Parse(Console.ReadLine());

			Console.Write("Digite o número de colunas: ");
			int n = int.Parse(Console.ReadLine());

			int[,] matriz = new int[m, n];

			// Preenche a matriz
			for (int i = 0; i < m; i++)
			{
				string[] entrada = Console.ReadLine().Split(' ');

				for (int j = 0; j < n; j++)
				{
					matriz[i, j] = int.Parse(entrada[j]);
				}
			}


			//Console.WriteLine("Length {0}", matriz.Length);
			//Console.WriteLine("Rank {0}", matriz.Rank);
			//Console.WriteLine("GetLength {0} x {1}", matriz.GetLength(0), matriz.GetLength(1));
			//Console.WriteLine("GetLowerBound {0} x {1}", matriz.GetLowerBound(0), matriz.GetLowerBound(1));
			//Console.WriteLine("GetUpperBound {0} x {1}", matriz.GetUpperBound(0), matriz.GetUpperBound(1));

			Console.Write("Digite um valor: ");
			int x = int.Parse(Console.ReadLine());

			Console.WriteLine("------------------------------");
			
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (matriz[i, j] == x)
					{
						// Posição do número digitado
						Console.WriteLine("Posição: {0}, {1}", i, j);

						// Número a esquerda do número digitado
						if (j > 0)
						{
							Console.WriteLine("Esquerda: {0}", matriz[i, j - 1]);
						}
						
						// Número a direita do número digitado
						if (j < n - 1)
						{
							Console.WriteLine("Direita: {0}", matriz[i, j + 1]);
						}

						// Número acima do número digitado
						if (i > 0)
						{
							Console.WriteLine("Acima: {0}", matriz[i - 1, j]);
						}

						// Número abaixo do número digitado
						if (i < m - 1)
						{
							Console.WriteLine("Abaixo: {0}", matriz[i + 1, j]);
						}

						Console.WriteLine("------------------------------");
					}
				}
			}
		}
	}
}
