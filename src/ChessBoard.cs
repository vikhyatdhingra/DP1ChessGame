using System;
using SwinGameSDK;

namespace ChessGame
{
	public class ChessBoard
	{
		//private int[][] gridCoordinates;
		//privaate grid[][] _grids;
		private float _x, _y;
		private Color _color;
		private int _width, _height;

		public ChessBoard ()
		{
			_color = Color.Black;
			_width = 75;
			_height = 75;
		}	

		//It draws the chessboard
		public void DrawGrid()
		{
			//X axis is kept static and Y axis is incremented. It draws a triange with base Y axis
			//In other words, have the chess board is drawn
			for (_x = 0; _x <= 600; _x += 75)
			{
				for (_y = _x; _y <= 600; _y += 150)
				{
					SwinGame.DrawRectangle (_color, _x, _y, _width, _height);
					SwinGame.FillRectangle (_color, _x, _y, _width, _height);
				}
			}

			// It draws the other half
			for (_y = 0; _y <= 600; _y += 75)
			{
				for (_x = _y; _x <= 600; _x += 150)
				{
					SwinGame.DrawRectangle (_color, _x, _y, _width, _height);
					SwinGame.FillRectangle (_color, _x, _y, _width, _height);
				}
			}
		}
	}
}

