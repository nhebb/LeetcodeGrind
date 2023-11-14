namespace LeetcodeGrind.Solutions;

// 2246. Longest Path With Different Adjacent Characters
public class P2246
{
    public int LongestPath(int[] parent, string s)
    {
        if (parent.Length == 1) return 1;

        var adj = new Dictionary<int, List<int>>();
        for (int i = 0; i < parent.Length; i++)
            adj[i] = new List<int>();

        for (int i = 1; i < parent.Length; i++)
        {
            adj[i].Add(parent[i]);
            adj[parent[i]].Add(i);
        }

        int max = 0;
        int Dfs(int node, int prev)
        {
            int max1 = 0;
            int max2 = 0;

            foreach (var child in adj[node])
            {
                if (child != prev)
                {
                    var res = Dfs(child, node);
                    if (res > max1)
                    {
                        if (max1 > max2)
                            max2 = max1;
                        max1 = res;
                    }
                    else if (res > max2)
                    {
                        max2 = res;
                    }
                }
            }

            max = Math.Max(max, 1 + max1 + max2);

            if (prev != -1 && s[prev] == s[node])
                return 0;
            else
                return 1 + Math.Max(max1, max2);
        }

        _ = Dfs(0, -1);

        return max;
    }
}
