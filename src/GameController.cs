using System;
using SwinGameSDK;

namespace ChessGame
{
	public static class GameController
	{


		//The current state of the game
		private static GameState _state;
		//The chess piece that is currently chosen
		private static ChessPiece _currentPiece;
		//The board currently handled by the Controller
		private static ChessBoard _board;

		/// <summary>
		/// Loads the game.
		/// </summary>
		public static void LoadGame()
		{
			ChessBoard cb = new ChessBoard ();
			cb.Initialize();
			_board = cb;
			_state = GameState.WhiteChoose;
		}

		/// <summary>
		/// Determines the method for handling user input based on the current game state.
		/// </summary>
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

		/// <summary>
		/// Handles the player's input for choosing which piece to move.
		/// </summary>
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

		/// <summary>
		/// Handles the player's input for moving the chosen piece.
		/// </summary>
		public static void HandleMovement()
		{
			_board.HighlightPath (_currentPiece);
			_currentPiece.IsHighlighted = true;

			if (SwinGame.MouseClicked (MouseButton.LeftButton))
			{
				Grid grid = MouseToGrid ();
				string result = _currentPiece.MovePiece (grid, _board);

				if (result == null)
				{
					if (_state == GameState.WhiteMove)
					{
						_board.RemovePathHighLight ();
						_currentPiece.IsHighlighted = false;
						_currentPiece = null;
						_state = GameState.BlackChoose;
						return;
					}
					else
					{
						_board.RemovePathHighLight ();
						_currentPiece.IsHighlighted = false;
						_currentPiece = null;
						_state = GameState.WhiteChoose;
						return;
					}
				}
			}

			//Removes piece selection and returns to the Choosing phase	
			if (SwinGame.MouseClicked (MouseButton.RightButton))
			{
				if (_state == GameState.WhiteMove)
				{
					_board.RemovePathHighLight ();
					_currentPiece.IsHighlighted = false;
					_currentPiece = null;
					_state = GameState.WhiteChoose;
					return;
				}
				else
				{
					_board.RemovePathHighLight ();
					_currentPiece.IsHighlighted = false;
					_currentPiece = null;
					_state = GameState.BlackChoose;
					return;
				}
			}
				
		}

		/// <summary>
		/// Draws the game.
		/// </summary>
		public static void DrawGame()
		{
			_board.DrawBoard ();
			PrintMessage ();
		}

		/// <summary>
		/// Prints the message.
		/// </summary>
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

