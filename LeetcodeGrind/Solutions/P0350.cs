namespace LeetcodeGrind.Solutions;

// 350. Intersection of Two Arrays II
public class P0350
{
    public int[] IntersectII(int[] nums1, int[] nums2)
    {
        var d1 = nums1.GroupBy(x => x)
                      .ToDictionary(g => g.Key, g => g.Count());
        var d2 = nums2.GroupBy(x => x)
                      .ToDictionary(g => g.Key, g => g.Count());

        var intersects = new List<int>();
        foreach (var kvp in d1)
        {
            if (d2.TryGetValue(kvp.Key, out var count))
            {
                count = Math.Min(kvp.Value, count);
                for (int i = 0; i < count; i++)
                {
                    intersects.Add(kvp.Key);
                }
            }
        }

        return intersects.ToArray();
    }
}
