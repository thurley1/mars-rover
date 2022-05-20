using MarsRover.Domain.Coordinates;
using MarsRover.Domain.Directions;
using MarsRover.Domain.Plateaus;
using MarsRover.Domain.Rovers;

//capture top right coordinates and create the plateau - keep trying until successful
var topRightCoordinates = CaptureGridCoordinates();
var plateau = new Plateau(topRightCoordinates);
WriteSuccessfulMessage(plateau.ToString());

var roverCount = 0;
var anotherRover = "Y";

//loop on infinite number of rovers
do {
    //capture rover's initial state
    roverCount++;
    var disposition = CaptureRoverStartingPosition(roverCount, plateau);
    var rover = new Rover(
        id: roverCount,
        disposition: disposition);
    WriteSuccessfulMessage($"Initial state: { rover }");

    //capture movement plan
    var movementPlan = "";
    do
    {
        try
        {
            movementPlan = CaptureMovementPlan(rover.Id);
            rover.ProcessInstructionSet(movementPlan, plateau);
            WriteSuccessfulMessage($"Output: { rover }");
        }
        catch (Exception ex)
        {
            WriteException(ex);
            movementPlan = "";
        }
    } while (movementPlan == "");
    
    Console.Write("Would you like to move another rover ('Y' for yes, any other response for no)?:Y");
    anotherRover = Console.ReadLine();

} while (anotherRover == "Y");

//Leave window open
Console.ReadLine();

static Coordinate CaptureGridCoordinates()
{
    var coordinates = new List<int>();
    while (coordinates.Count <= 0)
    {
        try
        {
            Console.Write("Enter Graph's Upper Right Coordinate (integer space integer): ");
            var input = Console.ReadLine() ?? "";

            input.ValidateGridCoordinates();
            coordinates = input.Split(" ")
                .Select(c => int.Parse(c))
                .ToList();
            
        }
        catch (Exception ex)
        {
            WriteException(ex);
        }
    }

    return new Coordinate(coordinates[0], coordinates[1]);
}

static RoverDisposition CaptureRoverStartingPosition(int roverNumber, Plateau plateau)
{
    var dispositionData = new List<string>();
    while (dispositionData.Count <= 0)
    {
        try
        {
            Console.Write($"Enter Rover { roverNumber } Starting Position (integer space integer space direction): ");
            var input = Console.ReadLine() ?? "";
            input.ValidateRoverPosition(plateau);
            dispositionData = input.Split(" ").ToList();
        }
        catch (Exception ex)
        {
            WriteException(ex);
        }
    }
    
    return new RoverDisposition(
        coordinates: new Coordinate(int.Parse(dispositionData[0]), int.Parse(dispositionData[1])), 
        direction: dispositionData[2].DirectionFromString());
}

static string CaptureMovementPlan(int roverNumber)
{
    var movementPlan = "";
    while (string.IsNullOrEmpty(movementPlan))
    {
        try
        {
            Console.Write($"Rover { roverNumber } Movement Plan: ");
            var input = Console.ReadLine();
            input.ValidateMovementPlan();
            movementPlan = input;
        }
        catch (Exception ex)
        {
            WriteException(ex);
            movementPlan = "";
        }
    }
    
    return movementPlan;
}

static void WriteException(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"The following excpetion has occured while setting the graph's coordinates: { ex.Message }. \n\rPlease fix the error and try again.");
    Console.ResetColor();
}

static void WriteSuccessfulMessage(string? message)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{ message }");
    Console.ResetColor();
}