using MarsRover.Domain.Plateaus;
using System.Text.RegularExpressions;

namespace MarsRover.Domain.Rovers
{
    public static class RoverInstructionValidationExtensions
    {
        public static void ValidateGridCoordinates(this string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Invalid coordinates entered");

            var match = Regex.Match(input, @"^[0-9]*\s[0-9]*$");
            if (!match.Success)
                throw new ArgumentException("Invalid coordinates entered");
        }

        public static void ValidateRoverPosition(this string input, Plateau plateau)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Invalid location specified");

            var match = Regex.Match(input, @"^[0-9]*\s[0-9]*\s[N,E,S,W]$");
            if (!match.Success)
                throw new ArgumentException("Invalid location specified");

            //ensure that the starting position is not outside the grid
            var disposition = input.Split(" ");
            if (plateau.AreCoordinatesOutOfBounds(int.Parse(disposition[0]), int.Parse(disposition[1])))
                throw new ArgumentException("Position of rover is outside the bounds of the plateau");
        }

        public static void ValidateMovementPlan(this string? input)
        {
            if (input == null)
                throw new ArgumentException("Invalid movement plan specified");

            var match = Regex.Match(input, @"^[R,L,M]*$");
            if (!match.Success)
                throw new ArgumentException("Invalid movement plan specified");
        }
    }

}
