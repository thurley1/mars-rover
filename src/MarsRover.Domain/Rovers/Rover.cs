﻿using MarsRover.Domain.Coordinates;
using MarsRover.Domain.Directions;
using MarsRover.Domain.Plateaus;

namespace MarsRover.Domain.Rovers
{
    public class Rover
    {
        public Rover(int id, RoverDisposition disposition)
        {
            Id = id;
            Disposition = disposition;
        }

        public int Id { get; }
        public RoverDisposition Disposition { get; }

        public void ProcessInstructionSet(string instructions, Plateau plateau)
        {
            foreach (var instruction in new List<char>(instructions))
            {
                ProcessInstruction(instruction, plateau);
            }
        }

        public void ProcessInstruction(char instruction, Plateau plateau)
        {
            switch(instruction)
            {
                case 'M':
                    Forward(plateau);
                    break;
                case 'L':
                    Left();
                    break;
                case 'R':
                    Right();
                    break;
            }
        }

        public void Forward(Plateau plateau)
        {
            const string MOVE_OUT_OF_BOUNDS_MESSAGE = "Move will cause rover to be outside the bounds of the plateau";

            switch (Disposition.Direction)
            {
                case Direction.S:
                    if (plateau.AreCoordinatesOutOfBounds(Disposition.Coordinates.X, Disposition.Coordinates.Y - 1))
                        throw new ArgumentException(MOVE_OUT_OF_BOUNDS_MESSAGE);
                    Disposition.Coordinates.Y--;
                    break;
                case Direction.N:
                    if (plateau.AreCoordinatesOutOfBounds(Disposition.Coordinates.X, Disposition.Coordinates.Y + 1))
                        throw new ArgumentException(MOVE_OUT_OF_BOUNDS_MESSAGE);
                    Disposition.Coordinates.Y++;
                    break;
                case Direction.W:
                    if (plateau.AreCoordinatesOutOfBounds(Disposition.Coordinates.X - 1, Disposition.Coordinates.Y))
                        throw new ArgumentException(MOVE_OUT_OF_BOUNDS_MESSAGE);
                    Disposition.Coordinates.X--;
                    break;
                case Direction.E:
                    if (plateau.AreCoordinatesOutOfBounds(Disposition.Coordinates.X + 1, Disposition.Coordinates.Y))
                        throw new ArgumentException(MOVE_OUT_OF_BOUNDS_MESSAGE);
                    Disposition.Coordinates.X++;
                    break;
            }
        }

        public void Right()
        {
            Disposition.Direction = Disposition.Direction == Direction.W ? Direction.N : Disposition.Direction + 1;
        }

        public void Left()
        {
            Disposition.Direction = Disposition.Direction == Direction.N ? Direction.W : Disposition.Direction - 1;
        }   

        public override string? ToString()
        {
            return $"Rover { Id } - position: ({ Disposition.Coordinates.X }, { Disposition.Coordinates.Y }), " +
                $"facing { Disposition.Direction }";
        }
    }
}
