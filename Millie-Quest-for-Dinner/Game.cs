using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class Game
    {
        public Game()
        {
            UIAdapter.Instance.OpenGameWindow();
        }

        public void StartGame()
        {
            GameManager gm = new GameManager();
            TileMap map = new TileMap("map.txt");

            foreach (var obj in map.Objects)
            {
                gm.AddObject(obj);
            }

            do
            {
                UIAdapter.Instance.ProcessInput();
                UIAdapter.Instance.ClearScreen();

                gm.Update();
                gm.Draw(); 
                UIAdapter.Instance.RefreshScreen(); 
            } while (!UIAdapter.Instance.WindowCloseRequested());
        }
    }
}
