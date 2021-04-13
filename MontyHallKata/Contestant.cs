namespace MontyHallKata
{
    public class Contestant
    {
        public int ChooseDoor(FakeRandom random)
        {
            return random.Next(3);
        }
    }
}