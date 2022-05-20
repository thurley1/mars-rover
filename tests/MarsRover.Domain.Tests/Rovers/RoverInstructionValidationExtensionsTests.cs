using FluentAssertions;
using MarsRover.Domain.Rovers;
using Xunit;

namespace MarsRover.Domain.Tests.Rovers
{
    public class RoverInstructionValidationExtensionsTests
    {
        [Fact]
        public void ValidateGridCoordinates_WithNullInput_Throws()
        {
            string input = "";
            var exception = Record.Exception(() => input.ValidateGridCoordinates());

            exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void ValidateGridCoordinates_WithNonIntegerCoordinates_Throws()
        {
            var input = "a b";
            var exception = Record.Exception(() => input.ValidateGridCoordinates());

            exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void ValidateGridCoordinates_WithExtraSpaceInCoordinates_Throws()
        {
            var input = "1  2";
            var exception = Record.Exception(() => input.ValidateGridCoordinates());

            exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void ValidateGridCoordinates_WithValidInput_DoesNotThrow()
        {
            var input = "10 20";
            var exception = Record.Exception(() => input.ValidateGridCoordinates());

            exception.Should().BeNull();
        }
    }
}
