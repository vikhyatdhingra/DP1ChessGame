using System;

namespace ChessGame
{
	public class Rook: ChessPiece
	{
		public Rook (Grid initGrid, string player): base(initGrid, player, "R")
		{
		}

		///Rook.grid/this.grid is the current position of the piece
		///grid passed in as parameter is the intended position
		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			if (grid.Piece != null)
			{
				if (this.Player == grid.Piece.Player)
				{
					return false;
				}
			}

			if (grid.X == this.Grid.X)
			{
				if (this.Grid.Y > grid.Y)
				{
					for (int i = this.Grid.Y; i > grid.Y; i--)
					{
						if (cb [i, this.Grid.Y].Piece != null)
						{
							return false;
						}
					}

					return true;
				}
				else if (this.Grid.Y < grid.Y)
				{
					for (int i = this.Grid.Y; i < grid.Y; i++)
					{
						if (cb [i, this.Grid.Y].Piece != null)
						{
							return false;
						}
					}
					return true;
				}
				else
					return false;
			}
			else if (grid.Y == this.Grid.Y)
			{
				if (this.Grid.X > grid.X)
				{
					for (int i = this.Grid.X; i > grid.X; i--)
					{
						if (cb [i, this.Grid.X].Piece != null)
						{
							return false;
						}
					}

					return true;
				}
				else if (this.Grid.X < grid.X)
				{
					for (int i = this.Grid.X; i < grid.X; i++)
					{
						if (cb [i, this.Grid.X].Piece != null)
						{
							return false;
						}
					}

					return true;
				}
				else
					return false;
			}
			else
			{
				return false;
			}	
		}


		public override string MovePiece(Grid grid, ChessBoard cb)
		{
			if (CheckMovementRule (grid, cb))
			{
				this.Grid.RemovePiece ();
				grid.PlacePiece (this);
				return null;
			}

			return "Invalid move";
		}
	}
}

