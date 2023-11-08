namespace LeetcodeGrind.Solutions;

// 2057. Smallest Index With Equal Value
public class P2057
{
    public int SmallestEqual(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
            if (i % 10 == nums[i])
                return i;
        return -1;
    }
}
