using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public abstract class DynamicObject : GameObject
    {
        public DynamicObject() 
        {

        }

        public abstract void Update();

        public override abstract void Draw();        
    }
}
