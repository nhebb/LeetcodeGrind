namespace LeetcodeGrind.Solutions;

// 2928. Distribute Candies Among Children I
public class P2928
{
    public int DistributeCandies(int n, int limit)
    {
        var result = 0;

        for (int i = limit; i >= 0; i--)
        {
            var start = Math.Min(n - i, limit);

            for (int j = start; j >= 0; j--)
            {
                if (n - i - j > limit)
                {
                    break;
                }

                result++;
            }
        }

        return result;
    }
}
