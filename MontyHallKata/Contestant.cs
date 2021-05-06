using System.Collections.Generic;

namespace MontyHallKata
{
    public class Contestant : IContestant
    {
        public Door ChooseDoor(IRandom random, List<Door> doors)
        {
            var randomIndex = random.Next(doors.Count);
                return doors[randomIndex];
        }
    }
}