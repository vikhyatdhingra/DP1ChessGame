using System;

namespace ChessGame
{
	public abstract class ChessPiece
	{
		private Grid _grid;
		private string _player;
		private string _name;

		public ChessPiece (Grid initialGrid, string player, string name)
		{
			_grid = initialGrid;
			_player = player;
			_name = name;
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
		public abstract bool CheckMovementRule(Grid grid, ChessBoard cb);

		public abstract string MovePiece(Grid grid, ChessBoard cb);
	
	}
}

