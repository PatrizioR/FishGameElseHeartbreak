using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    [Serializable]
    public class Enemy : Entity
    {
        public Enemy(Position position, Direction direction, bool alive) : base(position, direction, alive)
        {
        }

        public Enemy(Position position, Direction direction) : base(position, direction, true)
        {
            
        }

        protected override void HandleInvalidMove()
        {
            // Change direction 180 degrees when hitting a wall
            switch (Direction)
            {
                case Direction.Up:
                    ChangeDirection(Direction.Down);
                    break;
                case Direction.Down:
                    ChangeDirection(Direction.Up);
                    break;
                case Direction.Left:
                    ChangeDirection(Direction.Right);
                    break;
                case Direction.Right:
                    ChangeDirection(Direction.Left);
                    break;
            }
        }
    }
}
