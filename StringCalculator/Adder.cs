using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Adder
    {
        public int Add(string input)
        {
            if (input == null)
            {
                throw new ArgumentException("Null numbers not allowed");
            }
            if (input == "")
            {
                return 0;
            }
            var delimiterList = new List<string>{",", "\n", "/", "[", "]"};
            if (input.StartsWith("//"))
            {
                while (input.Contains("["))
                {
                    var closedBracketIndex = input.IndexOf("]", StringComparison.Ordinal);
                    var openBracketIndex = input.IndexOf("[", StringComparison.Ordinal);
                    var delimiterLength = closedBracketIndex - openBracketIndex - 1;
                    var multiCharacterDelimiter = input.Substring(openBracketIndex + 1, delimiterLength);
                    if (char.IsDigit(multiCharacterDelimiter[0]) || 
                        char.IsDigit(multiCharacterDelimiter[^1]))
                    {
                        throw new ArgumentException
                            ($"Edge numbers not allowed: {multiCharacterDelimiter}");
                    }
                    delimiterList.Add(multiCharacterDelimiter);
                    input = input.Remove(openBracketIndex,2 + delimiterLength);
                }
                if (input.LastIndexOf('/') != input.Length - 1)
                {
                    var delimiter = input.Substring(input.LastIndexOf('/')+1,1);
                    delimiterList.Add(delimiter);
                }
            }
            var delimiterArray = delimiterList.ToArray();
            if (delimiterArray.Any(s=> input.Contains(s)))
            {
                var numbers = input.Split(delimiterArray, StringSplitOptions.None)
                    .Where(x => !string.IsNullOrEmpty(x));
                var sum = 0;
                foreach (var number in numbers)
                {
                    if (number.StartsWith('-')) 
                    {
                        var negativeNumbers = numbers.Where(x => x.First() == '-')
                            .Where(x => !string.IsNullOrEmpty(x));
                        throw new ArgumentException
                            ($"Negatives not allowed: {string.Join(", ",negativeNumbers)}");
                    }
                    if (Convert.ToInt32(number) >= 1000)
                    {
                        continue;
                    }
                    sum += Convert.ToInt32(number);
                }
                return sum;
            }
            return Convert.ToInt32(input);
        }
    }
}