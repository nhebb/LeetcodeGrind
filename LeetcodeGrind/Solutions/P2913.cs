using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2913. Subarrays Distinct Element Sum of Squares I
public class P2913
{
    public int SumCounts(IList<int> nums)
    {
        var sum = 0;
        var hs = new HashSet<int>();

        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = i; j < nums.Count; j++)
            {
                hs.Add(nums[j]);
                sum += hs.Count * hs.Count;
            }

            hs.Clear();
        }

        return sum;
    }
}
