namespace LeetcodeGrind.Solutions;

// 2070. Most Beautiful Item for Each Query
public class P2070
{
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        var price = items.Select(x => x[0]).ToArray();
        var beauty = items.Select(x => x[1]).ToArray();
        Array.Sort(price, beauty);

        // sweep left to right and then right to left
        for (int i = 1; i < beauty.Length; i++)
        {
            beauty[i] = Math.Max(beauty[i], beauty[i - 1]);
        }
        for (int i = beauty.Length - 2; i >= 0; i--)
        {
            if (price[i] == price[i + 1])
            {
                beauty[i] = Math.Max(beauty[i], beauty[i + 1]);
            }
        }

        var result = new List<int>(queries.Length);
        foreach (var q in queries)
        {
            var index = Array.BinarySearch(price, q);
            if (index < 0)
            {
                index = ~index - 1;
            }

            if (index >= 0)
            {
                result.Add(beauty[index]);
            }
            else
            {
                result.Add(0);
            }
        }

        return result.ToArray();
    }
}
