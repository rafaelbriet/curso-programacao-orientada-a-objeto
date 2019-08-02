using System;
using ChessGame.Board;

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Position position = new Position(3, 4);

			Console.WriteLine($"Position: {position}");
		}
	}
}
