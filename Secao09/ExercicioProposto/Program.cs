using System;
using System.Globalization;
using System.Text;
using ExercicioProposto.Entities;

namespace ExercicioProposto
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("ENTER CLIENT DATA:");
			Console.Write("Name: ");
			string clientName = Console.ReadLine();
			Console.Write("Email: ");
			string clientEmail = Console.ReadLine();
			Console.Write("Birth date (DD/MM/YYYY): ");
			DateTime clientBirthDate = DateTime.Parse(Console.ReadLine());

			Client client = new Client(clientName, clientEmail, clientBirthDate);

			Console.WriteLine("ENTER ORDER DATA:");
			Console.Write("Status: ");
			OrderStatus orderStatus = (OrderStatus) Enum.Parse(typeof(OrderStatus), Console.ReadLine());

			Order order = new Order(client, orderStatus);

			Console.Write("How Many items for this order? ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine($"Enter #{i +1 } item data:");
				Console.Write("Product name: ");
				string productName = Console.ReadLine();
				Console.Write("Name: ");
				double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
				Console.Write("Quantity: ");
				int quantity = int.Parse(Console.ReadLine());

				Product product = new Product(productName, productPrice);

				order.AddItem(new OrderItem(quantity, product));
			}

			Console.WriteLine();

			Console.WriteLine("ORDER SUMMARY");

			StringBuilder orderSummary = new StringBuilder();
			orderSummary.AppendLine($"Order moment: {order.Moment}");
			orderSummary.AppendLine($"Order status: {order.OrderStatus}");
			orderSummary.AppendLine($"Client: {order.Client}");
			orderSummary.AppendLine("Order items:");

			foreach (OrderItem item in order.OrderItems)
			{
				orderSummary.Append($"{item.Product.Name}, R$ {item.Price.ToString("F2", CultureInfo.InvariantCulture)}, ");
				orderSummary.AppendLine($"Quantity: {item.Quantity}, Subtotal: R$ {item.Subtotal().ToString("F2", CultureInfo.InvariantCulture)}");
			}

			orderSummary.AppendLine($"Total price: R$ {order.Total().ToString("F2", CultureInfo.InvariantCulture)}");

			Console.WriteLine(orderSummary.ToString());
		}
	}
}
