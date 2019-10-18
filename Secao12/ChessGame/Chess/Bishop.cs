using ChessGame.Board;

namespace ChessGame.Chess
{
	class Bishop : Piece
	{
		public Bishop(GameBoard board, Color color) : base(board, color) { }

		public override string ToString()
		{
			return "B";
		}

		public override bool[,] ValidMoves()
		{
			bool[,] validMoves = new bool[Board.Lines, Board.Collumns];

			Position tempPosition = new Position(0, 0);

			// Up Left Diagonal
			tempPosition.SetPosition(Position.Line - 1, Position.Collumn - 1);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Line -= 1;
				tempPosition.Collumn -= 1;
			}

			// Up Right Diagonal
			tempPosition.SetPosition(Position.Line - 1, Position.Collumn + 1);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Line -= 1;
				tempPosition.Collumn += 1;
			}

			// Down Right Diagonal
			tempPosition.SetPosition(Position.Line + 1, Position.Collumn + 1);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Line += 1;
				tempPosition.Collumn += 1;
			}

			// Down Left Diagonal
			tempPosition.SetPosition(Position.Line + 1, Position.Collumn - 1);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Line += 1;
				tempPosition.Collumn -= 1;
			}

			return validMoves;
		}
	}
}
