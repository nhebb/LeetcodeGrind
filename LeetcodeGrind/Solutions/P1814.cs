using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1814. Count Nice Pairs in an Array
public class P1814
{
    private const int _mod = 1_000_000_007;

    public int CountNicePairs(int[] nums)
    {


        // Nice pair, where i != j is defined as:
        //  => nums[i] + rev(nums[j]) == nums[j] + rev(nums[i])
        // Which can be rearranged as
        //  => nums[i] - rev(nums[i]) == nums[j] - rev(nums[j])

        // If all the numbers are less than 10, the formula
        // above will yield an array full of 0's,
        // so we can just return the number of pairs.
        var allZeros = !nums.Any(x => x >= 10);
        if (allZeros)
        {
            return UpdateCount(nums.Length - 1, 0);
        }

        var numMinusReverse = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] < 10)
                numMinusReverse[i] = 0;
            else
                numMinusReverse[i] = nums[i] - ReverseNumber(nums[i]);
        }

        Array.Sort(numMinusReverse);
        var count = 0;

        var j = 0;
        var k = 1;
        while (k < numMinusReverse.Length)
        {
            if (numMinusReverse[k] != numMinusReverse[j])
            {
                var n = k - j;
                count = UpdateCount(n, count);
                j = k;
            }
            else if (k == numMinusReverse.Length - 1)
            {
                var n = k - j + 1;
                count = UpdateCount(n, count);
            }
            k++;
        }

        return count % _mod;
    }

    private int UpdateCount(long n, int count)
    {
        n = (n % _mod);
        long numPairs = (n * (n - 1) / 2) % _mod;
        return (int)((count + numPairs) % _mod);
    }

    private int ReverseNumber(int number)
    {
        var result = 0;
        while (number > 0)
        {
            result *= 10;
            result += number % 10;
            number /= 10;
        }
        return result;
    }
}
