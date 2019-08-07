using System;
using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ChessMatch chessMatch = new ChessMatch();

				UI.PrintBoard(chessMatch.GameBoard);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}

			Console.ReadLine();
		}
	}
}
