using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// The DynamicObject is a GameObject that can move. For this reason, it needs an update method 
    /// and a draw method. 
    /// </summary>
    public abstract class DynamicObject : GameObject
    {
        public DynamicObject() 
        {

        }

        public abstract void Update();

        public override abstract void Draw();
    }
}
