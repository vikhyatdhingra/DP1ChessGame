using System;

namespace ChessGame
{
	public abstract class ChessPiece
	{
		private Grid _currentGrid;

		public ChessPiece (Grid initialGrid)
		{
			_currentGrid = initialGrid;
		}

		public abstract bool CheckMovementRule(int gridX, int gridY);

		public abstract string MovePiece();
	}
}

