using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class DirReduction {
  
    public static string[] dirReduc(String[] arr)
    {
        var opposite = new Dictionary<string, string> {{"NORTH", "SOUTH"}, {"EAST", "WEST"}, {"SOUTH", "NORTH"}, {"WEST", "EAST"}};
        var reducedDirections = new Stack<string>();
        foreach (var direction in arr)
        {
            if (reducedDirections.Count > 0)
            {
                var prevDirection = reducedDirections.Pop();
                if (prevDirection != opposite[direction])
                {
                    reducedDirections.Push(prevDirection);
                    reducedDirections.Push(direction);
                }
            }
            else
            {
                reducedDirections.Push(direction);
            }
        }
        return reducedDirections.Reverse().ToArray();
    }
}