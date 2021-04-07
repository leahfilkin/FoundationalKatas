using System.Collections.Generic;

namespace Yatzy
{
    public interface IUserInput
    {
        string GetDieToReroll();

        bool AskIfPlayerWillReroll();

        string AskPlayerForCategory(Turn turn, List<Category> categoriesLeft);
    }
    
}