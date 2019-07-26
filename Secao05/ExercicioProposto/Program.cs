using System;
using System.Globalization;

namespace ExercicioProposto
{
	class Program
	{
		static void Main(string[] args)
		{
			int conta;
			string nome;
			char haveraDepositoInicial;
			double valorParaDeposito;
			double valorParaSaque;

			ContaCorrente cliente;

			Console.Write("Entre o número da conta: ");
			conta = int.Parse(Console.ReadLine());

			Console.Write("Entre o titular da conta: ");
			nome = Console.ReadLine();

			Console.Write("Havéra depósito inicial (s/n)? ");
			haveraDepositoInicial = char.Parse(Console.ReadLine());

			if (haveraDepositoInicial == 's')
			{
				Console.Write("Entre o valor de depósito inical: ");
				valorParaDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

				cliente = new ContaCorrente(conta, nome, valorParaDeposito);
			}
			else
			{
				cliente = new ContaCorrente(conta, nome);
			}

			Console.WriteLine();
			Console.WriteLine("Dados da conta");
			Console.WriteLine(cliente);

			Console.WriteLine();
			Console.Write("Entre um valor para depósito: ");
			valorParaDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
			cliente.Deposito(valorParaDeposito);
			Console.WriteLine("Dados da conta atualizados");
			Console.WriteLine(cliente);

			Console.WriteLine();
			Console.Write("Entre um valor para saque: ");
			valorParaSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
			cliente.Saque(valorParaSaque);
			Console.WriteLine("Dados da conta atualizados");
			Console.WriteLine(cliente);
		}
	}
}
