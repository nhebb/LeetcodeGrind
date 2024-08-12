namespace LeetcodeGrind.Solutions;

// 1679. Max Number of K-Sum Pairs
public class P1679
{
    // hashing
    public int MaxOperations(int[] nums, int k)
    {
        var d = nums.GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

        var count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            var target = k - nums[i];
            var minNeeded = target == nums[i] ? 2 : 1;

            if (d[nums[i]] >= minNeeded &&
                d.TryGetValue(target, out int value) &&
                value >= minNeeded)
            {
                count++;
                d[nums[i]]--;
                d[target]--;
            }
        }

        return count;
    }

    // sorting / two pointers
    public int MaxOperations2(int[] nums, int k)
    {
        Array.Sort(nums);
        var count = 0;
        var i = 0;
        var j = nums.Length - 1;

        while (i < j)
        {
            if (nums[i] + nums[j] == k)
            {
                count++;
                i++;
                j--;
            }
            else if (nums[i] + nums[j] < k)
            {
                i++;
            }
            else if (nums[i] + nums[j] > k)
            {
                j--;
            }
        }

        return count;
    }
}

