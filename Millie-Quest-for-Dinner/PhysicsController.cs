using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;      
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class PhysicsController
    {
        private static Player _p;

        static PhysicsController()
        {

        }

        public static Player Player
        {
            get
            {
                return _p; 
            }
            set
            {
                _p = value; 
            }
        }

        public static void UserControl()
        {
            ControlType controlType = UIAdapter.Instance.GetKeyDown();
            Player.OnKeyBoardInput(controlType); 
        }

        public static void CheckCollisions(List<ICollidable> collidableObjects)
        {
            foreach (var c1 in collidableObjects)
            {
                foreach (var c2 in collidableObjects)
                {
                    if (c1 == c2)
                        continue;

                    // if c1 and c2 are on layer 1 and colliding
                    if (c1.Layer == 1 && c2.Layer == 1 && UIAdapter.Instance.HasCollided(c1, c2))
                    {
                        c1.OnCollision(c2);
                        c2.OnCollision(c1);
                    }
                }
            }
        }    

        public static void PlayerMove(Direction dir)
        {
            // basically a wrapper method at this point 
            // need to decide between: 
            // - handling player collision through OnCollision
            // - handling it in this method (checking if move is valid beforehand)

            _p.Move(dir); 
        }

        public void Gravity()
        {

        }
    }
}
