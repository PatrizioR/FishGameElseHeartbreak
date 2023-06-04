using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    [Serializable]
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // You might want to override Equals and GetHashCode if you will be comparing Positions
        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Position p = (Position)obj;
                return (this.X == p.X) && (this.Y == p.Y);
            }
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }
    }
}
