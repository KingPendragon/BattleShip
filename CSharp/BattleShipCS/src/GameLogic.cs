using SwinGameSDK;

namespace MyGame
{
	static class GameLogic
	{
		public static void Main()
		{
			//Opens a new Graphics Window
			SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

			//Load Resources
			GameResources.LoadResources();

			SwinGame.PlayMusic(GameResources.GameMusic("Background"));

			//Game Loop
			do
			{
				GameController.HandleUserInput();
				GameController.DrawScreen();

				//mute function
				if (SwinGame.KeyTyped (KeyCode.vk_m)) {
					if (GameResources.NotMuteSoundEffect) {
						SwinGame.PauseMusic ();
						GameResources.NotMuteSoundEffect = false;
					} else {
						SwinGame.ResumeMusic ();
						GameResources.NotMuteSoundEffect = true;
					}
				}
			} while (!(SwinGame.WindowCloseRequested() == true || GameController.CurrentState == GameState.Quitting));

			SwinGame.StopMusic();

			//Free Resources and Close Audio, to end the program.
			GameResources.FreeResources();
		}
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
