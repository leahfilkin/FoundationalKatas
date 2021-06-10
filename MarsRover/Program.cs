using System;
using System.Collections.Generic;
using System.IO.Compression;
using MarsRover.Console;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up the character array
            var commands= new List<Command> {Command.Forward, Command.Left, Command.Forward, Command.Right, Command.Backward};
            
            // set up the start position
            var startPosition = new Point(5,5);
            var grid = new Grid();
            Validator.IsPositionValid(startPosition, grid);
            
            // initialise the grid and rover
            var rover = new Rover(grid, startPosition, Direction.North);

            // if both are valid, check the first character in the array
            rover.Navigate(commands, grid);
        }
            
        }
}