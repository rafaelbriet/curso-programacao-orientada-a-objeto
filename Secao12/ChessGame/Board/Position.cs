namespace ChessGame.Board
{
	class Position
	{
		public int Line { get; set; }
		public int Collumn { get; set; }

		public Position(int line, int collumn)
		{
			Line = line;
			Collumn = collumn;
		}

		public override string ToString()
		{
			return $"{Line}, {Collumn}";
		}
	}
}
