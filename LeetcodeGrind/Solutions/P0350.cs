namespace LeetcodeGrind.Solutions;

// 350. Intersection of Two Arrays II
public class P0350
{
    public int[] IntersectII(int[] nums1, int[] nums2)
    {
        var d1 = new Dictionary<int, int>();
        var d2 = new Dictionary<int, int>();

        foreach (var num in nums1)
            if (!d1.TryAdd(num, 1))
                d1[num]++;

        foreach (var num in nums2)
            if (!d2.TryAdd(num, 1))
                d2[num]++;

        var res = new List<int>();
        foreach (var kvp in d1)
        {
            if (d2.TryGetValue(kvp.Key, out var val))
            {
                var count = Math.Min(kvp.Value, val);
                for (int i = 0; i < count; i++)
                    res.Add(kvp.Key);
            }
        }

        return res.ToArray();
    }
}
