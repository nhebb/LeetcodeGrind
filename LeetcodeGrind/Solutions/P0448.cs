namespace LeetcodeGrind.Solutions;

// 448. Find All Numbers Disappeared in an Array
public class P0448
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var hs = new HashSet<int>();
        foreach (var num in nums)
            hs.Add(num);

        var missing = new List<int>();
        for (int i = 1; i <= nums.Length; i++)
        {
            if (!hs.Contains(i))
                missing.Add(i);
        }

        return missing;
    }
}
