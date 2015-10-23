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
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
				cb.DrawBoard ();
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}