namespace LeetcodeGrind.Solutions;

// 1443. Minimum Time to Collect All Apples in a Tree
public class P1443
{
    public int MinTime(int n, int[][] edges, IList<bool> hasApple)
    {
        if (!hasApple.Any(x => x == true))
            return 0;

        var children = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            if (children.TryGetValue(edge[0], out var list1))
                list1.Add(edge[1]);
            else
                children[edge[0]] = new List<int>() { edge[1] };

            if (children.TryGetValue(edge[1], out var list2))
                list2.Add(edge[0]);
            else
                children[edge[1]] = new List<int>() { edge[0] };
        }

        if (children[0].Count == 0)
            return 0;

        var time = 0;
        var visited = new HashSet<int>();

        bool Dfs(int node, int dist)
        {
            visited.Add(node);
            var result = false;
            if (hasApple[node])
            {
                time += dist;
                dist = 0;
                result = true;
            }

            if (children.ContainsKey(node))
            {
                foreach (var child in children[node])
                {
                    if (visited.Contains(child))
                        continue;

                    if (Dfs(child, dist + 1))
                    {
                        time += 1;
                        result = true;
                        dist = 0;
                    }
                }
            }
            visited.Remove(node);
            return result;
        }

        _ = Dfs(0, 0);

        return time;
    }
}
