namespace LeetcodeGrind.Solutions;

// 3095. Shortest Subarray With OR at Least K I
public class P3095
{
    // Brute force
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        int len = int.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j < nums.Length; j++)
            {
                var orValue = 0;
                for (int idx = i; idx <= j; idx++)
                {
                    orValue |= nums[idx];
                }

                if (orValue >= k)
                {
                    len = Math.Min(len, j - i + 1);
                }
            }
        }

        return len == int.MaxValue
            ? -1
            : len;
    }
}
