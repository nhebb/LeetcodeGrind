namespace LeetcodeGrind.Solutions;

// 2748. Number of Beautiful Pairs
public class P2748
{
    public int CountBeautifulPairs(int[] nums)
    {
        int GetFirstDigit(int n)
        {
            while (n > 9)
            {
                n /= 10;
            }
            return n;
        }

        int Gcd(int a, int b)
        {
            if (b == 0) return a;

            return Gcd(b, a % b);
        }

        var count = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var firstDigit = GetFirstDigit(nums[i]);
                var lastDigit = nums[j] % 10;
                if (Gcd(firstDigit, lastDigit) == 1)
                {
                    count++;
                }

            }
        }

        return count;
    }
}
