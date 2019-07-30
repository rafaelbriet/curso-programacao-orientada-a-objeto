namespace ExercicioProposto.Entities
{
	class OrderItem
	{
		public int Quantity { get; set; }
		public double Price { get; set; }
		public Product Product { get; private set; }

		public OrderItem(int quantity, Product product)
		{
			Quantity = quantity;
			Price = product.Price;
			Product = product;
		}

		public double Subtotal()
		{
			return Quantity * Price;
		}
	}
}
