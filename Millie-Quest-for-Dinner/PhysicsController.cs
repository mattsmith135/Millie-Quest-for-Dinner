using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class PhysicsController
    {
        public PhysicsController()
        {

        }

        public void CheckCollisions(List<ICollidable> _collidableObjects)
        {
            foreach (var c1 in _collidableObjects)
            {
                foreach (var c2 in _collidableObjects)
                {
                    if (c1 == c2)
                        continue;

                    if (c1.Layer == 1 && c2.Layer == 1)
                    {
                        // If c1 and c2 are colliding
                        c1.OnCollision(c2);
                        c2.OnCollision(c1);
                    }
                }
            }
        }
    }
}
