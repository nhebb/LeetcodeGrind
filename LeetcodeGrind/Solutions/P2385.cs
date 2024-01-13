using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2385. Amount of Time for Binary Tree to Be Infected
public class P2385
{
    public int AmountOfTime(TreeNode root, int start)
    {
        if (root.left is null && root.right is null)
            return 0;

        var graph = new Dictionary<int, List<int>>();

        // Build graph
        var buildQ = new Queue<(TreeNode node, int parent)>();
        buildQ.Enqueue((root, -1));
        while (buildQ.Count > 0)
        {
            var count = buildQ.Count;
            for (int i = 0; i < count; i++)
            {
                var item = buildQ.Dequeue();
                var node = item.node;
                var parent = item.parent;

                if (node.val != start && node.left is null && node.right is null)
                {
                    continue;
                }

                graph[node.val] = new List<int>();
                if (parent != -1)
                {
                    graph[node.val].Add(parent);
                }

                if (node.left is not null)
                {
                    graph[node.val].Add(node.left.val);
                    buildQ.Enqueue((node.left, node.val));
                }
                if (node.right is not null)
                {
                    graph[node.val].Add(node.right.val);
                    buildQ.Enqueue((node.right, node.val));
                }
            }
        }

        var minutes = 0;
        var visited = new HashSet<int>();
        var bfsQ = new Queue<(int nodeVal, int time)>();
        bfsQ.Enqueue((start, 0));
        while (bfsQ.Count > 0)
        {
            var count = bfsQ.Count;
            for (int i = 0; i < count; i++)
            {
                var item = bfsQ.Dequeue();
                var nodeVal = item.nodeVal;
                var time = item.time;
                visited.Add(nodeVal);
                minutes = Math.Max(minutes, time);

                if (graph.ContainsKey(nodeVal))
                {
                    foreach (var neighbor in graph[nodeVal])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            bfsQ.Enqueue((neighbor, time + 1));
                        }
                    }
                }
            }
        }

        return minutes;
    }
}
