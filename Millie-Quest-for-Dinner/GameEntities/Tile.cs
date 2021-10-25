using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class Tile : GameObject, ICollidable
    {
        private TileType _tileType;
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

        public void AssignTileType(char tileKind)
        {
            List<char> keysList = new List<char>(); 
            
            foreach (char key in _tileTypeRegistry.Keys)
            {
                keysList.Add(key); 
            }

            if (!keysList.Contains(tileKind))
            {
                _tileType = TileType.None; 
            } else
            {
                _tileType = _tileTypeRegistry[tileKind]; 
            }
        }

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
