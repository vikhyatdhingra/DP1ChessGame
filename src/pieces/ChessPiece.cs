using System;

namespace ChessGame
{
	public abstract class ChessPiece
	{
		//The grid the chess piece is currently on
		private Grid _grid;
		//A short string that indicates which player the piece belongs to
		private string _player;
		//The name of the piece
		private string _name;
		//Indicates whether the piece is being highlighted or not
		private bool _isHighlighted;

		public ChessPiece (Grid initialGrid, string player, string name)
		{
			_grid = initialGrid;
			_player = player;
			_name = name;
			_isHighlighted = false;
		}

		/// <summary>
		/// Gets the name of the piece, which consists of the _player string and _name string.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get
			{
				return _player + _name;
			}
		}

		/// <summary>
		/// Gets or sets the grid the piece is currently on.
		/// </summary>
		/// <value>The grid.</value>
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

		/// <summary>
		/// Gets the string that indicates which player the piece belongs to.
		/// </summary>
		/// <value>The player.</value>
		public string Player
		{
			get
			{
				return _player;
			}
		}

		/// <summary>
		/// Checks for existing piece on horizontal path
		/// </summary>
		/// <returns><c>true</c> if the path is clear<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
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
				for (int i = this.Grid.Y + 1; i < grid.Y; i++)
				{
					if (cb [this.Grid.X, i].Piece != null)
					{
						return false;
					}
				}

				return true;
			}
		}

		/// <summary>
		/// Checks for existing piece on vertical path
		/// </summary>
		/// <returns><c>true</c> if the path is clear<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
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
				for (int i = this.Grid.X + 1; i < grid.X; i++)
				{
					if (cb [i, this.Grid.Y].Piece != null)
					{
						return false;
					}
				}

				return true;
			}
		}

		/// <summary>
		/// Checks for existing piece on diagonal path
		/// </summary>
		/// <returns><c>true</c> if the path is clear<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
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

		/// <summary>
		/// Gets or sets the _isHighlighted field indicating whether this instance is highlighted.
		/// </summary>
		/// <value><c>true</c> if this instance is highlighted; otherwise, <c>false</c>.</value>
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

		/// <summary>
		/// Checks the movement rules to see if a grid can be moved to or not.
		/// </summary>
		/// <returns><c>true</c>movement to the destination grid is possible<c>false</c> otherwise.</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
		public abstract bool CheckMovementRule(Grid grid, ChessBoard cb);

		/// <summary>
		/// Determines whether the destination is same grid the as the current grid or not.
		/// </summary>
		/// <returns><c>true</c> if the destination is the same grid<c>false</c>.</returns>
		/// <param name="grid">The destination grid</param>
		public bool IsDestinationSameGrid(Grid grid)
		{
			if (grid == this.Grid)
				return true;
			return false;
		}

		/// <summary>
		/// Determines whether the piece on the destination grid has the same color or not.
		/// </summary>
		/// <returns><c>true</c> the destination grid is empty or has a piece of opposing color<c>false</c>.</returns>
		/// <param name="grid">The destination grid</param>
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

		/// <summary>
		/// Moves the piece
		/// </summary>
		/// <returns>The result message of the movement, returns null if the movement is successful</returns>
		/// <param name="grid">The destination grid</param>
		/// <param name="cb">the Chessboard currently used</param>
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

