using System;
using SwinGameSDK;

namespace ChessGame
{
	public class Grid
	{
		//The piece currently on the grid
		private ChessPiece _chessPiece = null;

		//The location for drawing the piece representation. This is calculated from the drawing location
		private Point2D _centerLocation;

		//The location for drawing the grid itself
		private Point2D _drawingLocation;

		//The color of the grid
		private Color _color;

		//The indexes of the grid on the chessboard
		private int _x;
		private int _y;

		//Indicates whether this grid is highlighted or not
		private bool _isHighlighted;

		/// <summary>
		/// Initializes a new instance of the <see cref="ChessGame.Grid"/> class.
		/// </summary>
		/// <param name="x">The x coordinate for drawing.</param>
		/// <param name="y">The y coordinate for drawing.</param>
		/// <param name="indexX">Row index.</param>
		/// <param name="indexY">Column Index.</param>
		/// <param name="color">Color.</param>
		public Grid (int x, int y, int indexX, int indexY, Color color)
		{ 
			_x = indexX;
			_y = indexY;
			_drawingLocation.X = x;
			_drawingLocation.Y = y;
			_centerLocation.X = x + 75 / 2 - 8;
			_centerLocation.Y = y + 75 / 2 - 8;
			_color = color;
			_isHighlighted = false;
		}

		/// <summary>
		/// Places a chess piece onto the grid
		/// </summary>
		/// <param name="piece">A ChessPiece object</param>
		public void PlacePiece (ChessPiece piece)
		{
			_chessPiece = piece;
			_chessPiece.Grid = this;
		}

		/// <summary>
		/// Removes the current piece from the grid.
		/// </summary>
		public void RemovePiece ()
		{
			_chessPiece = null;
		}

		/// <summary>
		/// Gets the row index.
		/// </summary>
		/// <value>The row index</value>
		public int X
		{
			get
			{
				return _x;
			}
		}

		/// <summary>
		/// Gets the column index.
		/// </summary>
		/// <value>The column index</value>
		public int Y
		{
			get
			{
				return _y;
			}
		}

		/// <summary>
		/// Gets the current piece on the grid.
		/// </summary>
		/// <value>The piece.</value>
		public ChessPiece Piece
		{
			get
			{
				return _chessPiece;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this grid is highlighted.
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
		/// Draws the grid
		/// </summary>
		public void DrawGrid()
		{
			if (_color == Color.Black)
			{
				SwinGame.FillRectangle (_color, _drawingLocation.X, _drawingLocation.Y, 75, 75);
			}
			else
			{
				SwinGame.DrawRectangle (Color.Black, _drawingLocation.X, _drawingLocation.Y, 75, 75);
			}

			if (IsHighlighted)
			{
				SwinGame.FillRectangle (Color.DarkGreen, _drawingLocation.X + 2, _drawingLocation.Y + 2, 71, 71);
			}

			DrawPiece ();
		}


		/// <summary>
		/// Draws the piece currently on the grid.
		/// </summary>
		public void DrawPiece()
		{
			if (_chessPiece != null)
			{
				if (_chessPiece.Player == "B")
				{
					if (_chessPiece.IsHighlighted)
					{
						SwinGame.DrawText (_chessPiece.Name, Color.Green, LoadResources._font, _centerLocation);
					} else
					{
						SwinGame.DrawText (_chessPiece.Name, Color.Red, LoadResources._font, _centerLocation);
					}
				}
				else
				{
					if (_chessPiece.IsHighlighted)
					{
						SwinGame.DrawText (_chessPiece.Name, Color.Green, LoadResources._font, _centerLocation);
					}
					else
					{
						SwinGame.DrawText (_chessPiece.Name, Color.Blue, LoadResources._font, _centerLocation);	
					}
				}
			}
		}


	}
}

