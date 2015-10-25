using System;
using SwinGameSDK;

namespace ChessGame
{
	public class ChessBoard
	{
		private int _x = 0;
		private int _y = 0;
		private const int GRID_WIDTH = 75; 
		private const int GRID_HEIGHT = 75;
		private Grid[,] _grids = new Grid[8,8];

		public ChessBoard ()
		{
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
					_grids [i,j] = new Grid (_x, _y, i, j, color);
					_y += 75;

					if (_y == 600)
					{
						_y = 0;
					}
				}
				_x += 75;
				if (_x == 600)
				_x = 0;
			}

		}

		public void Initialize()
		{
			for (int i = 0; i < 8; i++)
			{
				_grids [i, 1].PlacePiece (new Pawn (_grids [i, 1], "B"));
			}

			for (int i = 0; i < 8; i++)
			{
				_grids [i, 6].PlacePiece (new Pawn (_grids [i, 6], "W"));
			}
		
			_grids [0, 0].PlacePiece (new Rook (_grids [0, 0], "B"));
			_grids [7, 0].PlacePiece (new Rook (_grids [7, 0], "B"));
			_grids [0, 7].PlacePiece (new Rook (_grids [0, 7], "W"));
			_grids [7, 7].PlacePiece (new Rook (_grids [7, 7], "W"));
			_grids [1, 0].PlacePiece (new Knight (_grids [1, 0], "B"));
			_grids [6, 0].PlacePiece (new Knight (_grids [6, 0], "B"));
			_grids [1, 7].PlacePiece (new Knight (_grids [1, 7], "W"));
			_grids [6, 7].PlacePiece (new Knight (_grids [6, 7], "W"));
			_grids [2, 0].PlacePiece (new Bishop (_grids [2, 0], "B"));
			_grids [5, 0].PlacePiece (new Bishop (_grids [5, 0], "B"));
			_grids [2, 7].PlacePiece (new Bishop (_grids [2, 7], "W"));
			_grids [5, 7].PlacePiece (new Bishop (_grids [5, 7], "W"));
			_grids [3, 0].PlacePiece (new Queen (_grids [2, 0], "B"));
			_grids [3, 7].PlacePiece (new Queen (_grids [2, 7], "W"));
			_grids [4, 0].PlacePiece (new King (_grids [5, 0], "B"));
			_grids [4, 7].PlacePiece (new King (_grids [5, 7], "W"));
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

		public Grid this[int i, int j]
		{
			get
			{
				return _grids [i, j];
			}
		}

	}
}

