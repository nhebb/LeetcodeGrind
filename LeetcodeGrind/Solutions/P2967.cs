namespace LeetcodeGrind.Solutions;

// 2967. Minimum Cost to Make Array Equalindromic
public class P2967
{
    public long MinimumCost(int[] nums)
    {
        Array.Sort(nums);

        var n = nums.Length;
        var median = n % 2 != 0
            ? nums[n / 2]
            : (int)((nums[(n + 1) / 2] + nums[n / 2]) / 2);

        long result = long.MaxValue;
        for (int i = median; i >= 1; i--)
        {
            if (IsPalindrome(i))
            {
                result = Math.Min(result, GetCost(nums, i));
                break;
            }
        }

        for (int i = median; i <= Math.Pow(10, 9); i++)
        {
            if (IsPalindrome(i))
            {
                result = Math.Min(result, GetCost(nums, i));
                break;
            }
        }

        return result;
    }

    private bool IsPalindrome(int n)
    {
        var s = n.ToString();
        var i = 0;
        var j = s.Length - 1;

        while (i < j)
        {
            if (s[i] != s[j])
                return false;
            i++;
            j--;
        }

        return true;
    }

    private long GetCost(int[] nums, int target)
    {
        long cost = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            cost += Math.Abs(target - nums[i]);
        }

        return cost;
    }
}