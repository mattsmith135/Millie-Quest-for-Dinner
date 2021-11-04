using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Parent enemy class that all enemies inherit from
    /// </summary>
    public abstract class Enemy : DynamicObject, ICollidable
    {
        public Enemy()
        {

        }

        public void OnCollision(ICollidable collidedWith)
        {
             
        }

        public override void Draw()
        {

        }

        public override void Update()
        {

        }
    }
}
