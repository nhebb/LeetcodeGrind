namespace LeetcodeGrind.Solutions;

// 1409. Queries on a Permutation With Key
public class P1409
{
    public int[] ProcessQueries(int[] queries, int m)
    {
        var p = Enumerable.Range(1, m).ToList();
        var ans = new List<int>();

        foreach (var query in queries)
        {
            var idx = p.IndexOf(query);
            ans.Add(idx);
            p.RemoveAt(idx);
            p.Insert(0, query);
        }
        return ans.ToArray();
    }
}
