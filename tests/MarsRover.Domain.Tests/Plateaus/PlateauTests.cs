using FluentAssertions;
using MarsRover.Domain.Coordinates;
using MarsRover.Domain.Plateaus;
using Xunit;

namespace MarsRover.Domain.Tests.Plateaus
{
    public class PlateauTests
    {
        [Fact]
        public void New_SetsProperties()
        {
            var coords = new Coordinate(7, 10);
            var plateau = new Plateau(coords);

            plateau.UpperRightCoordinate.X.Should().Be(7);
            plateau.UpperRightCoordinate.Y.Should().Be(10);
            plateau.LowerRightCoordinate.X.Should().Be(7);
            plateau.LowerRightCoordinate.Y.Should().Be(0);
            plateau.UpperLeftCoordinate.X.Should().Be(0);
            plateau.UpperLeftCoordinate.Y.Should().Be(10);
            plateau.LowerLeftCoordinate.X.Should().Be(0);
            plateau.LowerLeftCoordinate.Y.Should().Be(0);
        }
    }
}
