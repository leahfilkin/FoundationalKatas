namespace MontyHallKata
{
    public class Door
    {
        public bool HasPrize { get; }
        public bool IsContestantsFirstChoice { get; }


        public Door(bool hasPrize, bool isContestantsFirstChoice)
        {
            HasPrize = hasPrize;
            IsContestantsFirstChoice = isContestantsFirstChoice;
        }
    }
}