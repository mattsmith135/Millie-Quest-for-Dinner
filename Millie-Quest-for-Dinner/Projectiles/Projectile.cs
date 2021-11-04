using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Parent projectile class that all projectiles inherit from 
    /// </summary>
    public abstract class Projectile : DynamicObject, ICollidable
    {
        public Projectile()
        {

        }

        public void OnCollision(ICollidable collidedWith)
        {

        }

        public override void Update()
        {
           
        }

        public override void Draw()
        {

        }
    }
}
