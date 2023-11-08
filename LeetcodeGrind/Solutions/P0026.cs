namespace LeetcodeGrind.Solutions;

// 26. Remove Duplicates from Sorted Array
public class P0026
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums == null) { return 0; }

        int len = nums.Length;
        if (len <= 1) { return len; }

        for (int i = nums.Length - 1; i >= 1; i--)
        {
            if (nums[i - 1] == nums[i])
            {
                for (int j = i - 1; j < len - 1; j++)
                {
                    nums[j] = nums[j + 1];
                }
                len--;
            }
        }
        return len;
    }
}
