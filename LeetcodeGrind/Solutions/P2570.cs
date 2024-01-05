namespace LeetcodeGrind.Solutions;

// 2570. Merge Two 2D Arrays by Summing Values
public class P2570
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        var d = new Dictionary<int, int>();

        for (int i = 0; i < nums1.Length; i++)
        {
            d[nums1[i][0]] = nums1[i][1];
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (d.ContainsKey(nums2[i][0]))
            {
                d[nums2[i][0]] += nums2[i][1];
            }
            else
            {
                d[nums2[i][0]] = nums2[i][1];
            }
        }

        var result = new int[d.Keys.Count][];
        var index = 0;
        foreach (var kvp in d)
        {
            result[index] = new int[] { kvp.Key, kvp.Value };
            index++;
        }

        Array.Sort(result, (a, b) => a[0] - b[0]);

        return result;
    }
}
