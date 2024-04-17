namespace LeetcodeGrind.Solutions;

// 3115. Maximum Prime Difference
public class P3115
{
    public int MaximumPrimeDifference(int[] nums)
    {
        var first = 0;
        var last = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (IsPrime(nums[i]))
            {
                first = i;
                break;
            }
        }

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (IsPrime(nums[i]))
            {
                last = i;
                break;
            }
        }

        return last - first;
    }

    private bool IsPrime(int n)
    {
        if (n <= 2 || n % 2 == 0)
        {
            return n == 2;
        }

        for (int i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
