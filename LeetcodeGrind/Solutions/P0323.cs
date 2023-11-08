namespace LeetcodeGrind.Solutions;

// 323. Number of Connected Components in an Undirected Graph
public class P0323
{
    public int CountComponents(int n, int[][] edges)
    {
        var parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;

        foreach (var edge in edges)
        {
            var p = edge[0];
            while (p != parent[p])
                p = parent[p];

            var q = edge[1];
            while (q != parent[q])
                q = parent[q];

            if (p == q) continue;

            if (p < q)
                (p, q) = (q, p);

            parent[p] = q;
        }

        var count = 0;
        for (int i = 0; i < parent.Length; i++)
        {
            if (parent[i] == i)
                count++;
        }

        return count;
    }
}
