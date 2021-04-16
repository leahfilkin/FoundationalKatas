using System;

namespace MontyHallKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Monty Hall simulation!");
            var keepOriginalDoor = Strategy.KeepOriginalDoor;
            var changeDoor = Strategy.ChangeDoor;
            var keepOriginalDoorSimulator = new FakeSimulator(keepOriginalDoor);
            var changeDoorSimulator = new FakeSimulator(changeDoor);
            
            keepOriginalDoorSimulator.CollectGameResults(3);
            changeDoorSimulator.CollectGameResults(3);
            var keepResult = keepOriginalDoorSimulator.CalculateResults();
            var changeResult = changeDoorSimulator.CalculateResults();
        }
    }
}