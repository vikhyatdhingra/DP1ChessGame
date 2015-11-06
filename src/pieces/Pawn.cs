using System;

namespace ChessGame
{
	public class Pawn: ChessPiece
	{
		//Indicates whether the pawn is at its initial rank or not
		public bool _firstPawnMove;

		public Pawn (Grid initGrid, string player) :base(initGrid, player, "P") 
		{
			_firstPawnMove = true;
		}

		/// <summary>
		/// Checks if the capture rule applies to the destination grid
		/// </summary>
		/// <returns><c>true</c>if the grid is diagonally in front of this piece and contains a piece of different color<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		public bool CheckCaptureRule(Grid grid)
		{
			if (Math.Abs(grid.Y - this.Grid.Y) == 1)
			{
				if (this.Player == "B")
				{
					if (grid.X != this.Grid.X + 1)
						return false;
				}
				else
				{
					if (grid.X != this.Grid.X - 1)
						return false;
				}

				if (grid.Piece != null)
					return (CheckDestinationPieceColour(grid));
			}

			return false;
		}

		/// <summary>
		/// Checks if the first movement rule for pawns applies to the destination grid
		/// </summary>
		/// <returns><c>true</c>if the destination grid is within 2-grid range, and the path is clear<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		public bool CheckFirstMovementRule(Grid grid)
		{
			//Counts the distance to the chosen grid
			int offset = 0;


			if (this.Grid.Y == grid.Y)
			{

				if (Math.Abs (grid.X - this.Grid.X) > 2)
					return false;

				offset = grid.X - this.Grid.X;

				if (offset > 0)
				{
					if (grid.X <= this.Grid.X + offset && grid.X > this.Grid.X)
					{
						return (grid.Piece == null);
					}
				}
				else
				{
					if (grid.X >= this.Grid.X + offset && grid.X < this.Grid.X)
					{
						return (grid.Piece == null);
					}
				}
			}

			return (CheckCaptureRule (grid));
		}

		/// <summary>
		/// Checks if the rule for later movement of pawns applies to the destination grid
		/// </summary>
		/// <returns><c>true</c>if the destination grid is directly in front of this piece and is empty<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		public bool CheckLaterMovementRule(Grid grid)
		{
			if (this.Grid.Y == grid.Y)
			{
				if (this.Player == "B")
				{
					if (grid.X != this.Grid.X + 1)
						return false;
					return (grid.Piece == null);
				}
				else
				{
					if (grid.X != this.Grid.X - 1)
						return false;
					return (grid.Piece == null);
				}
			}
			return (CheckCaptureRule (grid));
		}

		/// <summary>
		/// Checks the movement rule of pawns to see if a grid can be moved to or not.
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			if (IsDestinationSameGrid (grid))
				return false;

			//Checks whether the pawn has been moved yet or is it still at its initial rank
			if (_firstPawnMove)
			{
				return (CheckFirstMovementRule (grid));
			}
			else
			{
				return (CheckLaterMovementRule (grid));
			}
		}

		/// <summary>
		/// Moves the piece
		/// </summary>
		/// <returns>The result message of the movement, returns null if the movement is successful</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
		public override string MovePiece(Grid grid, ChessBoard cb)
		{
			if (CheckMovementRule (grid, cb))
			{
				_firstPawnMove = false;
				this.Grid.RemovePiece ();
				grid.PlacePiece (this);
				return null;
			}

			return "Invalid move";
		}
	}
}

