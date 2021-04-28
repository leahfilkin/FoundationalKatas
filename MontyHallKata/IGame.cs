namespace MontyHallKata
{
    public interface IGame
    {
        public int Play(IRandom random, Strategy strategy);
        
    }
}