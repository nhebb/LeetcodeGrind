using System.ComponentModel.Design;

namespace LeetcodeGrind.Solutions;

// 310. Minimum Height Trees
public class P0310
{
    // BFS - TLE
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        if (edges.Length == 0)
            return new List<int>() { 0 };

        var paths = new Dictionary<int, List<int>>(n);
        for (int i = 0; i < n; i++)
        {
            paths[i] = new List<int>();
        }

        foreach (var edge in edges)
        {
            paths[edge[0]].Add(edge[1]);
            paths[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        var minHeight = int.MaxValue;
        var result = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (paths[i].Count == 0)
                continue;

            var q = new Queue<int>();
            q.Enqueue(i);
            var height = 0;

            while (q.Count > 0)
            {
                var len = q.Count;
                for (int j = 0; j < len; j++)
                {
                    var vertex = q.Dequeue();
                    visited.Add(vertex);
                    foreach (var neighbor in paths[vertex])
                    {
                        if (visited.Contains(neighbor))
                            continue;
                        q.Enqueue(neighbor);
                    }
                }

                height++;
            }

            if (height < minHeight)
            {
                result.Clear();
                result.Add(i);
                minHeight = height;
            }
            else if (height == minHeight)
            {
                result.Add(i);
            }

            visited.Clear();
        }

        return result;
    }


    // Topological sort
    public IList<int> FindMinHeightTrees2(int n, int[][] edges)
    {
        if (n == 1)
            return new List<int>() { 0 };

        var paths = new HashSet<int>[n];
        foreach (var edge in edges)
        {
            if (paths[edge[0]] == null)
                paths[edge[0]] = new HashSet<int>();
            paths[edge[0]].Add(edge[1]);

            if (paths[edge[1]] == null)
                paths[edge[1]] = new HashSet<int>();
            paths[edge[1]].Add(edge[0]);
        }

        var leaves = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (paths[i].Count == 1)
            {
                leaves.Enqueue(i);
            }
        }

        while (n > 2)
        {
            var newLeaves = new List<int>();
            while (leaves.Count > 0)
            {
                n--;
                var leaf = leaves.Dequeue();
                var neighbor = paths[leaf].First();
                paths[neighbor].Remove(leaf);
                if (paths[neighbor].Count == 1)
                {
                    newLeaves.Add(neighbor);
                }
            }

            foreach (var leaf in newLeaves)
            {
                leaves.Enqueue(leaf);
            }
        }

        var result = new List<int>();
        while (leaves.Count > 0)
        {
            result.Add(leaves.Dequeue());
        }

        return result;
    }

}
