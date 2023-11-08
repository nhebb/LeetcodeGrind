namespace LeetcodeGrind.Solutions;

// 56. Merge Intervals
public class P0056
{
    public int[][] Merge(int[][] intervals)
    {
        var list = new List<int[]>(intervals).OrderBy(x => x[0]).ToList();
        var skiplist = new HashSet<int>();

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i][1] >= list[i + 1][0])
            {
                list[i + 1][0] = Math.Min(list[i][0], list[i + 1][0]);
                list[i + 1][1] = Math.Max(list[i][1], list[i + 1][1]);
                skiplist.Add(i);
            }
        }

        var res = new List<int[]>();
        for (int i = 0; i < list.Count; i++)
        {
            if (!skiplist.Contains(i))
            {
                res.Add(list[i]);
            }
        }

        return res.ToArray();
    }
}
