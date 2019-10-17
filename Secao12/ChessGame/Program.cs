using System;
using System.Collections.Generic;

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
					UI.PrintGameStatus(chessMatch);

					Console.WriteLine();
					Console.Write("Origin: ");
					Position origin = UI.ReadPosition().ToPosition();

					chessMatch.ValidateOriginPosition(origin);

					bool[,] validMoves = chessMatch.GameBoard.GetPieceAt(origin).ValidMoves();

					Console.Clear();
					UI.PrintBoard(chessMatch.GameBoard, validMoves);
					UI.PrintGameStatus(chessMatch);

					Console.WriteLine();
					Console.Write("Destination: ");
					Position destination = UI.ReadPosition().ToPosition();

					chessMatch.ValidateDestinationPosition(origin, destination);

					chessMatch.PerformMove(origin, destination);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine(e.StackTrace);
					Console.ReadLine();
				}
			}

			Console.ReadLine();
		}
	}
}
