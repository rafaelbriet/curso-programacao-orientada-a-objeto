using System;

namespace ChessGame.Board
{
	class GameBoardExecption : Exception
	{
		public GameBoardExecption(string message) :  base(message) { }
	}
}
