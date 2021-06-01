using System;

namespace MarsRover.Console
{
    class Program
    {
        static void Main(string[] args)
        {
                // set up the start position
                var startingPosition = "1,1";
                // set up the character array
                var instructions = new char[] {'f'};
                // validate the start position
                var grid = new Grid();
                var startingPositionIsValid = Validator.IsStartingPositionValid(startingPosition, grid);
                // validate the character array
                var instructionsAreValid = Validator.AreInstructionsValid(instructions); 
                // if both are valid, check the first character in the array
                // move the rover according to what that first letter says
        }
            
        }
    }