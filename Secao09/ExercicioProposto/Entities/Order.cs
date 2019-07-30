using System;
using System.Collections.Generic;

namespace ExercicioProposto.Entities
{
	class Order
	{
		public DateTime Moment { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public Client Client { get; set; }
		public List<OrderItem> OrderItems { get; set; }

		public Order(Client client, OrderStatus orderStatus)
		{
			Moment = DateTime.Now;
			OrderStatus = orderStatus;
			Client = client;
			OrderItems = new List<OrderItem>();
		}

		public void AddItem(OrderItem item)
		{
			OrderItems.Add(item);
		}

		public void RemoveItem(OrderItem item)
		{
			OrderItems.Remove(item);
		}

		public double Total()
		{
			double total = 0.0;

			foreach (OrderItem item in OrderItems)
			{
				total += item.Subtotal();
			}

			return total;
		}
	}
}
