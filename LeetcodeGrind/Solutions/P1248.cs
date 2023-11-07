namespace LeetcodeGrind.Solutions;

// 1248. Count Number of Nice Subarrays
public class P1248
{
    public int NumberOfSubarrays(int[] nums, int k)
    {
        // Store the numbers of evens that are left (pre) and
        // right (post) of an index in dictionaries. Add 1 for
        // the empty set.
        var pre = new Dictionary<int, int>();
        var post = new Dictionary<int, int>();
        var even = 0;
        for (int idx = 0; idx < nums.Length; idx++)
        {
            if (nums[idx] % 2 == 0)
                even++;
            else
            {
                pre[idx] = even + 1;
                even = 0;
            }
        }

        even = 0;
        for (int idx = nums.Length - 1; idx >= 0; idx--)
        {
            if (nums[idx] % 2 == 0)
                even++;
            else
            {
                post[idx] = even + 1;
                even = 0;
            }
        }

        // find first odd
        int i = 0;
        while (i < nums.Length && nums[i] % 2 == 0)
            i++;
        var odd = 1;
        int j = i;

        // begin sliding window
        var count = 0;
        while (i < nums.Length && j < nums.Length)
        {
            if (odd == k)
            {
                // increment the count by left x right
                count += (pre[i] * post[j]);

                // slide i to the next odd value
                i++;
                odd--;
                while (i < nums.Length && nums[i] % 2 == 0)
                    i++;

                // handle case where k == 1
                if (j < i)
                {
                    odd++;
                    j = i;
                }
            }
            else
            {
                j++;
                if (j < nums.Length && nums[j] % 2 == 1)
                    odd++;
            }
        }

        return count;
    }
}
