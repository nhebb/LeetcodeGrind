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
}
