using System;
using SwinGameSDK;

namespace ChessGame
{
	public class ChessBoard
	{
		//private int[][] gridCoordinates;
		private int _tempX = 0;
		private int _tempY = 0;
		//private Color _color;
		private const int GRID_WIDTH = 75; 
		private const int GRID_HEIGHT = 75;

		private Grid[,] _grids = new Grid[8,8];
		//private Point2D[,] _locations = new Point2D[8,8];

		public ChessBoard ()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{

					Console.Write (_tempX);
					Console.WriteLine (_tempY);

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

					_grids [i,j] = new Grid (_tempX, _tempY, color);

					_tempY += 75;
					if (_tempY == 600)
						_tempY = 0;
				}
				_tempX += 75;
				if (_tempX == 600)
					_tempX = 0;
			}

		}

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

		/*
		//It draws the chessboard
		public void DrawGrid()
		{
			//X axis is kept static and Y axis is incremented. It draws a triange with base Y axis
			//In other words, have the chess board is drawn
			for (_x = 0; _x <= 600; _x += 75)
			{
				for (_y = _x; _y <= 600; _y += 150)
				{
					
			`		SwinGame.DrawRectangle (_color, _x, _y, _width, _height);
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
		}*/
	}
}

