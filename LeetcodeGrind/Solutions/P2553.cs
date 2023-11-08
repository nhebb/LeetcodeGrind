namespace LeetcodeGrind.Solutions;

// 2553. Separate the Digits in an Array
public class P2553
{
    public int[] SeparateDigits(int[] nums)
    {
        var ans = new List<int>();
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            var n = nums[i];
            while (n > 0)
            {
                ans.Add(n % 10);
                n /= 10;
            }
        }
        ans.Reverse();
        return ans.ToArray();
    }
}
