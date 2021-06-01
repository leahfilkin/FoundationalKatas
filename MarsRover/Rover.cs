namespace MarsRover
{
    public class Rover
    {
        private int _x;
        private int _y;
        public Rover(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public string GetPosition()
        {
            return $"[{_x},{_y}]";
        }
    }
}