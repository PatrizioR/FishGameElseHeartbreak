using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishGameElseHeartbreak
{
    [Serializable]
    public class Object : Entity
    {
        public Object(Position position, Direction direction) : base(position, direction)
        {
        }

        // If there's specific behavior for the object class, implement here
    }
}
