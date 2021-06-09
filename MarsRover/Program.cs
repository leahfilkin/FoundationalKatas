using System;
using System.IO.Compression;
using MarsRover.Console;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up the character array
            var commandInput = new[] {'f', 'l', 'f'};
            var output = new Output();
            
            //translate character array (validates as well)
            var decoder = new Decoder();
            var commands = decoder.GetCommands(commandInput);
            
            // set up the start direction
            var startDirection = Direction.North;
            
            // set up the start position
            var startPosition = new Point(5,5);
            var grid = new Grid();
            Validator.IsPositionValid(startPosition, grid);
            
            // initialise the grid and rover
            var rover = new Rover(grid, startPosition, startDirection);

            // if both are valid, check the first character in the array
            foreach (var command in commands)
            {
                if (command == Command.Forward || command == Command.Back)
                {
                    var nextPosition = rover.CalculateNextPosition(command);
                    Rover.CheckForObstacleAt(nextPosition, grid);
                    rover.Move(nextPosition);
                    output.PrintConfirmationOfMove(rover);
                }
                else
                {
                    rover.Turn(command);
                    output.PrintConfirmationOfTurn(rover);
                }
            }
        }
            
        }
}