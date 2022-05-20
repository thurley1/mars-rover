using MarsRover.Domain.Coordinates;
using MarsRover.Domain.Directions;

namespace MarsRover.Domain.Rovers
{

    public class RoverDisposition
    {
        /// <summary>
        /// Creates a new Rover Disposition (Coordinates of the Rover on the Plateau (grid) along with which Direction the Rover is facing)
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="direction"></param>
        public RoverDisposition(Coordinate coordinates, Direction direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }

        public Coordinate Coordinates { get; set;  }
        public Direction Direction { get; set;  }
    }
}
