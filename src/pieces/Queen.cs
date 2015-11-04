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
			if (!CheckDestinationPieceColour (grid))
				return false;
			if (IsDestinationSameGrid (grid))
				return false;

			if (grid.Y == this.Grid.Y)
			{
				return CheckVertical (grid, cb);
			}
			else if (grid.X == this.Grid.X)
			{ 
				return CheckHorizontal (grid, cb);
			} 
			else if (Math.Abs (grid.X - this.Grid.X) == Math.Abs (grid.Y - this.Grid.Y))
			{
				return CheckDiagonal (grid, cb);
			}
			else
			{
				return false;
			}
		}

	}
}

