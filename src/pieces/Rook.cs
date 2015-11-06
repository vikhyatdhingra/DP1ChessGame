using System;

namespace ChessGame
{
	public class Rook: ChessPiece
	{
		public Rook (Grid initGrid, string player): base(initGrid, player, "R")
		{
		}

		/// <summary>
		/// Checks the movement rule of rooks to see if a grid can be moved to or not.
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

			//The path is vertical
			if (grid.Y == this.Grid.Y)
			{
				return CheckVertical (grid, cb);
			}
			//The path is horizontal
			else if (grid.X == this.Grid.X)
			{
				return CheckHorizontal (grid, cb);
			}
			//The path is invalid
			else
			{
				return false;
			}	
		}


	}
}

