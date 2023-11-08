namespace LeetcodeGrind.Solutions;

// 2404. Most Frequent Even Element
public class P2404
{
    public int MostFrequentEven(int[] nums)
    {
        var evens = nums.Where(x => x % 2 == 0);
        if (!evens.Any())
            return -1;

        var grps = evens.GroupBy(x => x);
        var num = grps.FirstOrDefault().Key;
        var maxFreq = 0;

        foreach (var grp in grps)
        {
            var count = grp.Count();
            if (count > maxFreq
                || (count == maxFreq && grp.Key < num))
            {
                maxFreq = count;
                num = grp.Key;
            }
        }
        return num;
    }
}
