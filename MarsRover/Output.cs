namespace MarsRover.Console
{
    public class Output
    {
        public string PrintConfirmationOfMove(Rover rover)
        {
            return $"The rover has moved to {ToString(rover.Position)}";
        }

        public string ToString(Point position)
        {
            return $"({position.X},{position.Y})";
        }

        public string PrintConfirmationOfTurn(Rover rover)
        {
            return $"The rover has turned to face {rover.Direction.ToString()}";
        }
    }
}