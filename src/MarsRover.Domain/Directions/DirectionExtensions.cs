namespace MarsRover.Domain.Directions
{
    public static class DirectionExtensions
    {
        public static Direction DirectionFromString(this string direction)
        {
            if (Enum.TryParse(direction, out Direction d))
                return d;
            else throw new ArgumentOutOfRangeException(nameof(direction));
        }
    }
}
