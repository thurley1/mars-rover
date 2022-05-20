namespace MarsRover.Domain.Directions
{
    /// <summary>
    /// A static class of extension methods used to validate a string direction
    /// </summary>
    public static class DirectionExtensions
    {
        /// <summary>
        /// This extension method will take a string value that depicts a direction and return the Direction enum element.
        /// If the parse fails and ArgumentOutOfRangeException is thrown.
        /// </summary>
        /// <param name="direction"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static Direction DirectionFromString(this string direction)
        {
            if (Enum.TryParse(direction, out Direction d))
                return d;
            else throw new ArgumentOutOfRangeException(nameof(direction));
        }
    }
}
