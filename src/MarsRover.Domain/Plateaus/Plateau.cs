using MarsRover.Domain.Coordinates;

namespace MarsRover.Domain.Plateaus
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
        public int MinXCoordinate => LowerLeftCoordinate.X;
        public int MaxYCoordinate => UpperRightCoordinate.Y - 1;
        public int MinYCoordinate => LowerRightCoordinate.Y;

        public bool AreCoordinatesOutOfBounds(int xCoord, int yCoord)
        {
            return xCoord < MinXCoordinate || xCoord > MaxXCoordinate
                || yCoord < MinYCoordinate || yCoord > MaxYCoordinate;
        }

        public override string? ToString()
        {
            return $"Plateau (grid) " +
                $"Lower-left: ({ LowerLeftCoordinate.X }, { LowerLeftCoordinate.Y }), " +
                $"Upper-right: ({ UpperRightCoordinate.X }, { UpperRightCoordinate.Y })";
        }
    }
}
