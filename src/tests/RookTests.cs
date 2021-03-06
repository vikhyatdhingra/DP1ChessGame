using System;
using NUnit.Framework;

namespace ChessGame
{
	[TestFixture ()]
	public class RookTests
	{
		[Test()]
		public void TestHorizontalPathChecking()
		{
			ChessBoard cb = new ChessBoard ();
			Rook rk = new Rook (cb [3, 3], "B");
			cb [3, 3].PlacePiece (rk);
			//Test valid path
			Assert.IsTrue (rk.CheckHorizontal (cb[3, 6], cb));
			Assert.IsTrue (rk.CheckHorizontal (cb[3, 1], cb));

			//Test White piece path block
			cb [3, 2].PlacePiece (new Rook (cb [3, 2], "W"));
			Assert.IsFalse (rk.CheckHorizontal (cb[3, 1], cb));
			cb [3, 4].PlacePiece (new Rook (cb [3, 4], "W"));
			Assert.IsFalse (rk.CheckHorizontal (cb [3, 6], cb));

			//Test Black piece path block
			cb [3, 4].PlacePiece (new Rook (cb [3, 4], "B"));
			Assert.IsFalse (rk.CheckHorizontal (cb [3, 6], cb));
			cb [3, 2].PlacePiece (new Rook (cb [3, 2], "B"));
			Assert.IsFalse (rk.CheckHorizontal (cb[3, 1], cb));
		}
			
		[Test()]
		public void TestVerticalPathChecking()
		{
			ChessBoard cb = new ChessBoard ();
			Rook rk = new Rook (cb [3, 3], "B");
			cb [3, 3].PlacePiece (rk);

			//Test Valid path
			Assert.IsTrue (rk.CheckVertical (cb[6, 3], cb));
			Assert.IsTrue (rk.CheckVertical(cb[1, 3], cb));

			//Test White piece path block
			cb [2, 3].PlacePiece (new Rook (cb [2, 3], "W"));
			Assert.IsFalse (rk.CheckVertical (cb[1, 3], cb));
			cb [4, 3].PlacePiece (new Rook (cb [4, 3], "W"));
			Assert.IsFalse (rk.CheckVertical (cb [6, 3], cb));

			//Test Black piece path block
			cb [4, 3].PlacePiece (new Rook (cb [4, 3], "B"));
			Assert.IsFalse (rk.CheckVertical (cb [6, 3], cb));
			cb [2, 3].PlacePiece (new Rook (cb [2, 3], "B"));
			Assert.IsFalse (rk.CheckVertical (cb[1, 3], cb));
		}

		[Test()]
		public void TestCapture()
		{
			ChessBoard cb = new ChessBoard ();
			Rook rk = new Rook (cb [3, 3], "B");
			cb [3, 3].PlacePiece (rk);

			//Test capture failure - piece of the same color
			cb [2, 3].PlacePiece (new Rook (cb [2, 3], "B"));
			Assert.IsFalse (rk.CheckMovementRule (cb[2, 3], cb));
			cb [4, 3].PlacePiece (new Rook (cb [4, 3], "B"));
			Assert.IsFalse (rk.CheckMovementRule (cb [4, 3], cb));
			cb [3, 2].PlacePiece (new Rook (cb [3, 2], "B"));
			Assert.IsFalse (rk.CheckMovementRule (cb [3, 2], cb));
			cb [3, 4].PlacePiece (new Rook (cb [3, 4], "B"));
			Assert.IsFalse (rk.CheckMovementRule (cb[3, 4], cb));

			//Test capture failure - piece of different color
			cb [2, 3].PlacePiece (new Rook (cb [2, 3], "W"));
			Assert.IsTrue (rk.CheckMovementRule (cb[2, 3], cb));
			cb [4, 3].PlacePiece (new Rook (cb [4, 3], "W"));
			Assert.IsTrue (rk.CheckMovementRule (cb [4, 3], cb));
			cb [3, 2].PlacePiece (new Rook (cb [3, 2], "W"));
			Assert.IsTrue (rk.CheckMovementRule (cb [3, 2], cb));
			cb [3, 4].PlacePiece (new Rook (cb [3, 4], "W"));
			Assert.IsTrue (rk.CheckMovementRule (cb[3, 4], cb));
		}

		[Test ()]
		public void TestRookMovement ()
		{
			ChessBoard cb = new ChessBoard ();
			Rook rk = new Rook (cb [3, 1], "B");
			cb [3, 1].PlacePiece (rk);
			Assert.IsTrue(rk.CheckMovementRule (cb [4, 1], cb));
			Assert.IsFalse (rk.CheckMovementRule (cb [0, 3], cb));
			Assert.AreEqual (rk.MovePiece (cb [0, 3], cb), "Invalid move");
			Assert.AreNotSame (rk.Grid, cb [0, 3]);
			Assert.IsNull(rk.MovePiece (cb [4, 1], cb));
			Assert.AreSame (rk.Grid, cb [4, 1]);
		}
	}
}

