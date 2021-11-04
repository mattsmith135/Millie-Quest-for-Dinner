using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging; 

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// An interface that all collidable objects implement. 
    /// </summary>
    public interface ICollidable
    {
        void OnCollision(ICollidable collidedWith);

        double X { get; }

        double Y { get; }

        int Layer { get; set; } 
        
        string BitmapName { get; set; }

        BitmapData BitmapData { get; }
    }
}
