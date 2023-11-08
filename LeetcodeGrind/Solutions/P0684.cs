namespace LeetcodeGrind.Solutions;

// 684. Redundant Connection
public class P0684
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var maxEdge = 0;
        foreach (var edge in edges)
        {
            if (edge[0] > maxEdge)
                maxEdge = edge[0];
            if (edge[1] > maxEdge)
                maxEdge = edge[1];
        }

        var parent = new int[maxEdge + 1];
        for (int i = 0; i < parent.Length; i++)
            parent[i] = i;

        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        void Union(int x, int y)
        {
            parent[Find(x)] = Find(y);
        }

        bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }

        var ans = new int[2];

        foreach (var edge in edges)
        {
            if (Connected(edge[0], edge[1]))
            {
                ans[0] = edge[0];
                ans[1] = edge[1];
            }
            else
            {
                Union(edge[0], edge[1]);
            }
        }

        return ans;
    }
}
