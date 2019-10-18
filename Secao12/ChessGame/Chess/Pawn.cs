using ChessGame.Board;

namespace ChessGame.Chess
{
	class Pawn : Piece
	{
		public Pawn(GameBoard board, Color color) : base(board, color) { }

		public override string ToString()
		{
			return "P";
		}

		public override bool[,] ValidMoves()
		{
			bool[,] validMoves = new bool[Board.Lines, Board.Collumns];

			Position tempPosition = new Position(0, 0);

			if (Color == Color.White)
			{
				tempPosition.SetPosition(Position.Line - 1, Position.Collumn);
				if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}

				tempPosition.SetPosition(Position.Line - 2, Position.Collumn);
				if (Board.isPositionValid(tempPosition) && CanMove(tempPosition) && Movements == 0)
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}

				tempPosition.SetPosition(Position.Line - 1, Position.Collumn - 1);
				if (Board.isPositionValid(tempPosition) && HasOpponent(tempPosition))
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}

				tempPosition.SetPosition(Position.Line - 1, Position.Collumn + 1);
				if (Board.isPositionValid(tempPosition) && HasOpponent(tempPosition))
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}
			}
			else
			{
				tempPosition.SetPosition(Position.Line + 1, Position.Collumn);
				if (Board.isPositionValid(tempPosition) && CanMove(tempPosition))
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}

				tempPosition.SetPosition(Position.Line + 2, Position.Collumn);
				if (Board.isPositionValid(tempPosition) && CanMove(tempPosition) && Movements == 0)
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}

				tempPosition.SetPosition(Position.Line + 1, Position.Collumn - 1);
				if (Board.isPositionValid(tempPosition) && HasOpponent(tempPosition))
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}

				tempPosition.SetPosition(Position.Line + 1, Position.Collumn + 1);
				if (Board.isPositionValid(tempPosition) && HasOpponent(tempPosition))
				{
					validMoves[tempPosition.Line, tempPosition.Collumn] = true;
				}
			}

			return validMoves;
		}

		private bool HasOpponent(Position position)
		{
			Piece piece = Board.GetPieceAt(position);

			if (piece != null && piece.Color != Color)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool FreeMove(Position position)
		{
			if (Board.GetPieceAt(position) == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
