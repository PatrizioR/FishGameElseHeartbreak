using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    public class Board
    {
        public int Size { get; private set; }
        public List<Entity> Entities { get; private set; }

        public Board(int size)
        {
            Size = size;
            Entities = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        public bool IsValidMove(Position newPosition)
        {
            if (newPosition.X < 0 || newPosition.X >= Size || newPosition.Y < 0 || newPosition.Y >= Size)
            {
                // New position is outside of the board
                return false;
            }

            foreach (var e in Entities)
            {
                if (e.Position.Equals(newPosition))
                {
                    // There is already an entity on the new position
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append("   |");
            for (int col = 0; col < Size; col++)
            {
                sb.Append(col.ToString().PadLeft(2, '0'));
                sb.Append('|');
            }
            sb.AppendLine();
            sb.AppendLine("".PadRight(Size * 3 + 4, '-'));
            for (int Y = 0; Y < Size; Y++)
            {
                sb.Append($"{(Y).ToString().PadLeft(2, '0')} |");
                for (int X = 0; X < Size; X++)
                {
                    var position = new Position(X, Y);
                    var entityOnPosition = Entities.FirstOrDefault(entity => entity.Position.Equals(position));
                    switch (entityOnPosition)
                    {
                        case Player p:
                            sb.Append('P');
                            break;
                        case Enemy e:
                            sb.Append('E');
                            break;
                        default:
                            sb.Append(' ');
                            break;
                    }
                    if(entityOnPosition?.Alive != false)
                    {
                        switch (entityOnPosition?.Direction)
                        {
                            case Direction.Up:
                                sb.Append('↑');
                                break;
                            case Direction.Down:
                                sb.Append('↓');
                                break;
                            case Direction.Left:
                                sb.Append('←');
                                break;
                            case Direction.Right:
                                sb.Append('→');
                                break;
                            default:
                                sb.Append(' ');
                                break;
                        }
                    }
                    else
                    {
                        sb.Append('†');
                    }
                    
                    sb.Append('|');
                }
                sb.AppendLine();
                sb.AppendLine("".PadRight(Size * 3 + 4, '-'));
            }
            return sb.ToString();
        }
    }
}
