namespace LeetcodeGrind.Solutions;

// 1791. Find Center of Star Graph
public class P1791
{
    // HashSet solution  - O(n) time and space
    // but n will effectively top out at 4
    public int FindCenter(int[][] edges)
    {
        var hs = new HashSet<int>();
        foreach (var edge in edges)
        {
            if (!hs.Add(edge[0]))
                return edge[0];

            if (!hs.Add(edge[1]))
                return edge[1];
        }

        return 0;
    }

    // O(1) time and space by @votrubac (ofc)
    public int FindCenter2(int[][] edges)
    {
        // Since each edge will contain the center,
        // you only need to check the first 2 edges.
        return (edges[0][0] == edges[1][0] || edges[0][1] == edges[1][0])
            ? edges[1][0]
            : edges[1][1];
    }
}
