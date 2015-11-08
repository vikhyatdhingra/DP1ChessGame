using NUnit.Framework;
using System;

namespace ChessGame
{
	[TestFixture()]
	public class KnightTest
	{
		[Test()]
		public void TestKnightMovementOnEmpty ()
		{
			ChessBoard cb = new ChessBoard ();
			Knight kn = new Knight (cb [4, 4], "B");
			cb [4, 4].PlacePiece (kn);

			Assert.IsTrue(kn.CheckMovementRule(cb[6, 5], cb));
			Assert.IsTrue(kn.CheckMovementRule(cb[5, 6], cb));
			Assert.IsTrue(kn.CheckMovementRule(cb[3, 2], cb));
			Assert.IsTrue(kn.CheckMovementRule(cb[2, 3], cb));
			Assert.IsTrue(kn.CheckMovementRule(cb[3, 6], cb));
			Assert.IsTrue(kn.CheckMovementRule(cb[6, 3], cb));
			Assert.IsTrue(kn.CheckMovementRule(cb[2, 5], cb));
			Assert.IsTrue(kn.CheckMovementRule(cb[5, 2], cb));

			Assert.IsNull (kn.MovePiece (cb [5, 2], cb));
			Assert.AreEqual (kn.Grid, cb [5, 2]);
		}

		[Test()]
		public void TestKnightInvalidMovement()
		{
			ChessBoard cb = new ChessBoard ();
			Knight kn = new Knight (cb [4, 4], "B");
			cb [4, 4].PlacePiece (kn);

			Assert.IsFalse(kn.CheckMovementRule(cb[3,3], cb));
			Assert.IsFalse(kn.CheckMovementRule(cb[7,7], cb));
			Assert.IsFalse(kn.CheckMovementRule(cb[4, 3], cb));

			Assert.AreEqual (kn.MovePiece (cb [4, 3], cb), "Invalid move");
			Assert.AreNotSame (kn.Grid, cb [4, 3]);
			Assert.AreSame (kn.Grid, cb [4, 4]);
		}

		[Test()]
		public void TestKnightMovementOnGridWithAlliedPiece()
		{
			ChessBoard cb = new ChessBoard ();
			Knight kn = new Knight (cb [4, 4], "B");
			cb [4, 4].PlacePiece (kn);

			cb [6, 5].PlacePiece (new Knight (cb [6, 5], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[6, 5], cb));
			cb [5, 6].PlacePiece (new Knight (cb [5, 6], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[5, 6], cb));
			cb [3, 2].PlacePiece (new Knight (cb [3, 2], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[3, 2], cb));
			cb [2, 3].PlacePiece (new Knight (cb [2, 3], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[2, 3], cb));
			cb [3, 6].PlacePiece (new Knight (cb [3, 6], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[3, 6], cb));
			cb [6, 3].PlacePiece (new Knight (cb [6, 3], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[6, 3], cb));
			cb [2, 5].PlacePiece (new Knight (cb [2, 5], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[2, 5], cb));
			cb [5, 2].PlacePiece (new Knight (cb [5, 2], "B"));
			Assert.IsFalse(kn.CheckMovementRule(cb[5, 2], cb));
		}

		[Test()]
		public void TestKnightMovementOnGridWithEnemyPiece()
		{
			ChessBoard cb = new ChessBoard ();
			Knight kn = new Knight (cb [4, 4], "B");
			cb [4, 4].PlacePiece (kn);

			cb [6, 5].PlacePiece (new Knight (cb [6, 5], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[6, 5], cb));
			cb [5, 6].PlacePiece (new Knight (cb [5, 6], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[5, 6], cb));
			cb [3, 2].PlacePiece (new Knight (cb [3, 2], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[3, 2], cb));
			cb [2, 3].PlacePiece (new Knight (cb [2, 3], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[2, 3], cb));
			cb [3, 6].PlacePiece (new Knight (cb [3, 6], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[3, 6], cb));
			cb [6, 3].PlacePiece (new Knight (cb [6, 3], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[6, 3], cb));
			cb [2, 5].PlacePiece (new Knight (cb [2, 5], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[2, 5], cb));
			cb [5, 2].PlacePiece (new Knight (cb [5, 2], "W"));
			Assert.IsTrue(kn.CheckMovementRule(cb[5, 2], cb));
		}
	}
}

