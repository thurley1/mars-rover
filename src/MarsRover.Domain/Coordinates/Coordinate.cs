namespace MarsRover.Domain.Coordinates
{
    public class Coordinate
    {
        /// <summary>
        /// Creates a new Coordinate with a specific x and y value.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
