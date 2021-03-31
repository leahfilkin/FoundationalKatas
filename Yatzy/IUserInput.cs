namespace Yatzy
{
    public interface IUserInput
    {
        string GetDieToReroll();

        bool AskIfPlayerWillReroll();

        string AskPlayerForCategory(Turn turn);
    }
    
}