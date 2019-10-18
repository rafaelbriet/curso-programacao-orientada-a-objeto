using ChessGame.Board;

namespace ChessGame.Chess
{
	class Queen : Piece
	{
		public Queen(GameBoard board, Color color) : base(board, color) { }

		public override string ToString()
		{
			return "Q";
		}

		public override bool[,] ValidMoves()
		{
			bool[,] validMoves = new bool[Board.Lines, Board.Collumns];

			Position tempPosition = new Position(0, 0);

			// Up
			tempPosition.SetPosition(Position.Line - 1, Position.Collumn);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Line -= 1;
			}

			// Right
			tempPosition.SetPosition(Position.Line, Position.Collumn + 1);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Collumn += 1;
			}

			// Down
			tempPosition.SetPosition(Position.Line + 1, Position.Collumn);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Line += 1;
			}

			// Left
			tempPosition.SetPosition(Position.Line, Position.Collumn - 1);

			while (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;

				if (Board.GetPieceAt(tempPosition) != null && Board.GetPieceAt(tempPosition).Color != Color)
				{
					break;
				}

				tempPosition.Collumn -= 1;
			}

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
