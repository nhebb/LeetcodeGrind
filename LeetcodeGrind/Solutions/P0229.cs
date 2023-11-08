namespace LeetcodeGrind.Solutions;

// 229. Majority Element II
public class P0229
{
    public IList<int> MajorityElementII(int[] nums)
    {
        var numCount = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (!numCount.TryAdd(num, 1))
            {
                numCount[num]++;
            }
        }

        var ans = new List<int>();
        var target = nums.Length / 3;
        return numCount.Where(x => x.Value > target)
                       .Select(x => x.Key)
                       .ToList();
    }
}
