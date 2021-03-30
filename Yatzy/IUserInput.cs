namespace Yatzy
{
    public interface IUserInput
    {
        string GetDieToReroll();

        string AskIfPlayerWillReroll();
    }
}