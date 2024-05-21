namespace LeetcodeGrind.Solutions;

// 1. Two Sum
public class P0001
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.TryGetValue(target - nums[i], out int result)
                && result != i)
            {
                return new int[] { i, result };
            }

            dict[nums[i]] = i;
        }

        return new int[] { -1, -1 };
    }
}

