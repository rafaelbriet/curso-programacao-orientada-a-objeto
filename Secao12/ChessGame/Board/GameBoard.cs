namespace ChessGame.Board
{
	class GameBoard
	{
		public int Lines { get; set; }
		public int Collumns { get; set; }

		private Piece[,] pieces;

		public GameBoard(int lines, int collumns)
		{
			Lines = lines;
			Collumns = collumns;
			pieces = new Piece[lines, collumns];
		}

		public Piece GetPieceAt(int line, int collumn)
		{
			return pieces[line, collumn];
		}

		public Piece GetPieceAt(Position position)
		{
			return pieces[position.Line, position.Collumn];
		}

		public void AddPiece(Piece piece, Position position)
		{
			if (hasPiece(position))
			{
				throw new GameBoardExecption("Invalid position");
			}

			pieces[position.Line, position.Collumn] = piece;
			piece.Position = position;
		}

		public void ValidatePosition(Position position)
		{
			if (!isPositionValid(position))
			{
				throw new GameBoardExecption("Invalid position.");
			}
		}

		public bool hasPiece(Position position)
		{
			ValidatePosition(position);
			return GetPieceAt(position) != null;
		}

		public bool isPositionValid(Position position)
		{
			if (position.Line < 0 || position.Line >= Lines || position.Collumn < 0 || position.Collumn >= Collumns)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
