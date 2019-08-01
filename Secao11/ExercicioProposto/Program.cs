using System;
using ExercicioProposto.Entities;
using ExercicioProposto.Exceptions;

namespace ExercicioProposto
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter account data");

			Console.Write("Number: ");
			int number = int.Parse(Console.ReadLine());

			Console.Write("Holder: ");
			string holder = Console.ReadLine();

			Console.Write("Initial balance: ");
			double balance = double.Parse(Console.ReadLine());

			Console.Write("Withdraw limit: ");
			double limit = double.Parse(Console.ReadLine());

			Account account = new Account(number, holder, balance, limit);

			Console.WriteLine();
			Console.Write("Enter the ammount to withdraw: ");
			double amountToWithdraw = double.Parse(Console.ReadLine());

			try
			{
				account.Withdraw(amountToWithdraw);
				Console.WriteLine("New Balance: {0:0.00}", account.Balance);
			}
			catch (AccountException e)
			{
				Console.WriteLine(e.Message);
			}

			Console.WriteLine();
			Console.WriteLine("Do you want to do another operation?");
		}
	}
}
