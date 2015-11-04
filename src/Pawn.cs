using System;

namespace ChessGame
{
	public class Pawn: ChessPiece
	{
		public bool firstPawnMove;

		public Pawn (Grid initGrid, string player) :base(initGrid, player, "P") 
		{
			firstPawnMove = true;
		}

		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			if (this.Grid == grid)
				return false;
			
			if (this.Player == "B")
			{
				if (firstPawnMove)
				{
					if (grid.Y <= this.Grid.Y + 2 && grid.Y > this.Grid.Y && this.Grid.X == grid.X)
					{
						firstPawnMove = false;
						return true;
					}
					else
					{
						//Console.WriteLine ("something");
						return false;
					}
				}else  
				{
					if (grid.Y == this.Grid.Y + 1 && this.Grid.X == grid.X)
					{
						return true;
					}
					else if (grid.Y == this.Grid.Y + 1 && (grid.X == this.Grid.X + 1 || grid.X == this.Grid.X - 1))
					{
						if (grid.Piece != null)
						{
							if (grid.Piece.Player != this.Player)
							{
								return true;
							}
							else
								return false;
						}
						else
							return false;
					}
					else
						return false;
				}
			} else
			{
				if (firstPawnMove)
				{
					if (grid.Y >= this.Grid.Y - 2 && grid.Y < this.Grid.Y && this.Grid.X == grid.X)
					{
						firstPawnMove = false;
						return true;
					}
					else
						return false;
				}else  
				{
					if (grid.Y == this.Grid.Y - 1 && this.Grid.X == grid.X)
					{
						return true;
					}
					else if (grid.Y == this.Grid.Y - 1 && (grid.X == this.Grid.X + 1 || grid.X == this.Grid.X - 1))
					{
						if (grid.Piece != null)
						{
							if (grid.Piece.Player != this.Player)
							{
								return true;
							}
							else
								return false;
						}
						else
							return false;
					}
					else
						return false;
				}
			}

		}

		public override string MovePiece(Grid grid, ChessBoard cb)
		{
			if (CheckMovementRule (grid, cb))
			{
				this.Grid.RemovePiece ();
				grid.PlacePiece (this);
				//this.Grid = grid;
				return null;
			}

			return "Invalid move";
		}
	}
}

