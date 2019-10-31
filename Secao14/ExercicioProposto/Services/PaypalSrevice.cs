using System;

namespace ExercicioProposto.Services
{
	class PaypalSrevice : IOnlinePaymentService
	{
		public double Insterest(double amount, int months)
		{
			return amount + (amount * 0.01) * months;
		}

		public double PaymentFee(double amount)
		{
			return amount + (amount * 0.02);
		}
	}
}
