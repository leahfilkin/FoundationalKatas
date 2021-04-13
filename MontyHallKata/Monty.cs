namespace MontyHallKata
{
    public class Monty
    {
        public int GetIncorrectDoor(int contestantDoor, int winningDoor)
        {
            var random = new Random();
            while (true)
            {
                var doorToReturn = random.Next(3);
                if (doorToReturn != contestantDoor && doorToReturn != winningDoor)
                {
                    return doorToReturn;
                }
            }
        }
    }
}