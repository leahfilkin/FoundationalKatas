using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class DirReduction {
  
    public static string[] DirReduc(String[] arr)
    {
        var arrList = arr.ToList();
        var group = arrList.GroupBy( i => i );
        var counts = new Dictionary<string,int>(); 
        foreach (var direction in group)
        {
            counts.Add(direction.Key, direction.Count());
        }

        if (arrList.Contains("NORTH") || arrList.Contains("SOUTH") && counts["NORTH"] > 1 && counts["SOUTH"] > 1)
        {
            var smallestCount = Math.Min(counts["NORTH"], counts["SOUTH"]);
            for (var i = 0; i < smallestCount; i++)
            {
                if (arrList.IndexOf("NORTH") - 1 == arrList.IndexOf("SOUTH") ||
                    arrList.IndexOf("NORTH") + 1 == arrList.IndexOf("SOUTH"))
                {
                    arrList.Remove("NORTH");
                }

                arrList.Remove("SOUTH");
            }
        }
        if (arrList.Contains("EAST") || arrList.Contains("WEST") && counts["EAST"] > 1 && counts["WEST"] > 1)
        {
            var smallestCount = Math.Min(counts["EAST"], counts["WEST"]);
            for (var i = 0; i < smallestCount; i++)
            {
                if (arrList.IndexOf("EAST") - 1 == arrList.IndexOf("WEST") ||
                    arrList.IndexOf("EAST") + 1 == arrList.IndexOf("WEST"))
                {
                    arrList.Remove("EAST");
                    arrList.Remove("WEST");
                }
            }
        }

        return arrList.ToArray();
    }
}