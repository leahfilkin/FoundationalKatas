namespace Yatzy
{
    public interface IUserInput
    {
        string GetDieToReroll();

        char AskIfPlayerWillReroll();
    }
}