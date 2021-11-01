using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public abstract class GameObject
    {
        private double _x;
        private double _y;
        private int _layer;
        private string _bitmapName;
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

        public double X
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

        public double Y
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

        public int Layer
        {
            get
            {
                return _layer; 
            }
            set
            {
                _layer = value; 
            }
        }

        public string BitmapName
        {
            get
            {
                return _bitmapName; 
            } 
            set
            {
                _bitmapName = value; 
            }
        }

        public abstract void Draw(); 

        public void LoadWorldPosition(int row, int column)
        {
            // calculate an x and y position based on the row and column values (conversion to world position)
            _x = column * Settings.TILESIZE;
            _y = row * Settings.TILESIZE; 
        }

        public void Initialize()
        {
            _layer = 1;
            _bitmapName = this.GetType().Name.ToLower(); 
        }
    }
}
