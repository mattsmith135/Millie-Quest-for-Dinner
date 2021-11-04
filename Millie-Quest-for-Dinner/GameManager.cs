using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; 

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// A class in charge of managing the game. A majority of the logic in this class relates to managing the game's objects
    /// </summary>
    public class GameManager
    {
        private List<GameObject> _allObjects; // list of all game objects
        private List<DynamicObject> _dynamicObjects; // list of all dynamic objects
        private List<ICollidable> _collidableObjects; // list of all collidable objects

        public GameManager()
        {
            // initialising lists
            _allObjects = new List<GameObject>();
            _dynamicObjects = new List<DynamicObject>();
            _collidableObjects = new List<ICollidable>();

            RegisterGameObjects();
            LoadAssets();
        }

        /// <summary>
        /// Adds an object to one or any number of gamemanager lists based on its type
        /// </summary>
        /// <param name="obj">A gameobject</param>
        public void AddObject(GameObject obj)
        {
            _allObjects.Add(obj);

            if (obj is DynamicObject)
            {
                _dynamicObjects.Add((DynamicObject)obj); 
            } 

            if (obj is ICollidable)
            {
                _collidableObjects.Add((ICollidable)obj); 
            }
        }

        /// <summary>
        /// Asks all dynamic objects to update
        /// </summary>
        public void Update()
        {
            foreach (var obj in _dynamicObjects)
                obj.Update();

            // PhysicsController.CheckCollisions(_collidableObjects); 
        }

        /// <summary>
        /// Asks all objects to draw 
        /// </summary>
        public void Draw()
        {
            // dynamic objects need to be drawn after static ones 
            foreach (var obj in _allObjects)
            {
                if (obj is not DynamicObject)
                    obj.Draw(); 
            }

            foreach (var obj in _dynamicObjects)
            {
                obj.Draw(); 
            }
        }

        /// <summary>
        /// Asks SplashKit to load all game assets from a resource bundle.
        /// </summary>
        private void LoadAssets()
        {
            UIAdapter.Instance.LoadAssets(); 
        }

        /// <summary>
        /// Populates game object _gameObjectRegistry. 
        /// </summary>
        private void RegisterGameObjects()
        {
            GameObject.RegisterGameObject('a', typeof(AerialEnemy));
            GameObject.RegisterGameObject('e', typeof(DivebombEnemy));
            GameObject.RegisterGameObject('m', typeof(MarksmanEnemy));
            GameObject.RegisterGameObject('D', typeof(Dinner));
            GameObject.RegisterGameObject('j', typeof(Django));
            GameObject.RegisterGameObject('!', typeof(Player)); 
        }
    }
}
