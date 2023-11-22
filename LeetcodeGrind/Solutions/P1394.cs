namespace LeetcodeGrind.Solutions;

// 1394. Find Lucky Integer in an Array
public class P1394
{
    public int FindLucky(int[] arr)
    {
        var d = arr.GroupBy(x => x)
                   .ToDictionary(g => g.Key, g => g.Count());

        var max = -1;
        foreach (var kvp in d)
        {
            if (kvp.Key == kvp.Value)
                max = Math.Max(max, kvp.Key);
        }

        return max;
    }
}
