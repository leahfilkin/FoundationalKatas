namespace MarsRover.Console
{
    public class Output
    {
        public static string PrintConfirmationOfMove(Rover rover, Command command)
        {
            return $"The rover has moved {command.ToString()} to {ToString(rover.Position)}";
        }

        public static string ToString(Point position)
        {
            return $"({position.X},{position.Y})";
        }

        public static string PrintConfirmationOfTurn(Rover rover, Command command)
        {
            return $"The rover has turned {command.ToString()} to face {rover.Direction.ToString()}";
        }
    }
}