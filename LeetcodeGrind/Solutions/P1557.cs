namespace LeetcodeGrind.Solutions;

// 1557. Minimum Number of Vertices to Reach All Nodes
public class P1557
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var destination = new bool[n];

        // Mark destination nodes as true
        foreach (var edge in edges)
            destination[edge[1]] = true;

        // If node hasn't been marked as a destination,
        // then it's a root
        var result = new List<int>();
        for (int i = 0; i < destination.Length; i++)
        {
            if (!destination[i])
                result.Add(i);
        }

        return result;
    }
    public IList<int> FindSmallestSetOfVertices2(int n, IList<IList<int>> edges)
    {
        var hs = Enumerable.Range(0, n).ToHashSet();

        foreach (var edge in edges)
            hs.Remove(edge[1]);

        return hs.ToList();
    }
}
