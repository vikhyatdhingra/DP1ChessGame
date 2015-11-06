using System;

namespace ChessGame
{
	public class Bishop: ChessPiece
	{
		public Bishop (Grid initGrid, string player) :base(initGrid, player, "B")
		{
		}

		/// <summary>
		/// Checks the movement rules of bishops to see if a grid can be moved to or not.
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
			
			//Checks if the path is diagonal or not. Immediately returns false if invalid
			if (Math.Abs (grid.X - this.Grid.X) == Math.Abs (grid.Y - this.Grid.Y))
			{
				return CheckDiagonal (grid, cb);
			}
			else
				return false;				
		}


	}
}

