using ChessGame.Board;

namespace ChessGame.Chess
{
	class Knight : Piece
	{
		public Knight(GameBoard board, Color color) : base(board, color) { }

		public override string ToString()
		{
			return "K";
		}

		public override bool[,] ValidMoves()
		{
			bool[,] validMoves = new bool[Board.Lines, Board.Collumns];

			Position tempPosition = new Position(0, 0);

			tempPosition.SetPosition(Position.Line - 1, Position.Collumn - 2);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			tempPosition.SetPosition(Position.Line - 2, Position.Collumn - 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			tempPosition.SetPosition(Position.Line - 2, Position.Collumn + 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			tempPosition.SetPosition(Position.Line - 1, Position.Collumn + 2);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			tempPosition.SetPosition(Position.Line + 1, Position.Collumn + 2);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			tempPosition.SetPosition(Position.Line + 2, Position.Collumn + 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			tempPosition.SetPosition(Position.Line + 2, Position.Collumn - 1);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			tempPosition.SetPosition(Position.Line + 1, Position.Collumn - 2);
			if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
			{
				validMoves[tempPosition.Line, tempPosition.Collumn] = true;
			}

			return validMoves;
		}

	}
}
