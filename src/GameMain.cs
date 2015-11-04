using System;
using SwinGameSDK;

namespace ChessGame
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenGraphicsWindow("GameMain", 600, 600);
			LoadResources.LoadFont ();
			GameController.LoadGame ();
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
				GameController.HandleGameInput();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
				GameController.DrawGame ();
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}