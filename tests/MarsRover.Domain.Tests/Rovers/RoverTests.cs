using FluentAssertions;
using MarsRover.Domain.Coordinates;
using MarsRover.Domain.Directions;
using MarsRover.Domain.Plateaus;
using MarsRover.Domain.Rovers;
using Xunit;

namespace MarsRover.Domain.Tests.Rovers
{
    public class RoverTests
    {
        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingSouthAndOutOfGrid_Throws()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.S));

            var instructionSet = "M";
            var exception = Record.Exception(() => rover.ProcessInstructionSet(instructionSet, plateau));
            exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingSouth_DecrementsRoverYCoordinate()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 2),
                    direction: Direction.S));

            var instructionSet = "M";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Coordinates.Y.Should().Be(1);
        }

        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingNorthAndOutOfGrid_Throws()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 9),
                    direction: Direction.N));

            var instructionSet = "M";
            var exception = Record.Exception(() => rover.ProcessInstructionSet(instructionSet, plateau));
            exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingNorth_IncrementsRoverYCoordinate()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 1),
                    direction: Direction.N));

            var instructionSet = "M";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Coordinates.Y.Should().Be(2);
        }

        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingWestAndOutOfGrid_Throws()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.W));

            var instructionSet = "M";
            var exception = Record.Exception(() => rover.ProcessInstructionSet(instructionSet, plateau));
            exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingWest_DecrementsRoverXCoordinate()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(2, 0),
                    direction: Direction.W));

            var instructionSet = "M";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Coordinates.X.Should().Be(1);
        }

        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingEasthAndOutOfGrid_Throws()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(9, 0),
                    direction: Direction.E));

            var instructionSet = "M";
            var exception = Record.Exception(() => rover.ProcessInstructionSet(instructionSet, plateau));
            exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void ProcessInstructionSet_WithMInstruction_AndRoverFacingEast_IncrementsRoverXCoordinate()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.E));

            var instructionSet = "M";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Coordinates.X.Should().Be(1);
        }

        [Fact]
        public void ProcessInstructionSet_WithLInsutruction_AndRoverFacingNorth_TurnsRoverToTheLeft()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.N));

            var instructionSet = "L";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.W);
        }

        [Fact]
        public void ProcessInstructionSet_WithLInsutruction_AndRoverFacingSouth_TurnsRoverToTheLeft()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.S));

            var instructionSet = "L";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.E);
        }

        [Fact]
        public void ProcessInstructionSet_WithLInsutruction_AndRoverFacingEast_TurnsRoverToTheLeft()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.E));

            var instructionSet = "L";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.N);
        }

        [Fact]
        public void ProcessInstructionSet_WithLInsutruction_AndRoverFacingWest_TurnsRoverToTheLeft()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.W));

            var instructionSet = "L";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.S);
        }

        [Fact]
        public void ProcessInstructionSet_WithRInsutruction_AndRoverFacingNorth_TurnsRoverToTheRight()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.N));

            var instructionSet = "R";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.E);
        }

        [Fact]
        public void ProcessInstructionSet_WithRInsutruction_AndRoverFacingSouth_TurnsRoverToTheRight()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.S));

            var instructionSet = "R";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.W);
        }

        [Fact]
        public void ProcessInstructionSet_WithRInsutruction_AndRoverFacingEast_TurnsRoverToTheRight()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.E));

            var instructionSet = "R";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.S);
        }

        [Fact]
        public void ProcessInstructionSet_WithRInsutruction_AndRoverFacingWest_TurnsRoverToTheRight()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.W));

            var instructionSet = "R";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.N);
        }

        [Fact]
        public void ProcessInstructionSet_WithMultipleInstructions_MovesTheRover()
        {
            var plateau = new Plateau(
                new Coordinate(10, 10));

            var rover = new Rover(
                id: 1,
                disposition: new RoverDisposition(
                    coordinates: new Coordinate(0, 0),
                    direction: Direction.N));

            var instructionSet = "MMRMMLMM";
            rover.ProcessInstructionSet(instructionSet, plateau);

            rover.Disposition.Direction.Should().Be(Direction.N);
            rover.Disposition.Coordinates.X.Should().Be(2);
            rover.Disposition.Coordinates.Y.Should().Be(4);
        }
    }
}
