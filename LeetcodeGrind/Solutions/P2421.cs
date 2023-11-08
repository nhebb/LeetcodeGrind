namespace LeetcodeGrind.Solutions;

// 2421. Number of Good Paths
public class P2421
{
    public int NumberOfGoodPaths(int[] vals, int[][] edges)
    {
        // Sort edges lowest to highest
        Array.Sort(edges, (a, b) => Math.Max(vals[a[0]], vals[a[1]]) -
                                    Math.Max(vals[b[0]], vals[b[1]]));

        // Because a node is its own subtree, we initialize 
        // the result with the number of nodes.
        var result = vals.Length;

        var parent = new int[result];
        var count = new int[result];

        for (int i = 0; i < vals.Length; i++)
            parent[i] = i;

        // local functions for Union-Find
        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        bool Union(int a, int b)
        {
            int p = Find(a);
            int q = Find(b);

            // skip equal node parents
            if (p == q)
                return false;

            // if values are equal, update the result and the count
            if (vals[p] == vals[q])
            {
                result += (count[p] + 1) * (count[q] + 1);
                count[p] += count[q] + 1;
                parent[q] = p;
                return true;
            }

            // set the lower value as the parent
            if (vals[p] > vals[q])
                parent[q] = p;
            else
                parent[p] = q;

            return true;
        }

        foreach (int[] edge in edges)
            Union(edge[0], edge[1]);

        return result;
    }
}
