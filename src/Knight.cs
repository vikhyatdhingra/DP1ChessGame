using System;

namespace ChessGame
{
	public class Knight: ChessPiece
	{
		public Knight (Grid initGrid, string player): base(initGrid, player, "K")
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

