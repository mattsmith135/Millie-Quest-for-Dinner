using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Was meant to be a camera that follows the player. 
    /// Did not have the time to finish this class
    /// </summary>
    public class Camera
    {
        private double _x;
        private double _y;

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
