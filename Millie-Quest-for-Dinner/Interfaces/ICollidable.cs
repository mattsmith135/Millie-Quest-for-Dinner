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

        double X { get; }
        double Y { get; }
        int Layer { get; set; } 
        
        string BitmapName { get; set; }
    }
}
