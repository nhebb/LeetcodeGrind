namespace LeetcodeGrind.Solutions;

// 3190. Find Minimum Operations to Make All Elements Divisible by Three
public class P3190
{
    public int MinimumOperations(int[] nums)
    {
        return nums.Count(x => x % 3 != 0);
    }
}
