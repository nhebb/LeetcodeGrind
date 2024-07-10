namespace LeetcodeGrind.Solutions;

// 1579. Remove Max Number of Edges to Keep Graph Fully Traversable
public class P1579
{
    public int MaxNumEdgesToRemove(int n, int[][] edges)
    {
        var alice = Enumerable.Range(0, n).ToArray();
        var bob = Enumerable.Range(0, n).ToArray();
        var paths = 0;

        // Set the common edges (edge[0] == 3) for union find first ...
        foreach (var edge in edges)
        {
            if (edge[0] != 3)
                continue;

            var p = edge[1] - 1;
            var q = edge[2] - 1;

            if (Find(alice, p) != Find(alice, q) || Find(bob, p) != Find(bob, q))
            {
                Join(alice, p, q);
                Join(bob, p, q);
                paths++;
            }
        }

        // ... then set the edges that are alice or bob only.
        foreach (var edge in edges)
        {
            if (edge[0] == 3)
                continue;

            var p = edge[1] - 1;
            var q = edge[2] - 1;
            if (edge[0] == 1 && Find(alice, p) != Find(alice, q))
            {
                Join(alice, p, q);
                paths++;
            }
            else if (edge[0] == 2 && Find(bob, p) != Find(bob, q))
            {
                Join(bob, p, q);
                paths++;
            }
        }

        return Connected(alice) && Connected(bob)
            ? edges.Length - paths
            : -1;
    }

    void Join(int[] parents, int p, int q)
    {
        p = Find(parents, p);
        q = Find(parents, q);
        parents[p] = q;
    }

    int Find(int[] parents, int p)
    {
        if (parents[p] == p)
        {
            return p;
        }
        parents[p] = Find(parents, parents[p]);
        return parents[p];
    }

    bool Connected(int[] parents)
    {
        var parent = Find(parents, parents[0]);

        foreach (var node in parents)
        {
            if (parent != Find(parents, node))
            {
                return false;
            }
        }

        return true;
    }
}