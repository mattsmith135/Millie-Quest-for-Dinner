using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// All enumerations used in the program
    /// </summary>
    public enum TileType
    {
        None,
        Grass,
        Air,
        Dirt,
        Box
    }  
    
    public enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    public enum ControlType
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
}
