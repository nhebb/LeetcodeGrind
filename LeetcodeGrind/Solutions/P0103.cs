using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 103. Binary Tree Zigzag Level Order Traversal
public class P0103
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var levels = new List<IList<int>>();
        if (root == null)
        {
            return levels;
        }

        var q = new Queue<(TreeNode node, int level)>();
        q.Enqueue((root, 0));

        while (q.Count > 0)
        {
            var curNode = q.Dequeue();

            if (levels.Count == curNode.level)
                levels.Add(new List<int>());
            levels[^1].Add(curNode.node.val);

            if (curNode.node.left != null)
                q.Enqueue((curNode.node.left, curNode.level + 1));
            if (curNode.node.right != null)
                q.Enqueue((curNode.node.right, curNode.level + 1));
        }

        for (int i = 0; i < levels.Count; i++)
        {
            if (i % 2 == 1)
            {
                levels[i] = levels[i].Reverse().ToList();
            }
        }

        return levels;
    }
}
