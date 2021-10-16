using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using Millie_Quest_for_Dinner; 

namespace SplashKitUI
{
    public class SplashKitAdapter : UIAdapter
    {
        public SplashKitAdapter()
        {

        }

        public override void ProcessInput()
        {
            SplashKit.ProcessEvents(); 
        }

        public override void RefreshScreen()
        {
            SplashKit.RefreshScreen(); 
        }

        public override void DrawTile(Tile tile)
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed(tile.TileType.ToString().ToLower()), tile.X, tile.Y);
        }

        public override void DrawGameObject(GameObject gameObject)
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed(gameObject.GetType().ToString().ToLower()), gameObject.X, gameObject.Y);
        }

        public override void DrawPlayer(Player player)
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed(player.PlayerState.ToString().ToLower()), player.X, player.Y); 
        }

        public override void OpenGameWindow()
        {
            new Window("Millie: Quest for Dinner", Settings.WINDOW_WIDTH, Settings.WINDOW_HEIGHT); 
        }

        public override void ClearScreen()
        {
            SplashKit.ClearScreen(); 
        }

        public override bool WindowCloseRequested()
        {
            return SplashKit.WindowCloseRequested("Millie: Quest for Dinner"); 
        }

        public override void LoadAssets()
        {
            SplashKit.LoadResourceBundle("resourceBundle", "resourceBundle.txt");
        }
    }
}
