using System;
using SwinGameSDK;

namespace ChessGame
{
	/// <summary>
	/// Load resources used for the game.
	/// </summary>
	public static class LoadResources
	{
		// The font used for in-game text
		public static SwinGameSDK.Font _font;

		/// <summary>
		/// Loads the font and set the font style to bold.
		/// </summary>
		public static void LoadFont()
		{
			_font = SwinGame.LoadFontNamed ("maven_pro_regular", "maven_pro_regular.ttf", 19);
			_font.FontStyle = FontStyle.BoldFont;
		}
	}
}

