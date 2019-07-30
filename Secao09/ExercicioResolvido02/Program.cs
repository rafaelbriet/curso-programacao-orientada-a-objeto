using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioResolvido02
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime date;
			string title;
			string content;
			int likes;

			date = DateTime.Parse("21/06/2018 13:05:44");
			title = "Traveling to New Zealand";
			content = "I'm going to visit this wonderful country";
			likes = 12;

			Post post1 = new Post(date, title, content, likes);

			Comment comment1 = new Comment("Have a nice trip");
			Comment comment2 = new Comment("Wow that's awesome");

			post1.AddComment(comment1);
			post1.AddComment(comment2);

			date = DateTime.Parse("28/07/2018 23:14:19");
			title = "Good night guys";
			content = "See you tomorrow";
			likes = 5;

			Post post2 = new Post(date, title, content, likes);

			Comment comment3 = new Comment("Good night");
			Comment comment4 = new Comment("May the force be with you");

			post2.AddComment(comment3);
			post2.AddComment(comment4);

			Console.WriteLine(post1);
			Console.WriteLine();
			Console.WriteLine(post2);
		}
	}
}
