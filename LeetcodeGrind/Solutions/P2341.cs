namespace LeetcodeGrind.Solutions;

// 2341. Maximum Number of Pairs in Array
public class P2341
{
    public int[] NumberOfPairs(int[] nums)
    {
        var d = nums.GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

        var pairs = 0;
        var leftovers = 0;

        foreach (var kvp in d)
        {
            pairs += kvp.Value / 2;
            leftovers += kvp.Value % 2;
        }

        return new int[] { pairs, leftovers };
    }
}
