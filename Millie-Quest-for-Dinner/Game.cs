using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Main game class where game loop is maintained. 
    /// </summary>
    public class Game
    {
        public Game()
        {
            UIAdapter.Instance.OpenGameWindow();
        }

        /// <summary>
        /// Method in charge of 'starting' the game. 
        /// </summary>
        public void StartGame()
        {
            // Initialising the game manager and loading the map
            GameManager gm = new GameManager();
            TileMap.LoadMap("map.txt"); 

            // Adding all of the maps objects to the game manager 
            foreach (var obj in TileMap.Objects)
            {
                gm.AddObject(obj);
            }
            
            // game loop
            do
            {
                Watch.MeasureDeltaTime();
                UIAdapter.Instance.ProcessInput();
                PhysicsController.UserControl();
                UIAdapter.Instance.ClearScreen();

                gm.Update();
                gm.Draw();
                UIAdapter.Instance.RefreshScreen(); 
            } while (!UIAdapter.Instance.WindowCloseRequested());
        }
    }
}
