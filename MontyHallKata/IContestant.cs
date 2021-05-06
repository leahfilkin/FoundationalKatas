using System.Collections.Generic;

namespace MontyHallKata
{
    public interface IContestant
    {
        public Door ChooseDoor(IRandom random, List<Door> doors);
    }
}