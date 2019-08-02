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
	}
}
