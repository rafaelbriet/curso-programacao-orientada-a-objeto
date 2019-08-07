using System;
using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			ChessMatch chessMatch = new ChessMatch();

			while (chessMatch.HasMatchFinished == false)
			{
				try
				{
					Console.Clear();

					UI.PrintBoard(chessMatch.GameBoard);

					Console.WriteLine();
					Console.Write("Origem: ");
					Position origin = UI.ReadPosition().ToPosition();
					Console.Write("Destino: ");
					Position destination = UI.ReadPosition().ToPosition();

					chessMatch.Move(origin, destination);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine(e.StackTrace);
				}
			}

			Console.ReadLine();
		}
	}
}
