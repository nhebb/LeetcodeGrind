namespace LeetcodeGrind.Solutions;

// 2614. Prime In Diagonal
public class P2614
{
    public int DiagonalPrime(int[][] nums)
    {
        int n = nums.Length;
        var ans = 0;

        for (int i = 0; i < n; i++)
        {
            if (IsPrime(nums[i][i]))
            {
                ans = Math.Max(ans, nums[i][i]);
            }

            if (IsPrime(nums[i][n - i - 1]))
            {
                ans = Math.Max(ans, nums[i][n - i - 1]);
            }
        }

        return ans;
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
