using System;

namespace ChessGame
{
	public class Bishop: ChessPiece
	{
		public Bishop (Grid initGrid, string player) :base(initGrid, player, "B")
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

