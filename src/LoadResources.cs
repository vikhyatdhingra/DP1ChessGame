using System;
using SwinGameSDK;

namespace ChessGame
{
	public static class LoadResources
	{
		public static SwinGameSDK.Font _font;
	
		public static void LoadFont()
		{
			_font = SwinGame.LoadFontNamed ("maven_pro_regular", "maven_pro_regular.ttf", 19);
			_font.FontStyle = FontStyle.BoldFont;
		}
	}
}

