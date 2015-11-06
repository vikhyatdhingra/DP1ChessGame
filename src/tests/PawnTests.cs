using NUnit.Framework;
using System;

namespace ChessGame
{
	[TestFixture ()]
	public class PawnTests
	{
		[Test ()]
		public void TestBlackPawnMovement ()
		{
			ChessBoard cb = new ChessBoard ();
			Pawn testPiece = new Pawn (cb [1, 3], "B");
			cb [1, 3].PlacePiece(testPiece);

			Assert.AreEqual (testPiece.MovePiece (cb [2, 4], cb), "Invalid move");
			Assert.AreSame (testPiece.Grid, cb [1, 3]);
			Assert.IsNull (testPiece.MovePiece (cb [3, 3],cb));
			Assert.AreSame (testPiece.Grid, cb [3, 3]);
			Assert.IsNull (testPiece.MovePiece (cb [4, 3], cb));

			//Pawn cannot move 2 grids after its initial movement
			Assert.AreEqual (testPiece.MovePiece (cb [6, 3], cb), "Invalid move");
			Assert.AreSame (testPiece.Grid, cb [4, 3]);
		}

		[Test()]
		public void TestWhitePawnMovement()
		{
			ChessBoard cb = new ChessBoard ();
			Pawn testPiece = new Pawn (cb [6,6], "W");
			cb [6,6].PlacePiece(testPiece);

			Assert.AreEqual (testPiece.MovePiece (cb [4, 2], cb), "Invalid move");
			Assert.IsNull (testPiece.MovePiece (cb [4, 6],cb));
			Assert.AreSame (testPiece.Grid, cb [4, 6]);
			Assert.IsNull (testPiece.MovePiece (cb [3, 6], cb));

			//Pawn cannot move 2 grids after its initial movement
			Assert.AreEqual (testPiece.MovePiece (cb [1, 6], cb), "Invalid move");
			Assert.AreSame (testPiece.Grid, cb [3, 6]);
		}

		[Test()]
		public void TestBlackCaptureRule()
		{
			ChessBoard cb = new ChessBoard ();
			Pawn testPiece = new Pawn (cb [3, 2], "B");
			cb [3, 2].PlacePiece(testPiece);
			cb [4, 3].PlacePiece (new Pawn (cb [4, 3], "W"));
			cb [4, 2].PlacePiece (new Pawn (cb [4, 2], "B"));

			Assert.IsFalse (testPiece.CheckMovementRule (cb [4, 2], cb));
			Assert.IsTrue (testPiece.CheckMovementRule (cb [4, 3], cb));
		}

		[Test()]
		public void TestWhiteCaptureRule()
		{
			ChessBoard cb = new ChessBoard ();
			Pawn testPiece = new Pawn (cb [6,6], "W");
			cb [6, 6].PlacePiece(testPiece);
			cb [5,5].PlacePiece (new Pawn (cb [4, 3], "W"));
			cb [5, 7].PlacePiece (new Pawn (cb [4, 2], "B"));

			Assert.IsTrue (testPiece.CheckMovementRule (cb [5, 7], cb));
			Assert.IsFalse (testPiece.CheckMovementRule (cb [5, 5], cb));
		}
	}
		
}

