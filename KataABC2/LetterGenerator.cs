using System;
using System.Collections.Generic;

namespace KataABC2
{
    public class LetterGenerator
    {

        public static char GenerateRandomLetter(List<char> alphabet)
        {
            // from the list of letters, go to index determined by Random function
            // .Next gets the random number for you, ranging from first index to length of the Alphabet
            Random random = new Random();
            int randomIndex = random.Next(alphabet.Count);
            return alphabet[randomIndex];
        }
    }
}