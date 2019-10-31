using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioProposto
{
	class Program
	{

		// Fazer um programa que lê o caminho de um arquivo .csv contendo os dados de produtos vendidos.
		// Gerar um arquivo com o nome "summary.csv" um uma subpasta chamada "out", contendo apenas
		// o nome e o valor de cada produto;
		static void Main(string[] args)
		{
			string source = "D:\\Cursos\\Curso Programação Orientada a Objeto\\Secao13\\data\\mock_data.csv";
			//string destination = "D:\\Cursos\\Curso Programação Orientada a Objeto\\Secao13\\data\\out\\summary.csv";
			string destination;

			string line;
			List<string> summaryLines = new List<string>();

			Console.WriteLine("Destino do arquivo:");
			string destinationInput = Console.ReadLine();
			Console.WriteLine("Nome do arquivo:");
			string fileName = Console.ReadLine();

			destination = $@"{destinationInput}\\{fileName}.csv";

			try
			{
				// Abre o arquivo de origem
				using (FileStream fs = new FileStream(source, FileMode.Open))
				{
					// Lê o conteúdo do arquivo de origem
					using (StreamReader sr = new StreamReader(fs))
					{
						while ((line = sr.ReadLine()) != null)
						{
							string[] temp = line.Split(',');
							// remove a coluna de quantidade da linha e adiciona a uma lista
							summaryLines.Add($"{temp[0]},{temp[1]}");
						}
					}
				}

				// Caso a pasta de destino não exita cria uma nova pasta
				if (!Directory.Exists(Path.GetDirectoryName(destination)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(destination));
				}

				// Abre o arquivo de destino
				using (FileStream fs = new FileStream(destination, FileMode.Create))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						// Insere as linhas editas em um novo arquivo
						foreach (string l in summaryLines)
						{
							sw.WriteLine(l);
						}
					}
				}
			}
			catch (IOException e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				throw;
			}
		}
	}
}
