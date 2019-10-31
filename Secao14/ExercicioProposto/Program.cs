using System;
using System.Collections.Generic;
using System.Globalization;
using ExercicioProposto.Entities;
using ExercicioProposto.Services;

namespace ExercicioProposto
{
	// Gerar as parcelas a serem pagar de um contrato de acordo com a quantidade de meses desejadas.
	// O seviço de pagamento online utilizado (PayPal) cobra juro simples de 1% sobre cada parcela,
	// mais uma taxa de pagamento de 2%.
	// Fazer um programa que lê os dados de um contrato (número, data e valor). Ler o número de meses
	// para parcelamento e gerar as parcelas (sendo o primeiro pagamento um mês após a data inicial do
	// contrato. Mostrar os dados no console.
	class Program
	{
		static void Main(string[] args)
		{
			int input;
			string source = @"D:\Cursos\Curso Programação Orientada a Objeto\Secao14\data\contracts.csv";
			string destination = @"D:\Cursos\Curso Programação Orientada a Objeto\Secao14\data";

			do
			{
				Console.WriteLine("(1) Show all contracts (2) Search for contract");
				input = int.Parse(Console.ReadLine());

				if (input == 1)
				{
					Console.Clear();
					Console.WriteLine("Contracts:");

					List<Contract> contracts = ContractService.LoadAllContracts(source);

					foreach (Contract c in contracts)
					{
						Console.WriteLine(c);
					}

					Console.WriteLine();
				}
				else if (input == 2)
				{
					Console.WriteLine();
					Console.WriteLine("Enter contract Number: ");
					int number = int.Parse(Console.ReadLine());

					Contract contract = ContractService.SearchContract(source, number);

					Console.WriteLine();
					Console.WriteLine(contract);

					Console.WriteLine();
					Console.Write("Number of installments: ");
					int numberOfInstallments = int.Parse(Console.ReadLine());

					ContractService.ProcessContract(contract, numberOfInstallments, new PaypalSrevice());

					Console.WriteLine();
					Console.WriteLine("Installments:");

					foreach (Installment installment in contract.Installments)
					{
						Console.WriteLine($"{installment.DueDate.ToString("dd/MM/yyyy")} - {installment.Amount.ToString("F2", CultureInfo.InvariantCulture)}");
					}

					Console.WriteLine();
					Console.WriteLine("Save contract to file? (Y) Yes (N) No");
					string save = Console.ReadLine();

					if (save == "Y" || save == "y")
					{
						ContractService.SaveContract(destination, contract);
					}

					Console.WriteLine();
				}
			}
			while (input == 1 || input == 2);
		}
	}
}
