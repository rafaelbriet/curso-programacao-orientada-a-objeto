namespace ChessGame.Board
{
	class Piece
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
	}
}
