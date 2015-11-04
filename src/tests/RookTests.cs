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
			Rook rk = new Rook (cb [3, 1], "B");
			cb [3, 1].PlacePiece (rk);
			Assert.IsTrue(rk.CheckMovementRule (cb [4, 1], cb));
			Assert.IsFalse (rk.CheckMovementRule (cb [0, 3], cb));
		}
	}
}

