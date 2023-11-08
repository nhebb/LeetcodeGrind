namespace LeetcodeGrind.Solutions;

// 1980. Find Unique Binary String
public class P1980
{
    public string FindDifferentBinaryString(string[] nums)
    {
        var vals = nums.Select(x => Convert.ToInt32(x, 2));
        var max = vals.Max();
        var all = Enumerable.Range(0, max + 1);
        var missing = all.Except(vals);

        var len = nums[0].Length;
        return missing.Count() == 0
            ? Convert.ToString((max + 1), 2).PadLeft(len, '0')
            : Convert.ToString(missing.First(), 2).PadLeft(len, '0');
    }
}
