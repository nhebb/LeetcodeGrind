namespace LeetcodeGrind.Solutions;

// 1508. Range Sum of Sorted Subarray Sums
public class P1508
{
    public int RangeSum(int[] nums, int n, int left, int right)
    {
        var sums = new List<int>();
        for (int i = 0; i < n; i++)
        {
            var sum = 0;
            for (int j = i; j < n; j++)
            {
                sum += nums[j];
                sums.Add(sum);
            }
        }

        sums.Sort();

        long result = 0;
        for (int i = left - 1; i < right; i++)
        {
            result += sums[i];
        }

        var modulo = Math.Pow(10, 9) + 7;
        return (int)(result % modulo);
    }
}
