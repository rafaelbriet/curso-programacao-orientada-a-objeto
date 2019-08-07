using System;
using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
	class UI
	{
		public static void PrintBoard(GameBoard board)
		{
			for (int x = 0; x < board.Lines; x++)
			{
				Console.Write($"{8 - x} ");

				for (int y = 0; y < board.Collumns; y++)
				{
					Piece piece = board.GetPieceAt(x, y);

					if (piece == null)
					{
						Console.Write("_ ");
					}
					else
					{
						PrintPiece(piece);
						Console.Write(" ");
					}
				}

				Console.WriteLine();
			}

			Console.WriteLine("  A B C D E F G H");
		}

		public static void PrintPiece(Piece piece)
		{
			switch (piece.Color)
			{
				case Color.Black:
					ConsoleColor defaultColor = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write(piece);
					Console.ForegroundColor = defaultColor;
					break;
				case Color.White:
					Console.Write(piece);
					break;
				default:
					break;
			}
		}

		public static ChessPosition ReadPosition()
		{
			string input = Console.ReadLine();

			int line = int.Parse(input[1] + "");
			char collumn = input[0];

			return new ChessPosition(line, collumn);
		}
	}
}
