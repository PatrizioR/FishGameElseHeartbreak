using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    [Serializable]
    public abstract class Entity
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        public bool Alive { get; set; } = true;
        protected Entity(Position position, Direction direction, bool alive = true)
        {
            Position = position;
            Direction = direction;
            Alive = alive;
        }

        // Change direction of the Entity
        public void ChangeDirection(Direction newDirection)
        {
            Direction = newDirection;
        }

        // Move the Entity in its current direction
        public void Move(Board board)
        {
            Position newPosition = GetNextPosition();

            if (board.IsValidMove(newPosition))
            {
                Position = newPosition;
            }
            else
            {
                HandleInvalidMove();
            }
        }

        protected virtual void HandleInvalidMove()
        {
            // Default behavior is to do nothing on invalid move.
        }

        public Position GetNextPosition()
        {
            Position newPosition = new(Position.X, Position.Y);
            switch (Direction)
            {
                case Direction.Up:
                    newPosition.Y -= 1;
                    break;
                case Direction.Down:
                    newPosition.Y += 1;
                    break;
                case Direction.Left:
                    newPosition.X -= 1;
                    break;
                case Direction.Right:
                    newPosition.X += 1;
                    break;
            }

            return newPosition;
        }

        public override string ToString()
        {
            return $"{Position.X}/{Position.Y}|{Direction}";
        }
    }

}
