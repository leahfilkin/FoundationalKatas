namespace MontyHallKata
{
    public class Random : IRandom
    {
        public int Next(int range)
        {
            var random = new System.Random();
            return random.Next(3) + 1;
        }
    }
}