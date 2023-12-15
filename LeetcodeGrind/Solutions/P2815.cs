namespace LeetcodeGrind.Solutions;

// 2815. Max Pair Sum in an Array
public class P2815
{
    public int MaxSum(int[] nums)
    {
        var digits = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            var digit = GetMaxDigit(nums[i]);
            if(!digits.ContainsKey(digit))
            {
                digits[digit] = new List<int>();
            }
            digits[digit].Add(nums[i]);
        }

        var sum = -1;
        foreach (var kvp in digits)
        {
            if (kvp.Value.Count >= 2)
            {
                var curSum = kvp.Value.OrderByDescending(x => x).Take(2).Sum();
                sum = Math.Max(sum, curSum);
            }
        }

        return sum;
    }

    private int GetMaxDigit(int n)
    {
        var max = 0;
        while (n > 0)
        {
            max = Math.Max(max, n % 10);
            n /= 10;
        }
        return max;
    }
}
