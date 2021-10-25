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

        public void CheckCollisions(List<ICollidable> collidableObjects)
        {
            foreach (var c1 in collidableObjects)
            {
                foreach (var c2 in collidableObjects)
                {
                    if (c1 == c2)
                        continue;

                    // if c1 and c2 are on the same layer and colliding
                    if (c1.Layer == 1 && c2.Layer == 1 && UIAdapter.Instance.HasCollided(c1, c2))
                    {
                        c1.OnCollision(c2);
                        c2.OnCollision(c1);
                    }
                }
            }
        }

        public void Gravity()
        {

        }
    }
}
