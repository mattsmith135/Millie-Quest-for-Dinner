using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public interface ICollidable
    {
        void OnCollision(ICollidable collidedWith);

        int X { get; }
        int Y { get; }
    }
}
