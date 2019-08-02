using System;
using ChessGame.Board;

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			GameBoard gameBoard = new GameBoard(8, 8);

			UI.InitBoard(gameBoard);

			Console.ReadLine();
		}
	}
}
