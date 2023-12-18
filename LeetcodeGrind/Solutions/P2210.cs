namespace LeetcodeGrind.Solutions;

// 2210. Count Hills and Valleys in an Array
public class P2210
{
    public int CountHillValley(int[] nums)
    {
        var nums2 = new List<int>() { nums[0] };

        // Remove consecutive duplicates
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums2.Add(nums[i]);
            }
        }

        var count = 0;
        for (int i = 1; i < nums2.Count - 1; i++)
        {
            if (nums2[i] < nums2[i - 1] && nums2[i] < nums2[i + 1] ||
                nums2[i] > nums2[i - 1] && nums2[i] > nums2[i + 1])
            {
                count++;
            }
        }

        return count;
    }
}
