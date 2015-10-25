using System;

namespace ChessGame
{
	public class Queen: ChessPiece 
	{
		public Queen (Grid initGrid, string player) :base(initGrid, player, "Q") 
		{
		}

		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			return true;
		}

		public override string MovePiece(Grid grid, ChessBoard cb)
		{
			return "";
		}
	}
}

