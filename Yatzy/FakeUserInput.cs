namespace Yatzy
{
    public class FakeUserInput : IUserInput
    {
        public string GetDieToReroll()
        {
            throw new System.NotImplementedException();
        }

        public bool AskIfPlayerWillReroll()
        {
            throw new System.NotImplementedException();
        }

        public string AskPlayerForCategory(Turn turn)
        {
            throw new System.NotImplementedException();
        }
    }
}