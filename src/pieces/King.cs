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
			if (!CheckDestinationPieceColour (grid))
				return false;

			if (Math.Abs (grid.X - this.Grid.X) == 1 || Math.Abs (grid.Y - this.Grid.Y) == 1)
				return true;
			return false;
		}
	}
}

