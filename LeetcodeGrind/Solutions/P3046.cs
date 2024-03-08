namespace LeetcodeGrind.Solutions;

// 3046. Split the Array
public class P3046
{
    public bool IsPossibleToSplit(int[] nums)
    {
        if(nums.Length % 2 != 0) 
            return false;

        var maxPairs = nums.Length / 2;

        var d = nums.GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

        var pairs = 0;
        foreach (var kvp in d)
        {
            if (kvp.Value > 2)
                return false;
            else if (kvp.Value == 2)
                pairs++;
        }

        return pairs <= maxPairs;
    }
}
