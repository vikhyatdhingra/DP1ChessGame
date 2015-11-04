using System;
using SwinGameSDK;

namespace ChessGame
{
	public static class GameController
	{
		private static GameState _state;
		private static ChessPiece _currentPiece;
		private static ChessBoard _board;

		public static void LoadGame()
		{
			ChessBoard cb = new ChessBoard ();
			cb.Initialize();
			_board = cb;
			_state = GameState.WhiteChoose;
		}

		public static void HandleGameInput()
		{
			switch (_state)
			{
			case GameState.WhiteMove:
				HandleMovement ();
				break;
			case GameState.WhiteChoose:
				HandleChoice ();
				break;
			case GameState.BlackMove:
				HandleMovement ();
				break;
			case GameState.BlackChoose:
				HandleChoice ();
				break;
			}
		}

		public static void HandleChoice()
		{
			if(SwinGame.MouseClicked(MouseButton.LeftButton))
			{
				Grid grid = MouseToGrid ();
				if (grid.Piece == null)
				{
					return;
				}
					
				if (_state == GameState.WhiteChoose)
				{
					if (grid.Piece.Player == "W")
					{
						_currentPiece = grid.Piece;
						_state = GameState.WhiteMove;
						return;
					}
				}
				else
				{
					if (grid.Piece.Player == "B")
					{
						_currentPiece = grid.Piece;
						_state = GameState.BlackMove;
						return;
					}
				}
			}
		}

		/// <summary>
		/// Changes Mouse Coordinates to Grid Indexes
		//and gets the Grid
		/// </summary>
		/// <returns>The to grid.</returns>
		public static Grid MouseToGrid()
		{
			int row = 0;
			int col = 0;

			//translates the X and Y coordinates of 
			row = (int)Math.Floor (SwinGame.MouseY() / 75);
			col = (int)Math.Floor (SwinGame.MouseX() / 75);

			return _board [row, col];
		}


		public static void HandleMovement()
		{
			_currentPiece.IsHighlighted = true;
			if (SwinGame.MouseClicked (MouseButton.LeftButton))
			{
				Grid grid = MouseToGrid ();
				string result = _currentPiece.MovePiece (grid, _board);

				if (result == null)
				{
					if (_state == GameState.WhiteMove)
					{
						_currentPiece.IsHighlighted = false;
						_currentPiece = null;
						_state = GameState.BlackChoose;
						return;
					}
					else
					{
						_currentPiece.IsHighlighted = false;
						_currentPiece = null;
						_state = GameState.WhiteChoose;
						return;
					}
				}
			}

			if (SwinGame.MouseClicked (MouseButton.RightButton))
			{
				if (_state == GameState.WhiteMove)
				{
					_currentPiece.IsHighlighted = false;
					_currentPiece = null;
					_state = GameState.WhiteChoose;
					return;
				}
				else
				{
					_currentPiece.IsHighlighted = false;
					_currentPiece = null;
					_state = GameState.BlackChoose;
					return;
				}
			}
				
		}

		public static void DrawGame()
		{
			_board.DrawBoard ();
			PrintMessage ();
		}

		public static void PrintMessage()
		{
			SwinGame.DrawText (_state.ToString(), Color.Red, 300,300);
			//Console.WriteLine (_state.ToString ());
			if (_currentPiece != null)
			{
				//Console.WriteLine (_currentPiece.Name);
				SwinGame.DrawText (_currentPiece.Name, Color.Red, 300, 350);
			}
		}
	}
}

