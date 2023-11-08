namespace LeetcodeGrind.Solutions;

// 1431. Kids With the Greatest Number of Candies
public class P1431
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var maxCandies = candies[0];
        for (int i = 1; i < candies.Length; i++)
        {
            maxCandies = Math.Max(candies[i], maxCandies);
        }

        var ans = new bool[candies.Length];
        for (int i = 0; i < candies.Length; i++)
        {
            ans[i] = candies[i] + extraCandies >= maxCandies;
        }

        return ans;
    }
}
