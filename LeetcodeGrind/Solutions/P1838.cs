namespace LeetcodeGrind.Solutions;

// 1838. Frequency of the Most Frequent Element
// TODO: Finish this
public class P1838
{

    public int MaxFrequency(int[] nums, int k)
    {
        if (nums.Length == 1) return 1;

        var max = 1;
        int i = 0;
        int j = 1;
        var sum = nums[0];
        var delta = Math.Abs(nums[j] - nums[i]);

        while (j < nums.Length)
        {

        }

        return max;
    }
}
