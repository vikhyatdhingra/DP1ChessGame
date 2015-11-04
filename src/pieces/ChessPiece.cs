using System;

namespace ChessGame
{
	public abstract class ChessPiece
	{
		private Grid _grid;
		private string _player;
		private string _name;
		private bool _isHighlighted;

		public ChessPiece (Grid initialGrid, string player, string name)
		{
			_grid = initialGrid;
			_player = player;
			_name = name;
			_isHighlighted = false;
		}

		public string Name
		{
			get
			{
				return _player + _name;
			}
		}

		public Grid Grid
		{
			get
			{
				return _grid;
			} set
			{
				_grid = value;
			}
		}

		public string Player
		{
			get
			{
				return _player;
			}
		}

		public bool CheckHorizontal(Grid grid, ChessBoard cb)
		{
			if (this.Grid.Y > grid.Y)
			{
				for (int i = this.Grid.Y - 1; i > grid.Y; i--)
				{
					if (cb [this.Grid.X, i].Piece != null)
					{
						return false;
					}
				}

				return true;
			}
			else
			{
				for (int i = this.Grid.X + 1; i < grid.X; i++)
				{
					if (cb [this.Grid.X, i].Piece != null)
					{
						return false;
					}
				}

				return true;
			}
		}

		public bool CheckVertical(Grid grid, ChessBoard cb)
		{
			if (this.Grid.X > grid.X)
			{
				for (int i = this.Grid.X - 1; i > grid.X; i--)
				{
					if (cb [i, this.Grid.Y].Piece != null)
					{
						return false;
					}
				}

				return true;
			}
			else
			{
				for (int i = this.Grid.Y + 1; i < grid.Y; i++)
				{
					if (cb [i, this.Grid.Y].Piece != null)
					{
						return false;
					}
				}

				return true;
			}
		}

		public bool CheckDiagonal(Grid grid, ChessBoard cb)
		{
			int offsetRow = 0;
			int offsetColumn = 0;
			int i = 0;
			int j = 0;

			if (grid.X < this.Grid.X)
			{
				i = this.Grid.X - 1;
				offsetRow = -1;
			}
			else
			{
				i = this.Grid.X + 1;
				offsetRow = 1;
			}

			if (grid.Y < this.Grid.Y)
			{
				j = this.Grid.Y - 1;
				offsetColumn = -1;
			}
			else
			{
				j = this.Grid.Y + 1;
				offsetColumn = 1;
			}

			while (i != grid.X)
			{
				if (cb [i, j].Piece != null)
					return false;
				i += offsetRow;
				j += offsetColumn;
			}

			return true;
		}

		public bool IsHighlighted
		{
			get
			{
				return _isHighlighted;
			}
			set
			{
				_isHighlighted = value;
			}
		}

		public abstract bool CheckMovementRule(Grid grid, ChessBoard cb);

		public bool IsDestinationSameGrid(Grid grid)
		{
			if (grid == this.Grid)
				return true;
			return false;
		}

		public bool CheckDestinationPieceColour(Grid grid)
		{
			if (grid.Piece != null)
			{
				if (this.Player == grid.Piece.Player)
				{
					return false;
				}
			}

			return true;
		}

		public virtual string MovePiece(Grid grid, ChessBoard cb)
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

