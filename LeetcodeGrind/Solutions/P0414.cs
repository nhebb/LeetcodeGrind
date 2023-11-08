namespace LeetcodeGrind.Solutions;

// 414. Third Maximum Number
public class P0414
{
    public int ThirdMax(int[] nums)
    {
        var sorted = nums.OrderByDescending(x => x)
                         .Distinct();

        if (sorted.Count() < 3)
            return sorted.First();
        else
            return sorted.Skip(2).Take(1).First();
    }
}
