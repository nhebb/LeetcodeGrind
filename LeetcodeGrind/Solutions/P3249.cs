namespace LeetcodeGrind.Solutions;

// 3249. Count the Number of Good Nodes
public class P3249
{
    public int CountGoodNodes(int[][] edges)
    {
        var nodes = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            if (nodes.ContainsKey(edge[0]))
                nodes[edge[0]].Add(edge[1]);
            else
                nodes[edge[0]] = new List<int>() { edge[1] };

            if (nodes.ContainsKey(edge[1]))
                nodes[edge[1]].Add(edge[0]);
            else
                nodes[edge[1]] = new List<int>() { edge[0] };
        }

        var count = 0;

        int Dfs(int nodeVal, int parentVal)
        {
            if (nodes[nodeVal].Count == 1 && nodes[nodeVal][0] == parentVal)
            {
                count++;
                return 0;
            }

            var total = 0;
            var first = -1;
            var same = true;

            foreach (var childVal in nodes[nodeVal])
            {
                if (childVal == parentVal)
                    continue;

                var subCount = Dfs(childVal, nodeVal);
                total += subCount;

                if (first == -1)
                    first = subCount;

                if (subCount != first)
                    same = false;
            }

            if (same)
                count++;

            return total + 1;
        }

        _ = Dfs(0, -1);

        return count;
    }
}
