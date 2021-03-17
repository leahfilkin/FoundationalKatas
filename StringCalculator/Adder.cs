using System;

namespace StringCalculator
{
    public class Adder
    {
        public int Add(string input)
        {
            if (input == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(input);
            }
        }
    }
}