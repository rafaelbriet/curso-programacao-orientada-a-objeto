using ChessGame.Board;
using System.Collections.Generic;

namespace ChessGame.Chess
{
	class ChessMatch
	{
		public GameBoard GameBoard { get; private set; }
		public bool HasMatchFinished { get; private set; }

		public int CurrentTurn { get; private set; }
		public Color CurrentPlayer { get; private set; }

		private HashSet<Piece> gamePieces;
		private HashSet<Piece> capturedPieces;

		public ChessMatch()
		{
			GameBoard = new GameBoard(8, 8);
			HasMatchFinished = false;
			CurrentTurn = 1;
			CurrentPlayer = Color.White;
			gamePieces = new HashSet<Piece>();
			capturedPieces = new HashSet<Piece>();

			StartMatch();
		}

		public void Move(Position origin, Position destination)
		{
			Piece piece = GameBoard.RemovePiece(origin);

			piece.IncreaseMovements();

			Piece capturedPiece = GameBoard.RemovePiece(destination);

			GameBoard.AddPiece(piece, destination);

			if (capturedPiece != null)
			{
				capturedPieces.Add(capturedPiece);
			}
		}

		public void PerformMove(Position origin, Position destination)
		{
			Move(origin, destination);

			CurrentTurn++;

			ChangePlayer();
		}

		public void ValidateOriginPosition(Position position)
		{
			if (GameBoard.GetPieceAt(position) == null)
			{
				throw new GameBoardExecption("There is no piece in the chosen position.");
			}

			if (CurrentPlayer != GameBoard.GetPieceAt(position).Color)
			{
				throw new GameBoardExecption("Can't move a piece from other player.");
			}

			if (GameBoard.GetPieceAt(position).HasValidMoves() == false)
			{
				throw new GameBoardExecption("There is no valid movement for the chosen piece.");
			}
		}

		public void ValidateDestinationPosition(Position origin, Position destination)
		{
			if (GameBoard.GetPieceAt(origin).CanMoveTo(destination) == false)
			{
				throw new GameBoardExecption("Can't move the chosen piece to this position.");
			}
		}

		public HashSet<Piece> GetPiecesByColor(Color color)
		{
			HashSet<Piece> pieces = new HashSet<Piece>();

			foreach (Piece p in gamePieces)
			{
				if (p.Color == color)
				{
					pieces.Add(p);
				}
			}

			pieces.ExceptWith(GetCapturedPiecesByColor(color));

			return pieces;
		}

		public HashSet<Piece> GetCapturedPiecesByColor(Color color)
		{
			HashSet<Piece> pieces = new HashSet<Piece>();

			foreach (Piece p in capturedPieces)
			{
				if (p.Color == color)
				{
					pieces.Add(p);
				}
			}

			return pieces;
		}

		private void ChangePlayer()
		{
			if (CurrentPlayer == Color.White)
			{
				CurrentPlayer = Color.Black;
			}
			else
			{
				CurrentPlayer = Color.White;
			}
		}

		private void AddPiece(Piece piece, ChessPosition position)
		{
			GameBoard.AddPiece(piece, position.ToPosition());
			gamePieces.Add(piece);
		}

		private void StartMatch()
		{
			AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(1, 'c'));
			AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'c'));
			AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'd'));
			AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'e'));
			AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(1, 'e'));
			AddPiece(new King(GameBoard, Color.White), new ChessPosition(1, 'd'));

			AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'c'));
			AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(8, 'c'));
			AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'd'));
			AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'e'));
			AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(8, 'e'));
			AddPiece(new King(GameBoard, Color.Black), new ChessPosition(8, 'd'));
		}
	}
}
