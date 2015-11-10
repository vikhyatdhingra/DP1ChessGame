using NUnit.Framework;
using System;

namespace ChessGame
{
	[TestFixture()]
	public class QueenTest
	{
		[Test()]
		public void TestQueenMovement ()
		{
			ChessBoard cb = new ChessBoard ();
			Queen qn = new Queen (cb [4, 4], "B");
			cb [4, 4].PlacePiece (qn);

			//All possible movement directions
			Assert.IsTrue (qn.CheckMovementRule (cb [5, 4], cb));
			Assert.IsTrue (qn.CheckMovementRule (cb [5, 5], cb));
			Assert.IsTrue (qn.CheckMovementRule (cb [4, 5], cb));
			Assert.IsTrue (qn.CheckMovementRule (cb [3, 3], cb));
			Assert.IsTrue (qn.CheckMovementRule (cb [4, 3], cb));
			Assert.IsTrue (qn.CheckMovementRule (cb [3, 4], cb));
			Assert.IsTrue (qn.CheckMovementRule (cb [3, 5], cb));
			Assert.IsTrue (qn.CheckMovementRule (cb [5, 3], cb));

			//Same position
			Assert.IsFalse (qn.CheckMovementRule (cb [4, 4], cb));

			//Other not pssible moves
			Assert.IsFalse (qn.CheckMovementRule (cb [6, 5], cb));
			Assert.IsFalse (qn.CheckMovementRule (cb [5, 6], cb));
		}
	}
}

