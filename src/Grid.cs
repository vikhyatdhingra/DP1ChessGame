using System;
using SwinGameSDK;

namespace ChessGame
{
	public class Grid
	{
		private ChessPiece _chessPiece = null;
		private Point2D _centerLocation;
		private Point2D _drawingLocation;
		private Color _color;
		private int _x;
		private int _y;
		private bool _isHighlighted;

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

		public void PlacePiece (ChessPiece piece)
		{
			_chessPiece = piece;
			_chessPiece.Grid = this;
		}

		public void RemovePiece ()
		{
			_chessPiece = null;
		}

		public int X
		{
			get
			{
				return _x;
			}
		}

		public int Y
		{
			get
			{
				return _y;
			}
		}

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

		public ChessPiece Piece
		{
			get
			{
				return _chessPiece;
			}
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

