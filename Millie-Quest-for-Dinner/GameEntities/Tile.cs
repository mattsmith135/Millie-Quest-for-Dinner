using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Represents a tile in the 2D list of tiles TileMap.Tiles
    /// </summary>
    public class Tile : GameObject, ICollidable
    {
        private TileType _tileType; // enum indicating type of tile 
        private Dictionary<char, TileType> _tileTypeRegistry = new Dictionary<char, TileType>(); 

        public TileType TileType
        {
            get
            {
                return _tileType; 
            }
        }

        public Dictionary<char, TileType>.KeyCollection TileTypeRegistryKeys
        {
            get
            {
                return _tileTypeRegistry.Keys; 
            }
        }

        public Tile()
        {
            // populating dictionary
            _tileTypeRegistry.Add('o', TileType.Air);
            _tileTypeRegistry.Add('g', TileType.Grass);
            _tileTypeRegistry.Add('d', TileType.Dirt);
            _tileTypeRegistry.Add('B', TileType.Box); 
        }

        public void OnCollision(ICollidable collidedWith)
        {

        }

        public override void Draw()
        {
            UIAdapter.Instance.DrawTile(this);    
        }

        /// <summary>
        /// Assigns tiletype enumeration value to a tile. 
        /// </summary>
        /// <param name="tileKind">A potential key to the _tileTypeRegistry dictionary</param>
        public void AssignTileType(char tileKind)
        {
            List<char> keysList = new List<char>(); 
            
            // populating keysList with all _tileTypeRegistry keys
            foreach (char key in _tileTypeRegistry.Keys)
            {
                keysList.Add(key); 
            }

            // if keysList contains tileKind, there must be a corresponding tiletype value. 
            if (!keysList.Contains(tileKind))
            {
                _tileType = TileType.None; 
            } else
            {
                _tileType = _tileTypeRegistry[tileKind]; 
            }
        }

        /// <summary>
        /// Assigns layer and bitmapName values. The layer value depends on the type of tile.
        /// Air and empty tiles are placed on layer -1 as they should not be colliding with anything
        /// </summary>
        public new void Initialize()
        {
            // assigning tiles to layers
            if (_tileType == TileType.Air || _tileType == TileType.None)
            {
                Layer = -1;
            } else
            {
                Layer = 1;
            }

            BitmapName = _tileType.ToString().ToLower(); 
        }
    }
}
