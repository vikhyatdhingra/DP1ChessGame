using System;
using NUnit.Framework;

namespace ChessGame
{
	[TestFixture ()]
	public class RookTests
	{

		[Test ()]
		public void RookMovementTests ()
		{
			ChessBoard cb = new ChessBoard ();
			Rook rk = new Rook (cb [1, 3], "B");
			cb [1, 3].PlacePiece (rk);
			Assert.IsTrue(rk.CheckMovementRule (cb [1, 4], cb));
			Assert.IsFalse (rk.CheckMovementRule (cb [1, 0], cb));
		}
	}
}

