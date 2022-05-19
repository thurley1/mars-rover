using MarsRover.ConsoleApp;
using MarsRover.Domain.Coordinates.Models;
using MarsRover.Domain.Plateaus.Models;

//capture coordinates of the plateau - keep trying until successful
string[]? coords;
do
{
    coords = CaptureGridCoordinates();
} while (coords == null);


var plateau = new Plateau(
    new Coordinate(int.Parse(coords[0]), int.Parse(coords[1])));

Console.WriteLine($"Plateau grid created. " +
    $"Lower-left: ({ plateau.LowerLeftCoordinate.X }, { plateau.LowerLeftCoordinate.Y }), " +
    $"Upper-right: ({ plateau.UpperRightCoordinate.X }, { plateau.UpperRightCoordinate.Y })");

//Leave window open
Console.ReadLine();

static string[]? CaptureGridCoordinates()
{
    try
    {
        Console.Write("Enter Graph Upper Right Coordinate (two integers separated by a space): ");
        var gridSize = Console.ReadLine();

        gridSize.ValidateGridCoordinates();
        return gridSize?.Split(" ");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"The following excpetion has occured: { ex.Message }. Please fix the error and try again.");
        return null;
    }
}

