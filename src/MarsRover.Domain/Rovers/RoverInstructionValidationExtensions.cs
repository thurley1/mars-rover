using MarsRover.Domain.Plateaus;
using System.Text.RegularExpressions;

namespace MarsRover.Domain.Rovers
{
    /// <summary>
    /// A static class of extension methods used to validate instructions.
    /// </summary>
    public static class RoverInstructionValidationExtensions
    {
        /// <summary>
        /// Validates that the provided string is in the int space int format, otherwise throws an ArgumentException
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateGridCoordinates(this string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Invalid coordinates entered");

            var match = Regex.Match(input, @"^[0-9]*\s[0-9]*$");
            if (!match.Success)
                throw new ArgumentException("Invalid coordinates entered");
        }

        /// <summary>
        /// Validates that the provided string is in int space int space [N,E,W,S] format, otherwise throws an ArgumentException
        /// Also, verification is done on the given coordinates to ensure that the Rover coordinates do not fall outside of the Plateau (grid)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="plateau"></param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Validates that the provided string is in the correct format for a movement plan (only R,L,M are allowed)
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentException"></exception>
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
