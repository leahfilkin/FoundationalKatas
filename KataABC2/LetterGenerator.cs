using System;
using System.Collections.Generic;

namespace KataABC2
{
    public static class LetterGenerator
    {

        public static char GenerateRandomLetter(List<char> alphabet)
        {
            Random random = new Random();
            int randomIndex = random.Next(alphabet.Count);
            return alphabet[randomIndex];
        }
    }
}