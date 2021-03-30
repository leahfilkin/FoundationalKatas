namespace Yatzy
{
    public class FakeUserInput : IUserInput
    {
        public string GetDieToReroll()
        {
            throw new System.NotImplementedException();
        }

        public string AskIfPlayerWillReroll()
        {
            throw new System.NotImplementedException();
        }
    }
}