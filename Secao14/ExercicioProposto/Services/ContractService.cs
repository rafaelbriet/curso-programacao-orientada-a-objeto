using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ExercicioProposto.Entities;

namespace ExercicioProposto.Services
{
	static class ContractService
	{
		public static void ProcessContract(Contract contract, int months, IOnlinePaymentService paymentService)
		{
			double baseInstallmentValue = contract.TotalValue / months;

			for (int i = 1; i <= months; i++)
			{
				DateTime dueDate = contract.Date.AddMonths(i);
				double installmentValue = paymentService.PaymentFee(paymentService.Insterest(baseInstallmentValue, i));

				contract.Installments.Add(new Installment(dueDate, installmentValue));
			}
		}

		public static Contract SearchContract(string source, int contractNumber)
		{
			Contract contract = null;

			using (FileStream fs = new FileStream(source, FileMode.Open))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
					string line;

					while ((line = sr.ReadLine()) != null)
					{
						if (line.Contains(contractNumber.ToString()))
						{
							string[] serachResult = line.Split(',');

							int number = int.Parse(serachResult[0]);
							DateTime date = DateTime.Parse(serachResult[1]);
							double value = double.Parse(serachResult[2], CultureInfo.InvariantCulture);

							contract = new Contract(number, date, value);
						}
					}
				}
			}

			return contract;
		}

		public static List<Contract> LoadAllContracts(string source)
		{
			List<Contract> contracts = new List<Contract>();

			using (FileStream fs = new FileStream(source, FileMode.Open))
			{
				using (StreamReader sr = new StreamReader(fs))
				{
					string line;

					while ((line = sr.ReadLine()) != null)
					{
						string[] serachResult = line.Split(',');

						int number = int.Parse(serachResult[0]);
						DateTime date = DateTime.Parse(serachResult[1]);
						double value = double.Parse(serachResult[2], CultureInfo.InvariantCulture);

						Contract contract = new Contract(number, date, value);

						contracts.Add(contract);
					}
				}
			}

			return contracts;
		}

		public static void SaveContract(string destination, Contract contract)
		{
			using (FileStream fs = new FileStream(destination + $@"\{contract.Number}.txt", FileMode.Create))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					sw.WriteLine(contract.ToString().Replace(" ", ""));

					foreach (Installment i in contract.Installments)
					{
						sw.WriteLine(i.ToString().Replace(" ", ""));
					}
				}
			}
		}
	}
}