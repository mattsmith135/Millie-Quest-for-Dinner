using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class Camera
    {
        private int _x;
        private int _y;

        /* 
        private int _width;
        private int _height;
        private int _maxX;
        private int _maxY; 
        */

        public Camera(Player player)
        {
            _x = player.X;
            _y = player.Y;
             
        }
    }
}
