namespace LeetcodeGrind.Solutions;

// 1331. Rank Transform of an Array
public class P1331
{
    public int[] ArrayRankTransform(int[] arr)
    {
        var list = arr.ToList();
        list.Sort();

        var rank = 1;
        var ranks = new Dictionary<int, int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (!ranks.ContainsKey(list[i]))
            {
                ranks[list[i]] = rank;
                rank++;
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = ranks[arr[i]];
        }

        return arr;
    }
}
