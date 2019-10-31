namespace ExercicioProposto.Services
{
	interface IOnlinePaymentService
	{
		double PaymentFee(double amount);
		double Insterest(double amount, int months);
	}
}
