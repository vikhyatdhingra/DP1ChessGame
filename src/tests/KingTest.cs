using NUnit.Framework;
using System;

namespace ChessGame
{
	[TestFixture()]
	public class KingTest
	{
		[Test()]
		public void TestKingMovementRuleOnEmptyGrids ()
		{
			ChessBoard cb = new ChessBoard ();
			King kg = new King (cb [4, 4], "B");
			cb [4, 4].PlacePiece (kg);

			//Check all possible movements
			Assert.IsTrue (kg.CheckMovementRule (cb [5, 4], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [5, 5], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [5, 3], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [4, 3], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [4, 5], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [3, 3], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [3, 4], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [3, 5], cb));

			//Check some invalid movements
			Assert.IsFalse (kg.CheckMovementRule (cb [6, 6], cb));
			Assert.IsFalse (kg.CheckMovementRule (cb [4, 6], cb));
			Assert.IsFalse (kg.CheckMovementRule (cb [6, 4], cb));
		}

		[Test()]
		public void TestKingCaptureRule()
		{
			ChessBoard cb = new ChessBoard ();
			King kg = new King (cb [4, 4], "B");
			cb [4, 4].PlacePiece (kg);

			//Create piece cases within range
			cb[5, 4].PlacePiece(new King(cb[5, 4], "B"));
			cb [5, 5].PlacePiece (new King (cb [5, 5], "W"));

			//Check whether the pieces can be captured or not.
			Assert.IsFalse(kg.CheckMovementRule(cb[5,4], cb));
			Assert.IsTrue (kg.CheckMovementRule (cb [5, 5], cb));
		}

		[Test()]
		public void TestKingMovement()
		{
			ChessBoard cb = new ChessBoard ();
			King kg = new King (cb [4, 4], "B");
			cb [4, 4].PlacePiece (kg);

			//Test invalid movement
			Assert.IsFalse(kg.CheckMovementRule(cb[6,7], cb));
			Assert.AreEqual(kg.MovePiece(cb[6, 7], cb), "Invalid move");
			Assert.AreSame (kg.Grid, cb [4, 4]);

			//Test valid movement
			Assert.IsTrue (kg.CheckMovementRule (cb [3, 5], cb));
			Assert.IsNull (kg.MovePiece (cb [3, 5], cb));
			Assert.AreSame (kg.Grid, cb [3, 5]);
		}
	}
}

