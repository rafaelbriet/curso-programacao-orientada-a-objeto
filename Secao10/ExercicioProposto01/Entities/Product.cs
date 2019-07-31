﻿namespace ExercicioProposto01.Entities
{
	class Product
	{
		public string Name { get; set; }
		public double Price { get; set; }

		public Product(string name, double price)
		{
			Name = name;
			Price = price;
		}

		public virtual string PriceTag()
		{
			return $"{Name} - R$ {Price.ToString("F2")}";
		}
	}
}
