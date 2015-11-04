using NUnit.Framework;
using System;

namespace ChessGame
{
	[TestFixture ()]
	public class PawnTests
	{
		[Test ()]
		public void TestMovement ()
		{
			ChessBoard cb = new ChessBoard ();
			Pawn testPiece = new Pawn (cb [1, 3], "B");
			cb [1, 3].PlacePiece(testPiece);

			Assert.AreEqual (testPiece.MovePiece (cb [2, 4], cb), "Invalid move");
			Assert.IsNull (testPiece.MovePiece (cb [3, 3],cb));
			Assert.AreSame (testPiece.Grid, cb [3, 3]);
			Assert.IsNull (testPiece.MovePiece (cb [4, 3], cb));
			Assert.AreEqual (testPiece.MovePiece (cb [6, 3], cb), "Invalid move");
		}

		[Test()]
		public void TestMovementRule()
		{
			ChessBoard cb = new ChessBoard ();
			Pawn testPiece = new Pawn (cb [3, 2], "B");
			cb [3, 2].PlacePiece(testPiece);

			Assert.IsFalse (testPiece.CheckMovementRule (cb [3, 2], cb));
		}
	}
		
}

