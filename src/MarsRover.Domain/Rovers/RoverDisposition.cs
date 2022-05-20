using MarsRover.Domain.Coordinates;
using MarsRover.Domain.Directions;

namespace MarsRover.Domain.Rovers
{
    public class RoverDisposition
    {
        public RoverDisposition(Coordinate coordinates, Direction direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }

        public Coordinate Coordinates { get; set;  }
        public Direction Direction { get; set;  }
    }
}
