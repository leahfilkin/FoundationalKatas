using System;

namespace MontyHallKata
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Monty Hall simulation!");
            var keepOriginalDoorSimulator = new Simulator(Strategy.KeepOriginalDoor);
            var changeDoorSimulator = new Simulator(Strategy.ChangeDoor);
            keepOriginalDoorSimulator.CollectGameResults(1000);
            changeDoorSimulator.CollectGameResults(1000);
            var keepResult = keepOriginalDoorSimulator.CalculateResults();
            var changeResult = changeDoorSimulator.CalculateResults();
            Console.WriteLine($"Keeping the original door results in a {keepResult}% win rate");
            Console.WriteLine($"Changing the door results in a {changeResult}% win rate");
        }
    }
}