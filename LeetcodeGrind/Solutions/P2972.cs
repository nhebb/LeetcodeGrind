using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2972. Count the Number of Incremovable Subarrays II
public class P2972
{
    public long IncremovableSubarrayCount(int[] nums)
    {
        int n = nums.Length;
        var start = new List<int>();
        var end = new List<int>();

        // Find the contiguous increasing elements
        // at the start of the array
        for (int i = 0; i < n; i++)
        {
            if (start.Count == 0 || start[^1] < nums[i])
            {
                start.Add(nums[i]);
            }
            else
            {
                break;
            }
        }

        // Find the contiguous increasing elements
        // at the end of the array
        for (int i = n - 1; i >= 0; i++)
        {
            if (end.Count == 0 || end[^1] > nums[i])
            {
                end.Add(nums[i]);
            }
            else
            {
                break;
            }
        }

        // If the entire array is increasing, simply
        // calculate the total number of subarrays.
        if (start.Count + end.Count > n)
        {
            return ((long)n) * (n + 1) / 2;
        }

        long count = start.Count + end.Count;
        var j = 0;
        var k = 0;
        end.Reverse(); // end was created backwards

        // Use two pointers to identify non-increasing spans
        while (j < start.Count && k < end.Count)
        {
            if (start[j] < end[k])
            {
                count += end.Count - k;
                j++;
            }
            else
            {
                k++;
            }
        }

        return count + 1;
    }
}
