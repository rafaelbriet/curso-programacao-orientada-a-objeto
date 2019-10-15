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
					Console.WriteLine("Current turn: {0}", chessMatch.CurrentTurn);
					Console.WriteLine("Waiting for the {0} move", chessMatch.CurrentPlayer);

					Console.WriteLine();
					Console.Write("Origin: ");
					Position origin = UI.ReadPosition().ToPosition();

					chessMatch.ValidateOriginPosition(origin);

					bool[,] validMoves = chessMatch.GameBoard.GetPieceAt(origin).ValidMoves();

					Console.Clear();
					UI.PrintBoard(chessMatch.GameBoard, validMoves);

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
