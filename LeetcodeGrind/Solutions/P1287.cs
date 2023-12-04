namespace LeetcodeGrind.Solutions;

// 1287. Element Appearing More Than 25% In Sorted Array
public class P1287
{
    public int FindSpecialInteger(int[] arr)
    {
        var d = arr.GroupBy(x => x)
                   .ToDictionary(g => g.Key, g => g.Count());

        foreach (var kvp in d)
        {
            if (kvp.Value * 4 > arr.Length)
            {
                return kvp.Key;
            }
        }

        return -1;
    }
}
