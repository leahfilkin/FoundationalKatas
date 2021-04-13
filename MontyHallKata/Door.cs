namespace MontyHallKata
{
    public class Door
    {
        public bool HasPrize { get; }
        public bool IsContestantsFirstChoice { get; }
        public bool IsContestantsSecondChoice { get; }



        public Door(bool hasPrize, bool isContestantsFirstChoice, bool isContestantsSecondChoice)
        {
            HasPrize = hasPrize;
            IsContestantsFirstChoice = isContestantsFirstChoice;
            IsContestantsSecondChoice = isContestantsSecondChoice;
        }
    }
}