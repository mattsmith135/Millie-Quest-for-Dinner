using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Game player class.
    /// </summary>
    public class Player : DynamicObject, ICollidable
    {

        public Player()
        {
            // The physicscontroller is in charge of moving the player.
            // Here I assign the player to the physicscontroller
            PhysicsController.Player = this;
        }

        /// <summary>
        /// Currently empty method. Intended as a response to collision with objects
        /// </summary>
        /// <param name="collidedWith">Object collided with</param>
        public void OnCollision(ICollidable collidedWith) 
        {

        }

        /// <summary>
        /// Asks the physicscontroller to move the player in a direction based on user input 
        /// </summary>
        /// <param name="type">User input</param>
        public void OnKeyBoardInput(ControlType type)
        {
            switch (type)
            {
                case ControlType.Left or ControlType.Right or ControlType.Up or ControlType.Down:
                    PhysicsController.PlayerMove((Direction)type);
                    break;
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
