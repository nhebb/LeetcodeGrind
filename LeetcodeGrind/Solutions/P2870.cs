using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2870. Minimum Number of Operations to Make Array Empty
public class P2870
{
    public int MinOperations(int[] nums)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
                d[nums[i]]++;
            else
                d[nums[i]] = 1;
        }

        var count = 0;
        foreach (var kvp in d)
        {
            if (kvp.Value == 1)
            {
                return -1;
            }

            count += kvp.Value / 3 + 1;
            if (kvp.Value % 3 != 0)
            {
                count++;
            }
        }

        return count;
    }
}
