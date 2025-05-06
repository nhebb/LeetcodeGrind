namespace LeetcodeGrind.Solutions;

// 2206. Divide Array Into Equal Pairs
public class P2206
{
    public bool DivideArray(int[] nums)
    {
        var d = nums.GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

        foreach (var kvp in d)
        {
            if (kvp.Value % 2 == 1)
            {
                return false;
            }
        }

        return true;
    }

    public bool DivideArray2(int[] nums)
    {
        var hs = new HashSet<int>(nums.Length / 2);
        foreach (var num in nums)
        {
            if (!hs.Add(num))
            {
                hs.Remove(num);
            }
        }

        return hs.Count == 0;
    }
}
