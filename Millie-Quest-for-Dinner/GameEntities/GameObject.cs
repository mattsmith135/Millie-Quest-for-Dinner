using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public abstract class GameObject
    {
        private int _x;
        private int _y;
        private static Dictionary<char, Type> _gameObjectRegistry = new Dictionary<char, Type>(); 

        public static void RegisterGameObject(char name, Type t)
        {
            _gameObjectRegistry[name] = t; 
        }

        public static GameObject CreateGameObject(char name)
        {
            return (GameObject)Activator.CreateInstance(_gameObjectRegistry[name]);
        }

        public GameObject()
        {

        }

        public int X
        {
            get
            {
                return _x; 
            }
            set
            {
                _x = value; 
            }
        }

        public int Y
        {
            get
            {
                return _y; 
            }
            set
            {
                _y = value; 
            }
        }

        public abstract void Draw(); 

        public void LoadWorldPosition(int row, int column)
        {
            // calculate an x and y position based on the row and column values (conversion to world position)
            _x = column * Settings.TILESIZE;
            _y = row * Settings.TILESIZE; 
        }
    }
}
