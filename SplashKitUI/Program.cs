using System;
using SplashKitSDK;
using Millie_Quest_for_Dinner;

namespace SplashKitUI
{
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

