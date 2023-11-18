using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 442. Find All Duplicates in an Array
public class P0442
{
    // Slower, but the LINQ array to dictionary is fun.
    public IList<int> FindDuplicates(int[] nums)
    {
        var d = nums.GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

        var result = new List<int>();

        foreach (var kvp in d)
        {
            if(kvp.Value == 2)
                result.Add(kvp.Key);
        }

        return result;
    }

    // Faster
    public IList<int> FindDuplicates2(int[] nums)
    {
        var hs = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!hs.Add(num))
                hs.Remove(num);
        }

        return hs.ToList();
    }

}
