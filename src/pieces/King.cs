using System;

namespace ChessGame
{
	public class King: ChessPiece
	{
		public King (Grid initGrid, string player) :base(initGrid, player, "KG") 
		{
		}

		/// <summary>
		/// Checks the movement rule of kings to see if a grid can be moved to or not.
		/// </summary>
		/// <returns><c>true</c>movement to the destination grid is possible<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			if (!CheckDestinationPieceColour (grid))
				return false;
			if (IsDestinationSameGrid (grid))
				return false;
			//Checks if both of the X and Y coordinates of the destination is only less thab 1 unit different from the current grid
			if (Math.Abs (grid.X - this.Grid.X) <= 1 && Math.Abs (grid.Y - this.Grid.Y) <= 1)
				return true;
			return false;
		}
	}
}

