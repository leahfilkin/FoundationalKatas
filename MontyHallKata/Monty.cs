using System.Collections.Generic;

namespace MontyHallKata
{
    public class Monty
    {
        public Door GetIncorrectDoor(List<Door> doors)
        {
            var random = new Random();
            while (true)
            {
                var doorToReturnIndex = random.Next(doors.Count);
                var doorToReturn = doors[doorToReturnIndex];
                if (!doorToReturn.IsContestantsFirstChoice && !doorToReturn.HasPrize)
                {
                    return doorToReturn;
                }
            }
        }
    }
}