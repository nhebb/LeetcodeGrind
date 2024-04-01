namespace LeetcodeGrind.Solutions;

// 992. Subarrays with K Different Integers
public class P0992
{
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        var d = new Dictionary<int, int>();
        var count = 0;
        var left = -1;
        var n = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            d[nums[right]] = right;

            while (d[nums[n]] != n)
            {
                n++;
            }

            if (d.Count > k)
            {
                left = n++;
                d.Remove(nums[left]);

                while (d[nums[n]] != n)
                {
                    n++;
                }
            }

            if (d.Count == k)
            {
                count += n - left;
            }
        }

        return count;
    }
}
