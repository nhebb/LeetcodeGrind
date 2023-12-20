namespace LeetcodeGrind.Solutions;

// 1636. Sort Array by Increasing Frequency
public class P1636
{
    public int[] FrequencySort(int[] nums)
    {
        return nums.GroupBy(x => x)
                   .OrderBy(g => g.Count())
                   .ThenByDescending(g => g.Key)
                   .SelectMany(g => g)
                   .ToArray();
    }
}
