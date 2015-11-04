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
			if (!CheckDestinationPieceColour (grid))
				return false;
			if (IsDestinationSameGrid (grid))
				return false;

			if (Math.Abs (grid.X - this.Grid.X) == 1)
			{
				if (Math.Abs (grid.Y - this.Grid.Y) == 2)
					return true;
				return false;
			}
			else if (Math.Abs (grid.Y - this.Grid.Y) == 1)
			{
				if (Math.Abs (grid.X - this.Grid.X) == 2)
					return true;
				return false;
			}
			else
			{
				return false;
			}
		}


	}
}

