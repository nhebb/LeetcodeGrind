namespace LeetcodeGrind.Solutions;

// 2441. Largest Positive Integer That Exists With Its Negative
public class P2441
{
    public int FindMaxK(int[] nums)
    {
        Array.Sort(nums);
        var hsNums = nums.ToHashSet();

        for (int i = nums.Length - 1; i >= 0 && nums[i] > 0; i--)
        {
            if (hsNums.Contains(-nums[i]))
                return nums[i];
        }

        return -1;
    }

    public int FindMaxK2(int[] nums)
    {
        Array.Sort(nums);

        var hsNegatives = new HashSet<int>();
        foreach (var num in nums)
        {
            if (num < 0)
                hsNegatives.Add(num);
            else
                break;
        }

        for (int i = nums.Length - 1; i >= 0 && nums[i] > 0; i--)
        {
            if (hsNegatives.Contains(-nums[i]))
                return nums[i];
        }

        return -1;
    }

}