using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Millie_Quest_for_Dinner;

namespace SplashKitUI
{
    /// <summary>
    /// A class containing all SplashKit code for the program. 
    /// </summary>
    public class SplashKitAdapter : UIAdapter
    {
        public SplashKitAdapter()
        {

        }

        /// <summary>
        /// Wrapper method used to process user input 
        /// </summary>
        public override void ProcessInput()
        {
            SplashKit.ProcessEvents();
        }

        /// <summary>
        /// Wrapper method used to refresh the screen
        /// </summary>
        public override void RefreshScreen()
        {
            SplashKit.RefreshScreen(); 
        }

        /// <summary>
        /// Draws tiles based on their bitmap name, x and y coordinates
        /// </summary>
        /// <param name="tile">Tile to be drawn</param>
        public override void DrawTile(Tile tile)
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed(tile.BitmapName), tile.X, tile.Y);
        }

        /// <summary>
        /// Draws game objects based on their bitmap name, x and y coordinates
        /// </summary>
        /// <param name="gameObject">Game object to be drawn</param>
        public override void DrawGameObject(GameObject gameObject)
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed(gameObject.BitmapName), gameObject.X, gameObject.Y);
        }

        /// <summary>
        /// Returns a boolean value based on whether or not the two passed in objects are colliding
        /// </summary>
        /// <param name="c1">Collidable object 1</param>
        /// <param name="c2">Collidable object 2</param>
        /// <returns>True or false</returns>
        public override bool HasCollided(ICollidable c1, ICollidable c2)
        {
            return SplashKit.BitmapCollision(SplashKit.BitmapNamed(c1.BitmapName), c1.X, c1.Y, SplashKit.BitmapNamed(c2.BitmapName), c2.X, c2.Y);
        }

        /// <summary>
        /// Gets user input 
        /// </summary>
        /// <returns>ControlType enum value</returns>
        public override ControlType GetKeyDown()
        {
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                return ControlType.Left; 
            } else if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                return ControlType.Right; 
            } else if (SplashKit.KeyDown(KeyCode.UpKey))
            {
                return ControlType.Up; 
            } else if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                return ControlType.Down; 
            }

            return ControlType.None;
        }

        /// <summary>
        /// Wrapper method that opens the game window 
        /// </summary>
        public override void OpenGameWindow()
        {
            new Window("Millie: Quest for Dinner", Settings.WINDOW_WIDTH, Settings.WINDOW_HEIGHT); 
        }

        /// <summary>
        /// Wrapper method that clears the screen
        /// </summary>
        public override void ClearScreen()
        {
            SplashKit.ClearScreen(); 
        }

        /// <summary>
        /// Wrapper method that checks if user has exited program
        /// </summary>
        /// <returns>True or false</returns>
        public override bool WindowCloseRequested()
        {
            return SplashKit.WindowCloseRequested("Millie: Quest for Dinner"); 
        }

        /// <summary>
        /// Loads all bitmaps from a resource bundle. 
        /// </summary>
        public override void LoadAssets()
        {
            SplashKit.LoadResourceBundle("resourceBundle", "resourceBundle.txt");
        }
    }
}
