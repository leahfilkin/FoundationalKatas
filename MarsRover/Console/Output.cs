using System.Collections.Generic;
using MarsRover.Enums;

namespace MarsRover.Console
{
    public static class Output
    {
        public static string ConfirmMove(Rover rover, Command command)
        {
            return $"The rover has moved {command.ToString()} to {rover.Position}";
        }

        public static string ConfirmTurn(Rover rover, Command command)
        {
            return $"The rover has turned {command.ToString()} to face {rover.Direction.ToString()}";
        }

        public static string GetNavigationHistory(List<string> navigationHistory)
        {
            return string.Join('\n', navigationHistory);
        }
    }
}