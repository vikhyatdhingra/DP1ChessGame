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
			Pawn testPiece = new Pawn (cb [3, 1], "B");
			cb [3, 1].PlacePiece(testPiece);

			Assert.AreEqual (testPiece.MovePiece (cb [4, 2], cb), "Invalid move");
			Assert.IsNull (testPiece.MovePiece (cb [3, 2],cb));
			Assert.AreSame (testPiece.Grid, cb [3, 2]);
			Assert.IsNull (testPiece.MovePiece (cb [3, 3], cb));

			Pawn testPiece2 = new Pawn (cb [4, 4], "W");
			cb [4, 4].PlacePiece(testPiece2);
			Assert.IsNull (testPiece.MovePiece (cb [4, 4], cb));
		}

		[Test()]
		public void TestRule()
		{
			ChessBoard cb = new ChessBoard ();
			Pawn testPiece = new Pawn (cb [3, 1], "B");
			cb [3, 1].PlacePiece(testPiece);

			Assert.IsTrue (testPiece.CheckMovementRule (cb [3, 2], cb));
		}
	}
		
}

