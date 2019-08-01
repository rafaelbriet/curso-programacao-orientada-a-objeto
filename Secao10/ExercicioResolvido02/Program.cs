using System;
using System.Collections.Generic;
using ExercicioResolvido02.Entities;

namespace ExercicioResolvido02
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Shape> shapes = new List<Shape>();

			Console.Write("Enter the number of shapes: ");
			int n = int.Parse(Console.ReadLine());

			for (int i = 1; i <= n; i++)
			{
				Console.WriteLine("Shape #{0} data:", i);

				Console.Write("Rectangle or Circle (r/c)? ");
				char type = char.Parse(Console.ReadLine());

				Console.Write("Color (Black/Blue/Red): ");
				Color color = (Color) Enum.Parse(typeof(Color), Console.ReadLine());

				switch (type)
				{
					case 'r':
						Console.Write("Width: ");
						double width = double.Parse(Console.ReadLine());

						Console.Write("height: ");
						double height = double.Parse(Console.ReadLine());

						shapes.Add(new Rectangle(color, width, height));

						break;
					case 'c':
						Console.Write("Radius: ");
						double radius = double.Parse(Console.ReadLine());

						shapes.Add(new Circle(color, radius));

						break;
					default:
						break;
				}
			}

			Console.WriteLine();
			Console.WriteLine("SHAPES AREA:");
			foreach (Shape shape in shapes)
			{
				Console.WriteLine(shape.Area());
			}
		}
	}
}
