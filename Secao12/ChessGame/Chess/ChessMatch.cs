using ChessGame.Board;
using System.Collections.Generic;

namespace ChessGame.Chess
{
	class ChessMatch
	{
		public GameBoard GameBoard { get; private set; }
		public bool HasMatchFinished { get; private set; }
		public bool IsInCheck { get; private set; }
		public int CurrentTurn { get; private set; }
		public Color CurrentPlayer { get; private set; }

		private HashSet<Piece> gamePieces;
		private HashSet<Piece> capturedPieces;

		public ChessMatch()
		{
			GameBoard = new GameBoard(8, 8);
			HasMatchFinished = false;
			IsInCheck = false;
			CurrentTurn = 1;
			CurrentPlayer = Color.White;
			gamePieces = new HashSet<Piece>();
			capturedPieces = new HashSet<Piece>();

			StartMatch();
		}

		public Piece DoMove(Position origin, Position destination)
		{
			Piece piece = GameBoard.RemovePiece(origin);

			piece.IncreaseMovements();

			Piece capturedPiece = GameBoard.RemovePiece(destination);

			GameBoard.AddPiece(piece, destination);

			if (capturedPiece != null)
			{
				capturedPieces.Add(capturedPiece);
			}

			return capturedPiece;
		}

		public void UndoMove(Position origin, Position destination, Piece capturedPiece)
		{
			Piece piece = GameBoard.RemovePiece(destination);

			piece.DecreaseMovements();

			if (capturedPiece != null)
			{
				GameBoard.AddPiece(capturedPiece, destination);
				capturedPieces.Remove(capturedPiece);
			}

			GameBoard.AddPiece(piece, origin);
		}

		public void PerformMove(Position origin, Position destination)
		{
			Piece capturedPiece = DoMove(origin, destination);

			if (Check(CurrentPlayer))
			{
				UndoMove(origin, destination, capturedPiece);
				throw new GameBoardExecption("You can't put yourself in check.");
			}

			if (Check(GetOpponent(CurrentPlayer)))
			{
				IsInCheck = true;
			}
			else
			{
				IsInCheck = false;
			}

			if (Checkmate(GetOpponent(CurrentPlayer)))
			{
				HasMatchFinished = true;
			}
			else
			{
				CurrentTurn++;
				ChangePlayer();
			}
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

		private Color GetOpponent(Color color)
		{
			if (color == Color.White)
			{
				return Color.Black;
			}
			else
			{
				return Color.White;
			}
		}

		private Piece GetKing(Color color)
		{
			foreach (Piece p in GetPiecesByColor(color))
			{
				if (p is King)
				{
					return p;
				}
			}

			return null;
		}

		private bool Check(Color color)
		{
			Piece king = GetKing(color);

			foreach (Piece p in GetPiecesByColor(GetOpponent(color)))
			{
				bool[,] moves = p.ValidMoves();

				if (moves[king.Position.Line, king.Position.Collumn])
				{
					return true;
				}
			}

			return false;
		}

		private bool Checkmate(Color color)
		{
			if (Check(color) == false)
			{
				return false;
			}

			foreach (Piece p in GetPiecesByColor(color))
			{
				bool[,] moves = p.ValidMoves();

				for (int x = 0; x < GameBoard.Lines; x++)
				{
					for (int y = 0; y < GameBoard.Collumns; y++)
					{
						if (moves[x, y])
						{
							Position origin = p.Position;
							Position destination = new Position(x, y);
							Piece capturedPiece = DoMove(origin, destination);

							bool isCheck = Check(color);

							UndoMove(origin, destination, capturedPiece);

							if (isCheck == false)
							{
								return false;
							}
						}
					}
				}
			}

			return true;
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
			//AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(1, 'c'));
			//AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'c'));
			//AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'd'));
			AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(7, 'h'));
			AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(1, 'c'));
			AddPiece(new King(GameBoard, Color.White), new ChessPosition(1, 'd'));

			//AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'c'));
			//AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(8, 'c'));
			//AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'd'));
			//AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'e'));
			AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(8, 'b'));
			AddPiece(new King(GameBoard, Color.Black), new ChessPosition(8, 'a'));
		}
	}
}
