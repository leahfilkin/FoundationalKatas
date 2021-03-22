using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Adder
    {
        public int Add(string input)
        {
            var delimiterList = new List<string>{",", "\n", "/", "[", "]"};
           if (input.Contains("//"))
            {
                while (input.Contains("["))
                {
                    var delimiterLength = input.IndexOf("]") - input.IndexOf("[") -1;
                    var multiCharacterDelimiter = input.Substring(input.IndexOf("[")+1, delimiterLength);
                    int value;
                    if (Char.IsDigit(multiCharacterDelimiter[0]) || 
                        Char.IsDigit(multiCharacterDelimiter[^1]))
                    {
                        throw new ArgumentException
                            ($"Edge numbers not allowed: {multiCharacterDelimiter}");
                    }
                    delimiterList.Add(multiCharacterDelimiter);
                    input = input.Remove(input.IndexOf("["),1);
                    input = input.Remove(input.IndexOf("]"),1);
                }
                if (input.LastIndexOf('/') != input.Length - 1)
                {
                    var delimiter = input.Substring(input.LastIndexOf('/')+1,1);
                    delimiterList.Add(delimiter);
                }
            }

            var delimiterArray = delimiterList.ToArray();
            var numbers = input.Split(delimiterArray, StringSplitOptions.None);
            if (input.Contains('-'))
            {
                var negativeNumbers = numbers.Where(x => x.First() == '-')
                    .Where(x => !string.IsNullOrEmpty(x));
                throw new ArgumentException
                    ($"Negatives not allowed: {string.Join(", ",negativeNumbers)}");
            }
            if (input == "")
            {
                return 0;
            }
            numbers = numbers.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (delimiterList.Any(s=> input.Contains(s)) == true)
            {
                var sum = 0;
                foreach (var number in numbers)
                {
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