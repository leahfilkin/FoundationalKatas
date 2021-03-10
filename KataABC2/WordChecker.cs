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
            var letterIsConfirmed = new Dictionary<int, bool>();
            var inputCharacters = input.ToCharArray().ToList();
            var breakingOut = false;
            foreach (var block in blockList)
            {
                foreach (var character in block)
                {
                    if (breakingOut) //if we want to break out of the outer loop as weve used a char on the block
                    {
                        breakingOut = false; //set it back to false so we dont keep breaking out
                        break;
                    }
                    if (inputCharacters.Contains(character)) //if the character is in the input
                    {
                        for (var i = 0; i < inputCharacters.Count; i++ )
                        {
                            var inputCharacter = inputCharacters[i];
                            if (letterIsConfirmed.ContainsKey(i)) //if that index has already got a block
                            {
                                continue; //this input letter has already been done
                            }
                            if (character == inputCharacter)
                            {
                                letterIsConfirmed.Add(i, true); //else add the letters index to the list
                                if (letterIsConfirmed.Count() == input.Length) //if the length of the confirmed letters
                                                                               //is the same as the input
                                {
                                    return true; //then all the letters match
                                }
                                if (character == block[0]) //if its the first block and its being used
                                {
                                    breakingOut = true; //we need to break out of the outer loop to start a new block
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


