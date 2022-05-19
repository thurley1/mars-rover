using System.Text.RegularExpressions;

namespace MarsRover.ConsoleApp
{
    public static class ConsoleInputExtensions
    {
        public static void ValidateGridCoordinates(this string? input)
        {
            if (input == null)
                throw new ArgumentException("Invalid coordinates entered");

            var match = Regex.Match(input, @"^[0-9]*\s[0-9]*$");
            if (!match.Success)
                throw new ArgumentException("Invalid coordinates entered");
        }
    }
}
