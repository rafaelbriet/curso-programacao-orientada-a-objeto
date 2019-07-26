using System;
using System.Globalization;

namespace ExercicioProposto
{
	class ContaCorrente
	{
		public int Conta { get; private set; }
		public double Saldo { get; private set; }
		public string Nome { get; set; }

		public ContaCorrente(int conta, string nome)
		{
			Conta = conta;
			Nome = nome;
		}

		public ContaCorrente(int conta, string nome, double depositoInicial) : this(conta, nome)
		{
			Deposito(depositoInicial);
		}

		public void Deposito(double valorDepositado)
		{
			Saldo += valorDepositado;
		}

		public void Saque(double valorSacado)
		{
			Saldo -= valorSacado + 5.0;
		}

		public override string ToString()
		{
			string mensagem = "Conta: " + Conta + ", Titular: " + Nome + ", Saldo: R$ " + Saldo.ToString("F2", CultureInfo.InvariantCulture);

			return mensagem;
		}
	}
}
