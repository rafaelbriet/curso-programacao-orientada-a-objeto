namespace ChessGame.Board
{
	abstract class Piece
	{
		public Position Position { get; set; }
		public GameBoard Board { get; protected set; }
		public Color Color { get; protected set; }
		public int Movements { get; protected set; }

		public Piece(GameBoard board, Color color)
		{
			Position = null;
			Board = board;
			Color = color;
			Movements = 0;
		}

		public void IncreaseMovements()
		{
			Movements++;
		}

		public bool CanMove(Position position)
		{
			Piece piece = Board.GetPieceAt(position);

			if (piece == null || piece.Color != Color)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CanMoveTo(Position position)
		{
			return ValidMoves()[position.Line, position.Collumn];
		}

		public bool HasValidMoves()
		{
			bool[,] moves = ValidMoves();

			for (int x = 0; x < Board.Lines; x++)
			{
				for (int y = 0; y < Board.Collumns; y++)
				{
					if (moves[x, y] == true)
					{
						return true;
					}
				}
			}

			return false;
		}

		public abstract bool[,] ValidMoves();
	}
}
