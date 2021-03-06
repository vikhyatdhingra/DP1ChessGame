using NUnit.Framework;
using System;

namespace ChessGame
{
	[TestFixture ()]
	public class TestChessPiece
	{
		[Test ()]
		public void TestPieceName ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop cpb = new Bishop (cb [4, 4], "B");
			King cpk = new King (cb [3, 3], "W");

			Assert.AreEqual ("BB", cpb.Name);
			Assert.AreEqual ("WKG", cpk.Name);
		}

		[Test ()]
		public void TestPieceGrid ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop cpb = new Bishop (cb [4, 4], "B");
			King cpk = new King (cb [3, 3], "W");

			cpk.MovePiece(cb[3, 4], cb);
			cpk.MovePiece(cb[6, 6], cb);

			Assert.AreEqual (cb[4, 4], cpb.Grid);
			Assert.AreEqual (cb[3, 4], cpk.Grid);
		}

		[Test ()]
		public void TestPiecePlayer ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop cpb = new Bishop (cb [4, 4], "B");
			King cpk = new King (cb [3, 3], "W");

			Assert.AreEqual ("B", cpb.Player);
			Assert.AreEqual ("W", cpk.Player);
		}
			

		[Test ()]
		public void TestPieceHorizontalPath ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop cpb = new Bishop (cb [4, 4], "B");
			King cpk = new King (cb [3, 3], "W");

			Assert.IsTrue (cpb.CheckHorizontal(cb[3, 2], cb));
			Assert.IsTrue (cpk.CheckHorizontal(cb[0, 0], cb));
		}


		[Test ()]
		public void TestPieceVerticalPath ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop cpb = new Bishop (cb [4, 4], "B");
			King cpk = new King (cb [3, 3], "W");

			Assert.IsTrue (cpb.CheckHorizontal(cb[3, 2], cb));
			Assert.IsTrue (cpk.CheckVertical(cb[0, 0], cb));
		}

		[Test ()]
		public void TestIfDestinationIsSameGrid ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop cpb = new Bishop (cb [4, 4], "B");

			Assert.IsTrue (cpb.IsDestinationSameGrid(cb[4, 4]));
			Assert.IsFalse (cpb.IsDestinationSameGrid(cb[4, 5]));
		}

		[Test ()]
		public void TestIfPieceisMoved ()
		{
			ChessBoard cb = new ChessBoard ();
			Bishop cpb = new Bishop (cb [4, 4], "B");
			cpb.MovePiece (cb [5, 5], cb);

			Assert.AreEqual (cb [5, 5], cpb.Grid);

		}

	

	}
}

