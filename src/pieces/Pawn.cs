using System;

namespace ChessGame
{
	public class Pawn: ChessPiece
	{
		public bool _firstPawnMove;

		public Pawn (Grid initGrid, string player) :base(initGrid, player, "P") 
		{
			_firstPawnMove = true;
		}

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

		public bool CheckFirstMovementRule(Grid grid)
		{
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


		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			if (IsDestinationSameGrid (grid))
				return false;
			
			if (_firstPawnMove)
			{
				return (CheckFirstMovementRule (grid));
			}
			else
			{
				return (CheckLaterMovementRule (grid));
			}
		}

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

