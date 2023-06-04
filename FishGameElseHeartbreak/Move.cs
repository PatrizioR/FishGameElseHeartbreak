using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    public class Move
    {
        public Direction Direction { get; private set; }
        public int Steps { get; private set; }

        public Move(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
    }
}
