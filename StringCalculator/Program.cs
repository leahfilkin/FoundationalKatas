namespace StringCalculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var adder = new Adder();
            var numberString = "-1,2,-3";
            
            var output = adder.Add(numberString);
        }
    }
}