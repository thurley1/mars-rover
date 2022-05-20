namespace MarsRover.Domain.Directions
{
    public static class DirectionExtensions
    {
        public static Direction FromString(this string direction)
        {
            _ = Enum.TryParse(direction, out Direction d);

            return d;
        }
    }
}
