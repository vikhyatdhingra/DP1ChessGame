using System;

namespace ChessGame
{
	public class King: ChessPiece
	{
		public King (Grid initGrid, string player) :base(initGrid, player, "KG") 
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

