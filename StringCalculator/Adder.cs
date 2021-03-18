using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Adder
    {
        public int Add(string input)
        {
            var delimiterList = new[] {',', '\n', '/'};
            if (input == "")
            {
                return 0;
            }
            if (input.Contains("//"))
            {
                var delimiter = ";";
                delimiterList = new[] {',', '\n', '/', Convert.ToChar(delimiter)};
            }
            if (input.IndexOfAny(delimiterList) != -1)
            {
                var sum = 0;
                string[] numbers = input.Split(delimiterList);
                numbers = numbers.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                foreach (var number in numbers)
                {
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