using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 501. Find Mode in Binary Search Tree
public class P0501
{
    public int[] FindMode(TreeNode root)
    {
        var d = new Dictionary<int, int>();
        var pq = new PriorityQueue<(int val, int count), int>();

        void Dfs(TreeNode node)
        {
            if (node is null)
                return;

            if (d.ContainsKey(node.val))
                d[node.val]++;
            else
                d[node.val] = 1;

            Dfs(node.left);
            Dfs(node.right);
        }

        Dfs(root);

        foreach (var kvp in d)
        {
            pq.Enqueue((kvp.Key, kvp.Value), -kvp.Value);
        }

        var res = new List<int>();
        var item = pq.Dequeue();
        res.Add(item.val);
        var count = item.count;
        while (pq.Peek().count == count)
        {
            item = pq.Dequeue();
            res.Add(item.val);
        }

        return res.ToArray();
    }
}
