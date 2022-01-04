using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Singleton. Contains a list of tiles which represents the entire map
    /// </summary>
    public static class TileMap
    {
        private static int _cols; // number of columns 
        private static int _rows; // number of rows
        private static Tile[,] _tiles; // 2D list of tiles 
        private static List<GameObject> _objects = new List<GameObject>(); // list of objects contained in map

        public static List<GameObject> Objects
        {
            get
            {
                return _objects;
            }
        }

        public static Tile[,] Tiles
        {
            get
            {
                return _tiles;
            }
        }
        public static int Cols
        {
            get
            {
                return _cols;
            }
        }

        public static int Rows
        {
            get
            {
                return _rows;
            }
        }

        static TileMap()
        {

        }

        /// <summary>
        /// Loads the map from a text file. When this method is complete,
        /// the tile and object lists will be populated and column + row counts
        /// will be recorded. 
        /// </summary>
        /// <param name="filename">Name of file containing map</param>
        public static void LoadMap(string filename)
        {
            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines(filename))
            {
                // if a line is blank, don't add it to the lines list 
                if (String.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                // if a line starts with a '#', don't add it to the lines list as it is a comment
                if (!line.StartsWith("#"))
                {
                    lines.Add(line);
                    _cols = Math.Max(_cols, line.Length);
                }
            }

            _rows = lines.Count;

            _tiles = new Tile[_rows, _cols];

            char kind;
            GameObject g;

            for (int y = 0; y < _rows; y++)
            {
                string line = lines[y];

                for (int x = 0; x < _cols; x++)
                {
                    kind = line[x];

                    Tile tile = new Tile();

                    if (tile.TileTypeRegistryKeys.Contains<char>(kind))
                    {
                        tile.AssignTileType(kind);
                    } else
                    {
                        tile.AssignTileType('o'); // if a tile type is not specified, create an air tile by default
                        g = GameObject.CreateGameObject(kind);
                        g.Initialize(); // assigns a collision layer and bitmap name
                        g.LoadWorldPosition(y, x);
                        _objects.Add(g);
                    }

                    try
                    {
                        _tiles[y, x] = tile;
                        tile.Initialize();
                        tile.LoadWorldPosition(y, x);
                        _objects.Add(tile);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// A method that returns the tile holding the coordinates passed in
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>A tile object with x and y coordinates equal to the ones passed in</returns>
        public static Tile GetTile(double x, double y)
        {
            x = Math.Round(x);
            y = Math.Round(y);

            foreach (Tile t in _tiles)
            {
                if (t.X == x && t.Y == y)
                {
                    return t;
                }
            }

            return null;
        }
    }
}
