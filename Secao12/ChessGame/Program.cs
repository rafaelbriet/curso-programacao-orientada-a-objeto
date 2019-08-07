﻿using System;
using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			GameBoard gameBoard = new GameBoard(8, 8);

			try
			{
				gameBoard.AddPiece(new Rook(gameBoard, Color.Black), new Position(0, 0));
				gameBoard.AddPiece(new Rook(gameBoard, Color.Black), new Position(0, 7));
				gameBoard.AddPiece(new King(gameBoard, Color.Black), new Position(0, 5));

				UI.InitBoard(gameBoard);
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
