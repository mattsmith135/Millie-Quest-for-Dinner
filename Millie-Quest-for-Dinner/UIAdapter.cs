using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// The UIAdapter is an example of the adapter pattern in action. 
    /// It acts as a bridge between the main program and SplashKit, keeping them separate.
    /// Abstract methods here are overriden in the SplashKitAdapter.cs
    /// </summary>
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

        public abstract bool HasCollided(ICollidable c1, ICollidable c2);

        public abstract ControlType GetKeyDown(); 
        
        public abstract void OpenGameWindow();

        public abstract void ClearScreen();

        public abstract bool WindowCloseRequested();

        public abstract void LoadAssets();
    }
}
