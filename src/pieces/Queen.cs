using System;

namespace ChessGame
{
	public class Queen: ChessPiece 
	{
		public Queen (Grid initGrid, string player) :base(initGrid, player, "Q") 
		{
		}

		/// <summary>
		/// Checks the movement rule of queens to see if a grid can be moved to or not.
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
			
			//Checks the case of the destination grid.
			//The destination has to be either directly horizontal, vertical, or diagonal to the queen piece, else returns false
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

