namespace LeetcodeGrind.Solutions;

// 3075. Maximize Happiness of Selected Children
public class P3075
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        Array.Sort(happiness);
        var i = happiness.Length - 1;
        long result = 0;
        long decrement = 0;

        while (k > 0)
        {
            result += Math.Max(0, happiness[i] - decrement);
            decrement++;
            k--;
            i--;
        }

        return result;
    }
}
