using System;
using SwinGameSDK;

namespace ChessGame
{
	public class ChessBoard
	{
		// The dimensions of each grid
		private const int GRID_WIDTH = 75; 
		private const int GRID_HEIGHT = 75;

		// A grid array used for storing the grids on the chessboard
		private Grid[,] _grids = new Grid[8,8];

		/// <summary>
		/// Initializes a new instance of the <see cref="ChessGame.ChessBoard"/> class.
		/// </summary>
		public ChessBoard ()
		{
			int x = 0;
			int y = 0;

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Color color = Color.Black;
					if ((i % 2 == 0) || (j % 2 == 0))
					{
						if ((i % 2 == 0) && (j % 2 == 0))
						{
							color = Color.Black;
						}
						else
						{
							color = Color.White;
						}
					}

					_grids [i,j] = new Grid (x, y, i, j, color);

					x += 75;
					if (x == 600)
						x = 0;
				}
				y += 75;
				if (y == 600)
					y = 0;
			}

		}

		/// <summary>
		/// Highlights the path possible for a chess piece.
		/// </summary>
		/// <param name="piece">The chess piece whose path needs to be highlighted</param>
		public void HighlightPath(ChessPiece piece) 
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (piece.CheckMovementRule(_grids[i,j], this))
						_grids [i, j].IsHighlighted = true;
				}
			} 
		}

		/// <summary>
		/// Removes the path highlight.
		/// </summary>
		public void RemovePathHighLight()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					_grids [i, j].IsHighlighted = false;
				}
			} 
		}

		/// <summary>
		/// Sets up the initial board
		/// </summary>
		public void Initialize()
		{
			for (int i = 0; i < 8; i++)
			{
				_grids [1, i].PlacePiece (new Pawn (_grids [1, i], "B"));
			}

			for (int i = 0; i < 8; i++)
			{
				_grids [6, i].PlacePiece (new Pawn (_grids [6, i], "W"));
			}
		
			_grids [0, 0].PlacePiece (new Rook (_grids [0, 0], "B"));
			_grids [7, 0].PlacePiece (new Rook (_grids [7, 0], "W"));
			_grids [0, 7].PlacePiece (new Rook (_grids [0, 7], "B"));
			_grids [7, 7].PlacePiece (new Rook (_grids [7, 7], "W"));
			_grids [0, 1].PlacePiece (new Knight (_grids [0, 1], "B"));
			_grids [0, 6].PlacePiece (new Knight (_grids [0, 6], "B"));
			_grids [7, 1].PlacePiece (new Knight (_grids [7, 1], "W"));
			_grids [7, 6].PlacePiece (new Knight (_grids [7, 6], "W"));
			_grids [0, 2].PlacePiece (new Bishop (_grids [0, 2], "B"));
			_grids [0, 5].PlacePiece (new Bishop (_grids [0, 5], "B"));
			_grids [7, 2].PlacePiece (new Bishop (_grids [7, 2], "W"));
			_grids [7, 5].PlacePiece (new Bishop (_grids [7, 5], "W"));
			_grids [0, 3].PlacePiece (new Queen (_grids [0, 3], "B"));
			_grids [7, 3].PlacePiece (new Queen (_grids [7, 3], "W"));
			_grids [0, 4].PlacePiece (new King (_grids [0, 4], "B"));
			_grids [7, 4].PlacePiece (new King (_grids [7, 4], "W"));
		}

		/// <summary>
		/// Draws the board.
		/// </summary>
		public void DrawBoard()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					_grids [i, j].DrawGrid ();
				}
			}
		}

		/// <summary>
		/// Gets the <see cref="ChessGame.ChessBoard"/> with the specified row and col indexes.
		/// </summary>
		/// <param name="i">The row index.</param>
		/// <param name="j">The column index.</param>
		public Grid this[int i, int j]
		{
			get
			{
				return _grids [i, j];
			}
		}
	}
}

