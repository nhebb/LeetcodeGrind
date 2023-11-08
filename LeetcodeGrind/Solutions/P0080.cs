namespace LeetcodeGrind.Solutions;

// 80. Remove Duplicates from Sorted Array II
public class P0080
{
    public int RemoveDuplicatesII(int[] nums)
    {
        int i = 0;
        foreach (var num in nums)
        {
            if (i < 2 || num > nums[i - 2])
            {
                nums[i] = num;
                i++;
            }
        }
        return i;
    }
}
