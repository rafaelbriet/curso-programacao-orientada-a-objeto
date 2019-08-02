using System;
using ChessGame.Board;

namespace ChessGame
{
	class UI
	{
		public static void InitBoard(GameBoard board)
		{
			for (int x = 0; x < board.Lines; x++)
			{
				for (int y = 0; y < board.Collumns; y++)
				{
					Piece piece = board.GetPieceAt(x, y);

					if (piece == null)
					{
						Console.Write("_ ");
					}
					else
					{
						Console.Write($"{piece} ");
					}
				}

				Console.WriteLine();
			}
		}
	}
}
