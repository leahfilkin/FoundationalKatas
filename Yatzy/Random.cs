namespace Yatzy
{
    public class Random : IRandom
    {
        public int Next(int range)
        {
            var random = new System.Random();
            return random.Next(range) + 1;
        }
    }
}