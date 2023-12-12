using LeetcodeGrind.Common;
using System.Collections.Generic;

namespace LeetcodeGrind.Solutions;

// 1122. Relative Sort Array
public class P1122
{
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var hs2 = arr2.ToHashSet();
        var d1 = arr1.GroupBy(x => x)
                     .ToDictionary(g => g.Key, g => g.Count());
        var extras = new List<int>();

        foreach (var value in arr1)
        {
            if (!hs2.Contains(value))
            {
                extras.Add(value);
            }
        }
        extras.Sort();

        var result = new List<int>(arr1.Length);
        foreach (var key in arr2)
        {
            for (int i = 0; i < d1[key]; i++)
            {
                result.Add(key);
            }
        }

        result.AddRange(extras);
        return result.ToArray();
    }
}
