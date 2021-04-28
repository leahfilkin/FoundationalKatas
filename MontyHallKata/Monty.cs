using System.Collections.Generic;

namespace MontyHallKata
{
    public class Monty
    {
        public Door GetIncorrectDoor(List<Door> doors, Door chosenDoor)
        {
            var random = new Random();
            while (true)
            {
                var doorToReturn = random.Next(doors.Count);
                if (doors[doorToReturn] != chosenDoor && !doors[doorToReturn].HasPrize)
                {
                    return doors[doorToReturn];
                }
            }
        }
    }
}