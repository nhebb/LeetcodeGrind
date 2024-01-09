namespace LeetcodeGrind.Solutions;

// 2148. Count Elements With Strictly Smaller and Greater Elements 
public class P2148
{
    public int CountElements(int[] nums)
    {
        Array.Sort(nums);

        var preMin = new int[nums.Length];
        preMin[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            preMin[i] = Math.Min(preMin[i - 1], nums[i]);
        }

        var postMax = new int[nums.Length];
        postMax[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            postMax[i] = Math.Max(nums[i], postMax[i + 1]);
        }

        var count = 0;
        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (preMin[i - 1] < nums[i] && nums[i] < postMax[i + 1])
            {
                count++;
            }
        }

        return count;
    }

    // Simpler and less convoluted than above
    public int CountElements2(int[] nums)
    {
        var min = nums.Min();
        var max = nums.Max();
        var count = 0;
        foreach (var num in nums)
        {
            if (min < num && num < max)
            {
                count++;
            }
        }
        return count;
    }
}
