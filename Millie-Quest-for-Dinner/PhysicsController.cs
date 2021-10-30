using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;      
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class PhysicsController
    {
        static PhysicsController()
        {

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

        public static void PlayerMove(Player p, Direction dir)
        {
            bool successful = true;

            // check if new location is occupied

            // if new location not occupied, move player 
            if (successful) p.Move(dir);  
        }

        public void Gravity()
        {

        }
    }
}
