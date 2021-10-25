using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class Player : DynamicObject, ICollidable
    {
        private PlayerState _playerState; 

        public PlayerState PlayerState
        {
            get
            {
                return _playerState; 
            }
        }

        public Player()
        {
            _playerState = PlayerState.PlayerAlive;
        }

        public void OnCollision(ICollidable collidedWith) 
        {
            Console.WriteLine(UIAdapter.Instance.HasCollided(this, collidedWith));
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            UIAdapter.Instance.DrawGameObject(this);
        }
    }
}
