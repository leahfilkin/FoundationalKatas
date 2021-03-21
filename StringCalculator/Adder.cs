using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Adder
    {
        public int Add(string input)
        {
            var delimiterList = new List<char>{',', '\n', '/'};
            if (input.Contains("//"))
            {
                if (input.LastIndexOf('/') != input.Length - 1)
                {
                    var delimiter = input.Substring(input.LastIndexOf('/')+1,1);
                    delimiterList.Add(Convert.ToChar(delimiter));
                }
            }
            var numbers = input.Split(delimiterList.ToArray());
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
            if (input.IndexOfAny(delimiterList.ToArray()) != -1)
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
            else
            {
                return Convert.ToInt32(input);
            }
        }
    }
}