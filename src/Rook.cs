using System;

namespace ChessGame
{
	public class Rook: ChessPiece
	{
		public Rook (Grid initGrid, string player): base(initGrid, player, "R")
		{
		}

		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			if (grid.X == this.Grid.X)
			{
				if (this.Grid.Y > grid.Y)
				{
					for (int old = this.Grid.Y; old > grid.Y; old--)
					{
						if (cb [old, this.Grid.Y].Piece != null)
						{
							return false;
						}
					}

					if (this.Player == grid.Piece.Player)
					{
						return false;
					}

					return true;
				}
				else if (this.Grid.Y > grid.Y)
				{
					for (int old = this.Grid.Y; old < grid.Y; old++)
					{
						if (cb [old, this.Grid.Y].Piece != null)
						{
							return false;
						}
					}
					if (this.Player == grid.Piece.Player)
					{
						return false;
					}
				}
			}
			else if (grid.Y == this.Grid.Y)
				return true;
			else
			{
				return false;
			}
			return false;
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

