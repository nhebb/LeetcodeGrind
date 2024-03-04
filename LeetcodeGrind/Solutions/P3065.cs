namespace LeetcodeGrind.Solutions;

public class P3065
{
    // 3065. Minimum Operations to Exceed Threshold Value I
    public int MinOperations(int[] nums, int k)
    {
        return nums.Count(x => x < k);
    }
}
