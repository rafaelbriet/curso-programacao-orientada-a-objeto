using ChessGame.Board;

namespace ChessGame.Chess
{
	class ChessPosition
	{
		public int Line { get; set; }
		public char Collumn { get; set; }

		public ChessPosition(int line, char collumn)
		{
			Line = line;
			Collumn = collumn;
		}

		public Position ToPosition()
		{
			return new Position(8 - Line, Collumn - 'a');
		}

		public override string ToString()
		{
			return $"{Collumn}{Line}";
		}
	}
}
