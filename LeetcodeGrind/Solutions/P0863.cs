using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 863. All Nodes Distance K in Binary Tree
public class P0863
{
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        var start = target.val;
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

        var ans = new List<int>();
        var visited = new HashSet<int>();
        var bfsQ = new Queue<(int nodeVal, int dist)>();
        bfsQ.Enqueue((start, 0));
        while (bfsQ.Count > 0)
        {
            var count = bfsQ.Count;
            for (int i = 0; i < count; i++)
            {
                var item = bfsQ.Dequeue();
                var nodeVal = item.nodeVal;
                var dist = item.dist;
                visited.Add(nodeVal);
                if (dist == k)
                {
                    ans.Add(nodeVal);
                }

                if (graph.ContainsKey(nodeVal))
                {
                    foreach (var neighbor in graph[nodeVal])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            bfsQ.Enqueue((neighbor, dist + 1));
                        }
                    }
                }
            }
        }

        return ans;
    }
}

