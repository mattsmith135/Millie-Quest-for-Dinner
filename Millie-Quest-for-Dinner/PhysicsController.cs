using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;      
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// The physics controller class is responsible for checking collisions and moving the player (among other things) 
    /// It has been made static so that it does not need to be instantiated everytime we want to use it in a different class.
    /// This class is largely unfinished and contains alternate methods for checking collisions
    /// </summary>
    public class PhysicsController
    {
        private static Player _p;

        static PhysicsController()
        {

        }

        public static Player Player
        {
            get
            {
                return _p; 
            }
            set
            {
                _p = value; 
            }
        }

        /// <summary>
        /// Assigns user input to a variable and passes this to the player. Player will then act based on this user input 
        /// </summary>
        public static void UserControl()
        {
            ControlType controlType = UIAdapter.Instance.GetKeyDown();
            Player.OnKeyBoardInput(controlType);
        }

        /// <summary>
        /// Checks for collisions between objects.
        /// </summary>
        /// <param name="collidableObjects">List of collidableObjects passed in from GameManager class</param>
        public static void CheckCollisions(List<ICollidable> collidableObjects)
        {
            foreach (var c1 in collidableObjects)
            {
                foreach (var c2 in collidableObjects)
                {
                    if (c1 == c2)
                        continue;

                    // if c1 and c2 are on layer 1 and colliding
                    // used to detect when sprites are colliding with eachother
                    if (c1.Layer == 1 && c2.Layer == 1 && UIAdapter.Instance.HasCollided(c1, c2))
                    {
                        c1.OnCollision(c2);
                        c2.OnCollision(c1);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if new player location is in map-bounds or colliding with anything 
        /// </summary>
        /// <param name="c1">Player object</param>
        /// <param name="newX">X location player wants to move to</param>
        /// <param name="newY">Y location player wants to move to</param>
        /// <returns>Null if no collision is found. Will return tile where collision took place if one does occur</returns>
        public static Tile getTileCollision(ICollidable c1, double newX, double newY)
        {
            double fromX = Math.Min(c1.X, newX);
            double fromY = Math.Min(c1.Y, newY);
            double toX = Math.Max(c1.X, newX);
            double toY = Math.Max(c1.Y, newY);
            
            /*
            // get the tile locations
            double fromTileX; 
            double fromTileY;
            double toTileX;
            double toTileY;

            double mapWidth = TileMap.Cols * Settings.TILESIZE; 

            for (double x = fromTileX; x <= toTileX; x++)
            {
                for (int y = fromTileY; y <= toTileY; y++)
                {
                    if (x < 0 || x >= (mapWidth) || TileMap.GetTile(x, y) != null)
                    {
                        // collisions found, return the tile
                        return TileMap.GetTile(x, y); 
                    }
                }
            }
            */

            // no collisions found, return null
            return null; 
        }

        /// <summary>
        /// Responsible for moving the player. Checks if the location the player is moving to is valid 
        /// before actually moving. This method is called by the player object. 
        /// </summary>
        /// <param name="dir">A direction determined by user input</param>
        public static void PlayerMove(Direction dir)
        {
            // calls getTileCollision
            // if player isn't colliding with tile, move it 
            // if player is colliding with tile, line up player with tile boundary 

            // change X 
            double dx;

            if (dir == Direction.Left)
            {
                dx = -Settings.PLAYERSPEED;  
            } else if (dir == Direction.Right)
            {
                dx = Settings.PLAYERSPEED; 
            } else
            {
                dx = 0; 
            }

            double oldX = _p.X;
            double newX = oldX + dx * Watch.DeltaTime;

            Tile tile = getTileCollision(_p, newX, _p.Y); 

            if (tile == null)
            {
                _p.X = newX; 
            } else
            {
                if (dx > 0)
                {
                    // player is moving right, line up with left of tile 
                } else if (dx < 0)
                {
                    // player is moving left, line up with right of tile
                }
            }

            // change y 
            double dy;

            if (dir == Direction.Up)
            {
                dy = -Settings.PLAYERSPEED; 
            } else if (dir == Direction.Down)
            {
                dy = Settings.PLAYERSPEED; 
            } else
            {
                dy = 0; 
            }

            double oldY = _p.Y;
            double newY = oldY + dy * Watch.DeltaTime;

            Tile tile2 = getTileCollision(_p, _p.X, newY);
            
            if (tile2 == null)
            {
                _p.Y = newY; 
            } else
            {
                if (dy > 0)
                {
                    // player is moving up, line up with bottom of tile
                } else if (dy < 0)
                {
                    // player is moving down, line up with top of tile
                }
            }
        }

        /// <summary>
        /// Unfinished method. Was supposed to enact a gravitional force upon all dynamic objects
        /// </summary>
        public static void Gravity()
        {

        }
    }
}
