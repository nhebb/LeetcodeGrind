using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 102. Binary Tree Level Order Traversal
public class P0102
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var lists = new List<IList<int>>();
        if (root == null)
            return lists;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            // Get the count before enqueueing new nodes,
            // then the next 'count' nodes dequeued will
            // be on the same level
            var count = queue.Count;
            var list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                list.Add(node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            lists.Add(list);
        }
        return lists;
    }
}
