namespace MontyHallKata
{
    public interface IGame
    {
        public int PlayGame(IRandom random, Strategy strategy);
    }
}