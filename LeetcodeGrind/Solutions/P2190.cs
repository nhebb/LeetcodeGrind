namespace LeetcodeGrind.Solutions;

// 2190. Most Frequent Number Following Key In an Array
public class P2190
{
    public int MostFrequent(int[] nums, int key)
    {
        var d = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length-1; i++)
        {
            if (nums[i] == key)
            {
                var target = nums[i + 1];
                if (d.ContainsKey(target))
                {
                    d[target]++;
                }
                else
                {
                    d[target] = 1;
                }
            }
        }

        var maxCount = 0;
        var maxTarget = 0;
        foreach (var kvp in d)
        {
            if (kvp.Value > maxCount)
            {
                maxCount = kvp.Value;
                maxTarget = kvp.Key;
            }
        }

        return maxTarget;
    }
}
