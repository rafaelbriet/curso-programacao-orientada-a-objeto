using ChessGame.Board;

namespace ChessGame.Chess
{
	class ChessMatch
	{
		public GameBoard GameBoard { get; private set; }
		public bool HasMatchFinished { get; private set; }

		private int currentTurn;
		private Color currentPlayer;

		public ChessMatch()
		{
			GameBoard = new GameBoard(8, 8);
			HasMatchFinished = false;
			currentTurn = 1;
			currentPlayer = Color.White;

			StartMatch();
		}

		public void Move(Position origin, Position destination)
		{
			Piece piece = GameBoard.RemovePiece(origin);

			piece.IncreaseMovements();

			Piece CapturedPiece = GameBoard.RemovePiece(destination);

			GameBoard.AddPiece(piece, destination);
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
