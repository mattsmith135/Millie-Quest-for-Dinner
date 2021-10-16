using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public abstract class UIAdapter
    {
        private static UIAdapter _instance;
        protected UIAdapter() => Initialise(); 
        
        public static UIAdapter Instance
        {
            get
            {
                return _instance;
            }
        }

        protected void Initialise()
        {
            _instance = this; 
        }

        public abstract void ProcessInput();

        public abstract void RefreshScreen();

        public abstract void DrawTile(Tile tile); 

        public abstract void DrawGameObject(GameObject gameObject);

        public abstract void DrawPlayer(Player player); 

        public abstract void OpenGameWindow();

        public abstract void ClearScreen();

        public abstract bool WindowCloseRequested();

        public abstract void LoadAssets();
    }
}
