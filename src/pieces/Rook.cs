using System;

namespace ChessGame
{
	public class Rook: ChessPiece
	{
		public Rook (Grid initGrid, string player): base(initGrid, player, "R")
		{
		}

		///Rook.grid/this.grid is the current position of the piece
		///grid passed in as parameter is the intended position
		public override bool CheckMovementRule(Grid grid, ChessBoard cb)
		{
			if (!CheckDestinationPieceColour (grid))
				return false;
			if (IsDestinationSameGrid (grid))
				return false;
			
			if (grid.Y == this.Grid.Y)
			{
				return CheckVertical (grid, cb);
			}
			else if (grid.X == this.Grid.X)
			{
				return CheckHorizontal (grid, cb);
			}
			else
			{
				return false;
			}	
		}


	}
}

