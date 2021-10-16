using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace Millie_Quest_for_Dinner
{
    public class TileMap
    {
        private int _cols;
        private int _rows;
        private Tile[,] _tiles; 
        private List<GameObject> _objects = new List<GameObject>(); 
        
        public List<GameObject> Objects
        {
            get
            {
                return _objects; 
            }
        }

        public Tile[,] Tiles
        {
            get
            {
                return _tiles; 
            }
        }
        public int Cols
        {
            get
            {
                return _cols; 
            }
        }

        public int Rows
        {
            get
            {
                return _rows; 
            }
        }

        public TileMap(string filename)
        {
            LoadMap(filename);
        }

        public void LoadMap(string filename)
        {
            List<string> lines = new List<string>();

            foreach (string line in File.ReadLines(filename))
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    break; 
                }

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
                        tile.AssignTileType('o'); // create an 'air' tile by default
                        g = GameObject.CreateGameObject(kind);
                        g.LoadWorldPosition(y, x);
                        _objects.Add(g);
                    }

                    try
                    {
                        _tiles[y, x] = tile;
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
    }
}
