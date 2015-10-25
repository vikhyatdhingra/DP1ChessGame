using System;
using SwinGameSDK;

namespace ChessGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 600, 600);
			ChessBoard cb = new ChessBoard ();
			LoadResources.LoadFont ();
			//Pawn testPiece = new Pawn (cb [0, 0], "B");
			//cb [0, 0].PlacePiece(testPiece);
			cb.Initialize();
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
				cb [0, 1].Piece.MovePiece (cb [0, 4], cb);

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
				cb.DrawBoard ();
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}