using System.Collections.Generic;
using MarsRover.Enums;

namespace MarsRover.Console
{
    static class Program
    {
        private static void Main(string[] args)
        {
            var commands = new List<Command> {Command.Forward, Command.Left, Command.Forward, Command.Right, Command.Backward};
            var startPosition = new Point(5,5);
            var grid = new Grid(new Random());
            Validator.CheckIfPositionIsValid(startPosition, grid);
            var rover = new Rover(grid, startPosition, Direction.North);
            rover.Navigate(commands, grid);
        }
            
        }
}