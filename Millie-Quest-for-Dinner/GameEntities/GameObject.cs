using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// This class represents a general gameobject or entity in the game. It is a parent class to many of the
    /// game's assets. It also operates using the abstract factory method, providing an interface for creating
    /// a family of related objects, without explicitly specifying their classes.
    /// </summary>
    public abstract class GameObject
    {
        private double _x; // x coordinate
        private double _y; // y coordinate
        private int _layer; // collision layer
        private string _bitmapName; // name of gameobject bitmap
        private BitmapData _bitmapData = new BitmapData(); // bitmap data used during collision checking 
        private static Dictionary<char, Type> _gameObjectRegistry = new Dictionary<char, Type>();  

        /// <summary>
        /// Creates a new <char,type> pair in the _gameObjectRegistry. This is used to 
        /// determine which object each character in the map file corresponds to.
        /// ie. GameObject.RegisterGameObject('a', typeof(AerialEnemy));
        /// </summary>
        /// <param name="name">Name of GameObject you want to register</param>
        /// <param name="t">Type of GameObject you want to register</param>
        public static void RegisterGameObject(char name, Type t)
        {
            _gameObjectRegistry[name] = t;
        }

        /// <summary>
        /// This works in conjunction with RegisterGameObject() to return 
        /// an instance of object corresponding to char name value passed in.
        /// </summary>
        /// <param name="name">Name of GameObject you wish to create an instance of</param>
        /// <returns>Instance of a type of gameobject</returns>
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

        public BitmapData BitmapData
        {
            get
            {
                return _bitmapData; 
            }
        }

        public abstract void Draw(); 

        /// <summary>
        /// Converts a GameObject's local map position to world coordinates by multiplying 
        /// each coordinate by tilesize. 
        /// </summary>
        /// <param name="row">GameObject row position in tilemap</param>
        /// <param name="column">GameObject column position in tilemap</param>
        public void LoadWorldPosition(int row, int column)
        {
            // calculate an x and y position based on the row and column values (conversion to world position)
            _x = column * Settings.TILESIZE;
            _y = row * Settings.TILESIZE; 
        }

        /// <summary>
        /// Used to assign values for _layer and _bitmapName. 
        /// </summary>
        public void Initialize()
        {
            _layer = 1;
            _bitmapName = this.GetType().Name.ToLower(); 
        }
    }
}
