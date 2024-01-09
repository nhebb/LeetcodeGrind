namespace LeetcodeGrind.Solutions;

// 2395. Find Subarrays With Equal Sum
public class P2395
{
    public bool FindSubarrays(int[] nums)
    {
        var hs = new HashSet<int>(nums.Length);

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (!hs.Add(nums[i] + nums[i + 1]))
                return true;
        }

        return false;
    }
}
