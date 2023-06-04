using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    [Serializable]
    public class Player : Entity
    {
        public Player(Position position, Direction direction, bool alive) : base(position, direction, alive)
        {
        }
        public Player(Position position, Direction direction) : base(position, direction, true)
        {
        }

        public void MoveLeft()
        {
            // Change direction 90 degrees to the left
            switch (Direction)
            {
                case Direction.Up:
                    ChangeDirection(Direction.Left);
                    break;
                case Direction.Down:
                    ChangeDirection(Direction.Right);
                    break;
                case Direction.Left:
                    ChangeDirection(Direction.Down);
                    break;
                case Direction.Right:
                    ChangeDirection(Direction.Up);
                    break;
            }
        }

        public void MoveRight()
        {
            // Change direction 90 degrees to the right
            switch (Direction)
            {
                case Direction.Up:
                    ChangeDirection(Direction.Right);
                    break;
                case Direction.Down:
                    ChangeDirection(Direction.Left);
                    break;
                case Direction.Left:
                    ChangeDirection(Direction.Up);
                    break;
                case Direction.Right:
                    ChangeDirection(Direction.Down);
                    break;
            }
        }
    }
}
