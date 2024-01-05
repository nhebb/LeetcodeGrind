namespace LeetcodeGrind.Solutions;

// 2363. Merge Similar Items
public class P2363
{
    public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
    {
        var d = new Dictionary<int, int>();

        for (int i = 0; i < items1.Length; i++)
        {
            d[items1[i][0]] = items1[i][1];
        }

        for (int i = 0; i < items2.Length; i++)
        {
            if (d.ContainsKey(items2[i][0]))
            {
                d[items2[i][0]] += items2[i][1];
            }
            else
            {
                d[items2[i][0]] = items2[i][1];
            }
        }

        var result = new List<IList<int>>();
        foreach (var kvp in d)
        {
            result.Add(new int[] { kvp.Key, kvp.Value });
        }

        result.Sort((a, b) => a[0] - b[0]);

        return result;
    }
}
