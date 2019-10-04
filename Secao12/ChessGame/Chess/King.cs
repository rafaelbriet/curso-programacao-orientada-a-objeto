using ChessGame.Board;

namespace ChessGame.Chess
{
	class King : Piece
	{
		public King(GameBoard board, Color color) : base(board, color) { }

		public override string ToString()
		{
			return "K";
		}

		public override bool[,] ValidMoves()
		{
			bool[,] validMoves = new bool[Board.Lines, Board.Collumns];

			Position tempPosition = new Position(0, 0);

			// Up
			tempPosition.SetPosition(Position.Line - 1, Position.Collumn);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			// Up Right
			tempPosition.SetPosition(Position.Line - 1, Position.Collumn + 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			// Right
			tempPosition.SetPosition(Position.Line, Position.Collumn + 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			// Right Down
			tempPosition.SetPosition(Position.Line + 1, Position.Collumn + 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			// Down
			tempPosition.SetPosition(Position.Line + 1, Position.Collumn);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			// Down Left
			tempPosition.SetPosition(Position.Line + 1, Position.Collumn - 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			// Left
			tempPosition.SetPosition(Position.Line , Position.Collumn - 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			// Left Up
			tempPosition.SetPosition(Position.Line - 1, Position.Collumn - 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			return validMoves;
		}
	}
}
