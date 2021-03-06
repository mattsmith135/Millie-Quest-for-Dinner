using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// A class that contains all the settings for the game.
    /// </summary>
    public record Settings
    {
        public static int TILESIZE { get; private set; }
        public static int WINDOW_WIDTH { get; private set; }
        public static int WINDOW_HEIGHT { get; private set; }
        public static double PLAYERSPEED { get; private set; }


        static Settings()
        {
            LoadSettings(); 
        }

        static void LoadSettings()
        {
            TILESIZE = 32;
            WINDOW_WIDTH = 800;
            WINDOW_HEIGHT = 600;
            PLAYERSPEED = 0.4; 
        }
    }
}
