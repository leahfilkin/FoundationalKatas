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
            keepOriginalDoorSimulator.RunSimulation(1000);
            changeDoorSimulator.RunSimulation(1000);
            var keepResult = keepOriginalDoorSimulator.GetPercentage();
            var changeResult = changeDoorSimulator.GetPercentage();
            Console.WriteLine($"Keeping the original door results in a {keepResult}% win rate");
            Console.WriteLine($"Changing the door results in a {changeResult}% win rate");
        }
    }
}