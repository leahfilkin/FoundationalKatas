namespace Yatzy
{
    public class FakeUserInput : IUserInput
    {
        public string GetDieToReroll()
        {
            throw new System.NotImplementedException();
        }

        public char AskIfPlayerWillReroll()
        {
            throw new System.NotImplementedException();
        }
    }
}