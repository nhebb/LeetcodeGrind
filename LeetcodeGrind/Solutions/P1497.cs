namespace LeetcodeGrind.Solutions;

// 1497. Check If Array Pairs Are Divisible by k
public class P1497
{
    public bool CanArrange(int[] arr, int k)
    {
        var freq = new int[k];
        foreach (var num in arr)
        {
            var val = num % k;
            if (val < 0)
            {
                val += k;
            }

            freq[val]++;
        }

        // There should be an even freq of nums
        // that are exactly divisible by k.
        if (freq[0] % 2 != 0)
        {
            return false;
        }

        for (int i = 1; i <= k / 2; i++)
        {
            if (freq[i] != freq[k - i])
            {
                return false;
            }
        }

        return true;
    }
}
