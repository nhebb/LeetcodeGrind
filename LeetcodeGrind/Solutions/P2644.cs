namespace LeetcodeGrind.Solutions;

// 2644. Find the Maximum Divisibility Score
public class P2644
{
    public int MaxDivScore(int[] nums, int[] divisors)
    {
        var max = 0;
        var result = divisors[0];

        for (int i = 0; i < divisors.Length; i++)
        {
            var count = nums.Where(x => x % divisors[i] == 0).Count();

            if (count > max || (count == max && divisors[i] < result))
            {
                max = count;
                result = divisors[i];
            }
        }

        return result;
    }
}
