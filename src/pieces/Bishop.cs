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
			if (!CheckDestinationPieceColour (grid))
				return false;
			if (IsDestinationSameGrid (grid))
				return false;

			if (Math.Abs (grid.X - this.Grid.X) == Math.Abs (grid.Y - this.Grid.Y))
			{
				return CheckDiagonal (grid, cb);
			}
			else
				return false;				
		}


	}
}

