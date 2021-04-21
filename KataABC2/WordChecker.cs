using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace KataABC2
{
    public class WordChecker
    {
        public static bool CanMakeWord(string input, List<string> blockList)
        {
            var inputLettersFoundInBlocks = new Dictionary<int, bool>();
            var inputLettersSplitIntoList = input.ToCharArray().ToList();
            var breakingOutOfLoop = false;
            foreach (var block in blockList)
            {
                foreach (var character in block)
                {
                    if (breakingOutOfLoop) 
                    {
                        breakingOutOfLoop = false; 
                        break;
                    }
                    if (inputLettersSplitIntoList.Contains(character)) 
                    {
                        for (var i = 0; i < inputLettersSplitIntoList.Count; i++ )
                        {
                            var inputCharacterThatMatchesBlockCharacter = inputLettersSplitIntoList[i];
                            if (inputLettersFoundInBlocks.ContainsKey(i)) 
                            {
                                continue; 
                            }
                            if (character == inputCharacterThatMatchesBlockCharacter)
                            {
                                inputLettersFoundInBlocks.Add(i, true); //else add the letters index to the list
                                if (inputLettersFoundInBlocks.Count() == input.Length) //if the length of the confirmed letters
                                                                               //is the same as the input
                                {
                                    return true; //then all the letters match
                                }
                                if (character == block[0]) //if its the first block and its being used
                                {
                                    breakingOutOfLoop = true; //we need to break out of the outer loop to start a new block
                                }
                                break; //breaking out of this loop
                            }
                        }
                    }
                }
            }
            return false; //if we go through all the blocks then we return false
        }
    }
}


