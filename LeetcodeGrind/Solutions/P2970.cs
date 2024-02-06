namespace LeetcodeGrind.Solutions;

// 2970. Count the Number of Incremovable Subarrays I
public class P2970
{
    public int IncremovableSubarrayCount(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        var outerValues = new List<int>();

        // Brute force. Iterate over every possible range.
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                // Add numbers before i and after j
                outerValues.AddRange(nums[0..i]);
                outerValues.AddRange(nums[(j + 1)..]);

                // Check whether values are ascending
                var ascending = true;
                for (int a = 1; a < outerValues.Count; a++)
                {
                    if (outerValues[a - 1] >= outerValues[a])
                    {
                        ascending = false;
                        break;
                    }
                }

                // Increment count only if outer values are strictly ascending
                if (ascending)
                {
                    count++;
                }

                // Reset for next iteration
                outerValues.Clear();
            }
        }

        return count;
    }
}
