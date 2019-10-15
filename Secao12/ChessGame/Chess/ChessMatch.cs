using ChessGame.Board;

namespace ChessGame.Chess
{
	class ChessMatch
	{
		public GameBoard GameBoard { get; private set; }
		public bool HasMatchFinished { get; private set; }

		public int CurrentTurn { get; private set; }
		public Color CurrentPlayer { get; private set; }

		public ChessMatch()
		{
			GameBoard = new GameBoard(8, 8);
			HasMatchFinished = false;
			CurrentTurn = 1;
			CurrentPlayer = Color.White;

			StartMatch();
		}

		public void Move(Position origin, Position destination)
		{
			Piece piece = GameBoard.RemovePiece(origin);

			piece.IncreaseMovements();

			Piece CapturedPiece = GameBoard.RemovePiece(destination);

			GameBoard.AddPiece(piece, destination);
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

		private void StartMatch()
		{
			GameBoard.AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(1, 'c').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'c').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'd').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(2, 'e').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.White), new ChessPosition(1, 'e').ToPosition());
			GameBoard.AddPiece(new King(GameBoard, Color.White), new ChessPosition(1, 'd').ToPosition());

			GameBoard.AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'c').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(8, 'c').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'd').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(7, 'e').ToPosition());
			GameBoard.AddPiece(new Rook(GameBoard, Color.Black), new ChessPosition(8, 'e').ToPosition());
			GameBoard.AddPiece(new King(GameBoard, Color.Black), new ChessPosition(8, 'd').ToPosition());
		}
	}
}
