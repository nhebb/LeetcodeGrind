namespace LeetcodeGrind.Solutions;

// 2444. Count Subarrays With Fixed Bounds
public class P2444
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        var minFound = false;
        var maxFound = false;

        var firstValidIndex = 0;
        var minIndex = 0;
        var maxIndex = 0;
        long count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > maxK || nums[i] < minK)
            {
                minFound = false;
                maxFound = false;
                firstValidIndex = i + 1;
            }

            if (nums[i] == minK)
            {
                minIndex = i;
                minFound = true;
            }

            if (nums[i] == maxK)
            {
                maxIndex = i;
                maxFound = true;
            }

            if (minFound && maxFound)
            {
                count += Math.Min(minIndex, maxIndex) - firstValidIndex + 1;
            }
        }

        return count;
    }
}
