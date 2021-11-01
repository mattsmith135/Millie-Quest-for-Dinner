using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class Player : DynamicObject, ICollidable
    {

        public Player()
        {
            PhysicsController.Player = this;
        }

        public void OnCollision(ICollidable collidedWith) 
        {

        }


        public void OnKeyBoardInput(ControlType type)
        {
            switch (type)
            {
                case ControlType.Left or ControlType.Right or ControlType.Up or ControlType.Down:
                    PhysicsController.PlayerMove((Direction)type);
                    break;
            }
        }

        public void Move(Direction dir)
        {
            /*
            switch (dir)
            {
                case Direction.Left: X -= Settings.PLAYERSPEED * (double)Watch.DeltaTime; break;
                case Direction.Right: X += Settings.PLAYERSPEED * (double)Watch.DeltaTime; break;
                case Direction.Up: Y -= Settings.PLAYERSPEED * (double)Watch.DeltaTime; break;
                case Direction.Down: Y += Settings.PLAYERSPEED * (double)Watch.DeltaTime; break; 
            }
            */

            switch (dir)
            {
                case Direction.Left: X -= Settings.PLAYERSPEED; break;
                case Direction.Right: X += Settings.PLAYERSPEED; break;
                case Direction.Up: Y -= Settings.PLAYERSPEED; break;
                case Direction.Down: Y += Settings.PLAYERSPEED; break;
            }
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
