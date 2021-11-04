using System;
using SplashKitSDK;
using Millie_Quest_for_Dinner;

namespace SplashKitUI
{
    /// <summary>
    /// The game is started from the SplashKitUI program class
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            new SplashKitAdapter();
            Game game = new Game();
            game.StartGame(); 
        }
    }
}

