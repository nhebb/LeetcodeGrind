using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 217. Contains Duplicate
public class P0217
{
    public bool ContainsDuplicate(int[] nums)
    {
        var hs = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!hs.Add(nums[i]))
                return true;
        }
        return false;
    }
}

