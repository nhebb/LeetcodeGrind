namespace LeetcodeGrind.Solutions;

// 261. Graph Valid Tree (locked)
public class P0261
{
    public bool ValidTree(int n, int[][] edges)
    {
        if (n == 0) return true;

        var adj = new List<List<int>>(n);
        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        bool Dfs(int i, int prev)
        {
            if (!visited.Add(i))
                return false;

            foreach (var neighbor in adj[i])
            {
                if (neighbor != prev)
                {
                    if (!Dfs(neighbor, i))
                        return false;
                }
            }
            return true;
        }

        return Dfs(0, -1) && visited.Count == n;
    }
}
