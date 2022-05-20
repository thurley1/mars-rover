using FluentAssertions;
using MarsRover.Domain.Directions;
using Xunit;

namespace MarsRover.Domain.Tests.Directions
{
    public class DirectionExtensionsTests
    {
        [Fact]
        public void FromString_WhenDirectionIsNorth_ReturnsNorth()
        {
            var direction = "N";
            var result = direction.DirectionFromString();

            result.Should().Be(Direction.N);
        }

        [Fact]
        public void FromString_WhenDirectionIsSouth_ReturnsSouth()
        {
            var direction = "S";
            var result = direction.DirectionFromString();

            result.Should().Be(Direction.S);
        }

        [Fact]
        public void FromString_WhenDirectionIsEast_ReturnsEast()
        {
            var direction = "E";
            var result = direction.DirectionFromString();

            result.Should().Be(Direction.E);
        }

        [Fact]
        public void FromString_WhenDirectionIsWest_ReturnsWest()
        {
            var direction = "W";
            var result = direction.DirectionFromString();

            result.Should().Be(Direction.W);
        }

        [Fact]
        public void FromString_WhenDirectionDoesNotExist_Throws()
        {
            var direction = "A";
            
            var exception = Record.Exception(() => direction.DirectionFromString());
            exception.Should().BeOfType<ArgumentOutOfRangeException>();
        }
    }
}
