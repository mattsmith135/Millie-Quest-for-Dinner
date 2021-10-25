using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class GameManager
    {
        private List<GameObject> _allObjects;
        private List<DynamicObject> _dynamicObjects;
        private List<ICollidable> _collidableObjects;
        private PhysicsController _physicsController;  


        public GameManager()
        {
            _allObjects = new List<GameObject>();
            _dynamicObjects = new List<DynamicObject>();
            _collidableObjects = new List<ICollidable>();
            _physicsController = new PhysicsController(); 


            RegisterGameObjects();
            LoadAssets();
        }

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

        public void Update()
        {
            foreach (var obj in _dynamicObjects)
                obj.Update();

            _physicsController.CheckCollisions(_collidableObjects); 
        }

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

        private void LoadAssets()
        {
            UIAdapter.Instance.LoadAssets(); 
        }

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
