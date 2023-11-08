namespace LeetcodeGrind.Solutions;

// 974. Subarray Sums Divisible by K
public class P0974
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var count = 0;
        var curr = 0;
        var prefMap = new Dictionary<int, int>();
        prefMap[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            curr += nums[i];
            curr %= k;
            if (curr < 0)
                curr += k;

            if (prefMap.ContainsKey(curr))
            {
                count += prefMap[curr];
                prefMap[curr] += 1;
            }
            else
            {
                prefMap[curr] = 1;
            }
        }
        return count;
    }
}
