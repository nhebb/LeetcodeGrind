namespace LeetcodeGrind.Solutions;

// 219. Contains Duplicate II
public class P0219
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        if (nums.Length == 1 || k == 0)
            return false;

        var valueCounts = new Dictionary<int, int>();
        int j = 0;
        while (j < nums.Length && j <= k)
        {
            if (!valueCounts.TryAdd(nums[j], 1))
                return true;
            j++;
        }

        int i = 1;
        j = k + 1;
        while (j < nums.Length)
        {
            valueCounts.Remove(nums[i - 1]);
            if (!valueCounts.TryAdd(nums[j], 1))
                return true;
            i++;
            j++;
        }
        return false;
    }
}
