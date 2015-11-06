using NUnit.Framework;
using System;

namespace ChessGame
{
	[TestFixture()]
	public class BishopTest
	{
		[Test()]
		public void TestPathCheck ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop bsh = new Bishop (cb [4, 4], "B");
			cb [4, 4].PlacePiece (bsh);

			Assert.IsTrue (bsh.CheckDiagonal (cb [1, 1], cb));
			Assert.IsTrue (bsh.CheckDiagonal (cb [6, 6], cb));
			Assert.IsTrue (bsh.CheckDiagonal (cb [2, 6], cb));
			Assert.IsTrue (bsh.CheckDiagonal (cb [6, 2], cb));
		}

		[Test()]
		public void TestPathBlock()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop bsh = new Bishop (cb [4, 4], "B");
			cb [4, 4].PlacePiece (bsh);

			//Create obstructions
			cb [3, 3].PlacePiece (new Bishop(cb[3, 3], "B"));
			cb [5, 5].PlacePiece (new Bishop(cb[5, 5], "B"));
			cb [3, 5].PlacePiece (new Bishop(cb[3, 5], "W"));
			cb [5, 3].PlacePiece (new Bishop(cb[5, 3], "W"));

			Assert.IsFalse (bsh.CheckDiagonal (cb [1, 1], cb));
			Assert.IsFalse(bsh.CheckDiagonal (cb [6, 6], cb));
			Assert.IsFalse (bsh.CheckDiagonal (cb [2, 6], cb));
			Assert.IsFalse (bsh.CheckDiagonal (cb [6, 2], cb));
		}

		[Test()]
		public void TestCapturePossibility()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop bsh = new Bishop (cb [4, 4], "B");
			cb [4, 4].PlacePiece (bsh);

			//Check attempt to capture same color piece
			cb [1, 1].PlacePiece (new Bishop(cb[1, 1], "B"));
			cb [6, 6].PlacePiece (new Bishop(cb[6, 6], "B"));
			cb [2, 6].PlacePiece (new Bishop(cb[2, 6], "B"));
			cb [6, 2].PlacePiece (new Bishop(cb[6, 2], "B"));
			Assert.IsFalse (bsh.CheckMovementRule (cb [1, 1], cb));
			Assert.IsFalse(bsh.CheckMovementRule (cb [6, 6], cb));
			Assert.IsFalse (bsh.CheckMovementRule (cb [2, 6], cb));
			Assert.IsFalse (bsh.CheckMovementRule (cb [6, 2], cb));

			//Check attempt to capture different color piece
			cb [1, 1].PlacePiece (new Bishop(cb[1, 1], "W"));
			cb [6, 6].PlacePiece (new Bishop(cb[6, 6], "W"));
			cb [2, 6].PlacePiece (new Bishop(cb[2, 6], "W"));
			cb [6, 2].PlacePiece (new Bishop(cb[6, 2], "W"));
			Assert.IsTrue (bsh.CheckMovementRule (cb [1, 1], cb));
			Assert.IsTrue(bsh.CheckMovementRule (cb [6, 6], cb));
			Assert.IsTrue (bsh.CheckMovementRule (cb [2, 6], cb));
			Assert.IsTrue (bsh.CheckMovementRule (cb [6, 2], cb));
		}

		[Test()]
		public void TestMovement()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop bsh = new Bishop (cb [4, 4], "B");
			cb [4, 4].PlacePiece (bsh);

			//Test correct movement
			Assert.IsTrue(bsh.CheckMovementRule (cb [6, 6], cb));
			Assert.IsNull (bsh.MovePiece (cb [6, 6], cb));
			Assert.AreSame (bsh.Grid, cb [6, 6]);

			//Test invalid movement
			Assert.IsFalse (bsh.CheckMovementRule (cb[4, 3], cb));
			Assert.AreEqual (bsh.MovePiece (cb [4, 3], cb), "Invalid move");
			Assert.AreSame (bsh.Grid, cb [6, 6]);
		}
	}
}

