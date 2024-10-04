namespace LeetcodeGrind.Solutions;

// 1331. Rank Transform of an Array
public class P1331
{
    public int[] ArrayRankTransform(int[] arr)
    {
        var n = arr.Length;
        var list = new int[n];
        Array.Copy(arr, list, n);
        Array.Sort(list);

        var rank = 1;
        var ranks = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            if (!ranks.ContainsKey(list[i]))
            {
                ranks[list[i]] = rank;
                rank++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = ranks[arr[i]];
        }

        return arr;
    }

    public int[] ArrayRankTransform2(int[] arr)
    {
        var list = arr.OrderBy(x => x).Distinct().ToList();
        var ranks = new Dictionary<int, int>();

        for (int i = 0; i < list.Count; i++)
        {
            ranks[list[i]] = i + 1;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = ranks[arr[i]];
        }

        return arr;
    }
}
