namespace LeetcodeGrind.Solutions;

// 2192. All Ancestors of a Node in a Directed Acyclic Graph
public class P2192
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        var parents = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            if (parents.TryGetValue(edge[1], out var list))
            {
                list.Add(edge[0]);
            }
            else
            {
                parents[edge[1]] = new List<int>() { edge[0] };
            }
        }

        void Dfs(int node, HashSet<int> hs, List<int> current)
        {
            hs.Add(node);
            if (parents.TryGetValue(node, out var list))
            {
                foreach (var item in list)
                {
                    if (!hs.Contains(item))
                    {
                        current.Add(item);
                        Dfs(item, hs, current);
                    }
                }
            }
        }

        var answer = new List<IList<int>>();
        for (int i = 0; i < n; i++)
        {
            var hs = new HashSet<int>();
            var current = new List<int>();
            Dfs(i, hs, current);
            current.Sort();
            answer.Add(current);
        }

        return answer;
    }
}
