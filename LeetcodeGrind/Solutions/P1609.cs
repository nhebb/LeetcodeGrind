using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1609. Even Odd Tree
public class P1609
{
    public bool IsEvenOddTree(TreeNode root)
    {
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var depth = 0;

        while (q.Count > 0)
        {
            var count = q.Count;
            var even = depth % 2 == 0;
            var expectedMod = even ? 1 : 0;

            var node = q.Dequeue();
            if (node.val % 2 != expectedMod)
            {
                return false;
            }
            var lastVal = node.val;

            if (node.left != null)
                q.Enqueue(node.left);
            if (node.right != null)
                q.Enqueue(node.right);

            for (int i = 1; i < count; i++)
            {
                node = q.Dequeue();
                if (node.val % 2 != expectedMod ||
                    even && node.val <= lastVal ||
                    !even && node.val >= lastVal)
                {
                    return false;
                }
                lastVal = node.val;

                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }

            depth++;
        }

        return true;
    }
}
