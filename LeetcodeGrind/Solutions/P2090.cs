namespace LeetcodeGrind.Solutions;

// 2090. K Radius Subarray Averages
public class P2090
{
    public int[] GetAverages(int[] nums, int k)
    {
        var res = new int[nums.Length];
        Array.Fill(res, -1);

        if (nums.Length >= k * 2)
        {
            var count = 2 * k + 1;
            long sum = 0;
            var i = 0;

            // stop before end of +/-k range -- it makes the
            // while loop cleaner when adding nums[j] to sum
            for (i = 0; i < 2 * k; i++)
                sum += nums[i];

            var j = 2 * k;
            i = k;

            while (j < nums.Length)
            {
                sum += nums[j];
                res[i] = (int)(sum / count);
                sum -= nums[i - k];
                i++;
                j++;
            }
        }

        return res;
    }
}
