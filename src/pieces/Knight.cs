using System;

namespace ChessGame
{
	public class Knight: ChessPiece
	{
		public Knight (Grid initGrid, string player): base(initGrid, player, "K")
		{
		}

		/// <summary>
		/// Checks the movement rules of knights to see if a grid can be moved to or not.
		/// </summary>
		///<returns><c>true</c>movement to the destination grid is possible<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
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

