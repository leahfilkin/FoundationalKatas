using System;
using System.Collections.Generic;

namespace KataABC2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ABC Program");
            AlphabetGenerator alphabetGenerator = new AlphabetGenerator();
            var alphabet = alphabetGenerator.CreateBeginningAlphabet();
            var blockList = new List<string>();
            for (var i = 0; i < 20; i++)
            {
                char letterOne = LetterGenerator.GenerateRandomLetter(alphabet);
                char letterTwo = letterOne;
                while (letterOne == letterTwo)
                {
                    letterTwo = LetterGenerator.GenerateRandomLetter(alphabet);
                }
                var block = new Block(letterOne, letterTwo);
                var createdBlock = block.CreateBlock();
                string pair = ($"{letterOne} {letterTwo}");
                blockList.Add(pair);
                Console.WriteLine(createdBlock);
            }
            var input = "";
            while (input == "")
            {
                Console.Write("Please enter a word you'd like to make with the blocks: ");
                input = Console.ReadLine()?.ToUpper();
            }
            bool canMakeWord = WordChecker.CanMakeWord(input, blockList);
            Console.WriteLine(canMakeWord);
        }
    }
}