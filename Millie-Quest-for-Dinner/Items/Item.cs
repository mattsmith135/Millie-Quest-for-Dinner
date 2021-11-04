using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Parent item class that all items inherit from 
    /// </summary>
    public abstract class Item : DynamicObject, ICollidable
    {
        public Item()
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
