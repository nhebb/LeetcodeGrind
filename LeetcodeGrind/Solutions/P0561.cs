namespace LeetcodeGrind.Solutions;

// 561. Array Partition
public class P0561
{
    public int ArrayPairSum(int[] nums)
    {
        Array.Sort(nums);
        return nums.Where(x => x % 2 == 0).Sum();
    }
}
