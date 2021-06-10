using MarsRover.Enums;

namespace MarsRover.Console
{
    public static class Output
    {
        public static string ConfirmMove(Rover rover, Command command)
        {
            return $"The rover has moved {command.ToString()} to {ToString(rover.Position)}";
        }

        public static string ToString(Point position)
        {
            return $"({position.X},{position.Y})";
        }

        public static string ConfirmTurn(Rover rover, Command command)
        {
            return $"The rover has turned {command.ToString()} to face {rover.Direction.ToString()}";
        }
    }
}