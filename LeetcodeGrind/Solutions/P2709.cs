namespace LeetcodeGrind.Solutions;

// 2709. Greatest Common Divisor Traversal
public class P2709
{
    public bool CanTraverseAllPairs(int[] nums)
    {
        var nodes = new Dictionary<int, int>();
        var visited = new bool[nums.Length];
        var graph = new List<int>[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            graph[i] = [];
        }

        void AddNodesToGraph(int prime, int index)
        {
            if (nodes.TryGetValue(prime, out int value))
            {
                graph[index].Add(value);
                graph[value].Add(index);
            }
            else
            {
                nodes[prime] = index;
            }
        }

        void Dfs(int node)
        {
            visited[node] = true;
            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    Dfs(neighbor);
                }
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            for (var j = 2; j * j <= num; j++)
            {
                if (num % j == 0)
                {
                    AddNodesToGraph(j, i);
                    while (num % j == 0)
                    {
                        num /= j;
                    }
                }
            }

            if (num > 1)
            {
                AddNodesToGraph(num, i);
            }
        }

        Dfs(0);

        return !visited.Any(x => !x);
    }
}
