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

		public Grid (int x, int y, Color color)
		{
			_drawingLocation.X = x;
			_drawingLocation.Y = y;
			_centerLocation.X = x + 75 / 2;
			_centerLocation.Y = y + 75 / 2;
			_color = color;
		}

		public void PlacePiece (ChessPiece piece)
		{
			_chessPiece = piece;
		}

		public void RemovePiece ()
		{
			_chessPiece = null;
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

		}

	}
}

