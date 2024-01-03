namespace LeetcodeGrind.Solutions;

// 2869. Minimum Operations to Collect Elements
public class P2869
{
    public int MinOperations(IList<int> nums, int k)
    {
        var have = new bool[k + 1]; // max num = 50
        var need = k;
        var count = 0;

        var i = nums.Count - 1;
        while (i >= 0 && need > 0)
        {
            count++;
            if (nums[i] <= k && !have[nums[i]])
            {
                have[nums[i]] = true;
                need--;
            }
            i--;
        }

        return count;
    }

    public int MinOperations2(IList<int> nums, int k)
    {
        var have = new HashSet<int>();
        var count = 0;

        for (int i = nums.Count - 1; i >= 0; i--)
        {
            count++;
            if (nums[i] <= k)
            {
                have.Add(nums[i]);
                if (have.Count == k)
                {
                    return count;
                }
            }
        }

        return count;
    }

}
