using MarsRover.Domain.Coordinates.Models;

namespace MarsRover.Domain.Plateaus.Models
{
    public class Plateau
    {
        public Plateau(Coordinate upperRightCoordinate)
        {
            UpperRightCoordinate = upperRightCoordinate;
        }

        public Coordinate UpperRightCoordinate { get; }
        public Coordinate LowerLeftCoordinate { get;  } = new Coordinate(0, 0);
        public Coordinate UpperLeftCoordinate => new(0, UpperRightCoordinate.Y);
        public Coordinate LowerRightCoordinate => new(UpperRightCoordinate.X, 0);
        public int MaxXCoordinate => UpperRightCoordinate.X - 1;
        public int MaxYCoordinate => UpperRightCoordinate.Y - 1;
    }
}
