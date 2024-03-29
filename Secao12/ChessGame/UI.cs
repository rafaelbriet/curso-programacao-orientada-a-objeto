﻿using System;
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
					PrintPiece(board.GetPieceAt(x, y));
				}

				Console.WriteLine();
			}

			Console.WriteLine("  A B C D E F G H");
		}

		public static void PrintGameStatus(ChessMatch match)
		{
			ConsoleColor defaultColor = Console.ForegroundColor;

			Console.WriteLine();
			Console.WriteLine("Current turn: {0}", match.CurrentTurn);

			if (match.HasMatchFinished == false)
			{
				if (match.CurrentPlayer == Color.White)
				{
					Console.WriteLine("Waiting for the white player move");
				}
				else
				{
					Console.WriteLine("Waiting for the black player move");
				}

				if (match.IsInCheck == true)
				{
					Console.WriteLine();
					Console.WriteLine("CHECK!");
				}
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("CHECKMATE!");
				Console.WriteLine("{0} player is the winner.", match.CurrentPlayer);
			}


			Console.WriteLine();
			Console.Write("White pieces captured: ");
			foreach (Piece p in match.GetCapturedPiecesByColor(Color.White))
			{
				Console.Write(p + " ");
			}

			Console.WriteLine();
			Console.Write("Black pieces captured: ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			foreach (Piece p in match.GetCapturedPiecesByColor(Color.Black))
			{
				Console.Write(p + " ");
			}
			Console.ForegroundColor = defaultColor;

			Console.WriteLine();
		}

		public static void PrintBoard(GameBoard board, bool[,] validMoves)
		{
			ConsoleColor defaultColor = Console.BackgroundColor;
			ConsoleColor validMovesBackgroundColor = ConsoleColor.DarkGray;

			for (int x = 0; x < board.Lines; x++)
			{
				Console.Write($"{8 - x} ");

				for (int y = 0; y < board.Collumns; y++)
				{
					if (validMoves[x, y] == true)
					{
						Console.BackgroundColor = validMovesBackgroundColor;
					}
					else
					{
						Console.BackgroundColor = defaultColor;
					}

					PrintPiece(board.GetPieceAt(x, y));
					Console.BackgroundColor = defaultColor;
				}

				Console.WriteLine();
			}

			Console.WriteLine("  A B C D E F G H");
			Console.BackgroundColor = defaultColor;
		}

		public static void PrintPiece(Piece piece)
		{
			if (piece == null)
			{
				Console.Write("_ ");
			}
			else
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

				Console.Write(" ");
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
