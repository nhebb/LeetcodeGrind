namespace LeetcodeGrind.Solutions;

// 961. N-Repeated Element in Size 2N Array
public class P0961
{
    public int RepeatedNTimes(int[] nums)
    {
        return nums.GroupBy(x => x)
                   .Where(g => g.Count() == nums.Length / 2)
                   .Select(g => g.Key)
                   .First();
    }
}
