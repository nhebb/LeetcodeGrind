namespace LeetcodeGrind.Solutions;

// 446. Arithmetic Slices II - Subsequence
public class P0446
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        var result = 0;
        var map = new List<Dictionary<long, int>>(nums.Length);

        for (int i = 0; i < nums.Length; i++)
        {
            map.Add(new Dictionary<long, int>());

            for (int j = 0; j < i; j++)
            {
                long diff = (long)nums[i] - nums[j];
                map[i].TryGetValue(diff, out var count1);
                map[j].TryGetValue(diff, out var count2);
                map[i][diff] = count1 + count2 + 1;
                result += count2;
            }
        }

        return result;
    }
}
